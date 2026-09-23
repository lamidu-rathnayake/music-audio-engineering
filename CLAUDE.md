# CLAUDE.md

Project instructions for coding agents working in `music-audio-engineering/`.

Read this fully before making changes.

> `README.md` is the short project overview.
> `ROADMAP-PREREQUISITES.md` contains the pre-roadmap foundations to master before Year 3 begins.
> `ROADMAP.md` contains the 2-year learning roadmap and progress.
> `CLAUDE.md` contains the engineering rules for AI coding agents.

---

## 1. What This Repository Is

A learning laboratory and university capstone project:

**Web-Native Audio Production Environment** (previously "Audio Studio") — a browser-native, loudness-aware audio application with a **C++/WASM real-time audio engine** and a **server-side ML service**.

```text
labs/       → Learning experiments and research
capstone/   → Main application
docs/       → Architecture, logs and thesis
benchmarks/ → Performance experiments
```

The goal is not simply working code.

The goal is:

**Understand → Implement → Measure → Document**

Never tick progress items or modify progress tracking unless explicitly asked.

---

## 2. How to Work With Me

* Explain the **mechanism**, not only the fix.
* State why something fails and the general principle behind it.
* Follow **Engine-First** in DSP, AudioWorklet and C++ work.
* Ask before introducing new dependencies into learning labs.
* Be direct and technically rigorous.
* Explain trade-offs when multiple approaches exist.
* Never invent APIs, flags, browser behavior or library features.
* If uncertain, say so and refer to official documentation.
* Keep changes small and focused.
* Do not refactor unrelated code.

---

# 3. Locked Technology Boundary

| Layer                | Technology                                     |
| --------------------- | ----------------------------------------------- |
| UI                    | React + strict TypeScript                       |
| Web                   | Client-side static export                       |
| Audio                 | Web Audio API + AudioWorklet                    |
| Native Prototype DSP  | C++ + JUCE (desktop plugin, Capstone Part 1)    |
| Browser DSP           | C++ compiled to WebAssembly, packaged as WAM v2 |
| WASM                  | Emscripten                                      |
| Visuals               | Canvas 2D                                       |
| Backend               | Python + FastAPI + Pydantic                     |
| Authentication        | OIDC + PKCE                                     |
| ML                    | Python + PyTorch + Librosa + scikit-learn       |
| ML API                | FastAPI + Pydantic                              |
| Edge Inference        | ONNX + ONNX Runtime Web + WebGPU                |

### Explicitly Out of Scope

Do not introduce the following without an explicit architecture override:

* ASP.NET Core / C#
* Node.js / Express
* Next.js server features / SSR / RSC
* WebGL
* TensorFlow.js
* Media Source Extensions
* Rust
* VST3 / AU / CLAP before the defense
* Web MIDI
* Tone.js
* Third-party JS audio/DSP frameworks
* Generative audio model training

> **Note:** JUCE and ONNX Runtime Web were previously listed here. Both are now locked-in per the current roadmap (`ROADMAP-2.md`): JUCE is the core of Year 4 – Semester 1 (Capstone Part 1's native plugin), and ONNX Runtime Web + WebGPU is the core of Year 4 – Semester 2's edge-inference work. If this doesn't match your intent, treat it as an architecture change worth its own ADR.

The project is **Engine-First**. The core DSP engine must be built directly rather than hidden behind an audio framework.

If an out-of-scope technology is genuinely required, propose an ADR before introducing it.

---

# 4. Layering

One language per core layer.

| Directory                           | Language              | Responsibility                                      |
| ------------------------------------ | --------------------- | ---------------------------------------------------- |
| `capstone/apps/web/`                 | TypeScript            | UI, controls and state                               |
| `capstone/apps/native-plugin/`       | C++ (JUCE)            | Native desktop plugin prototype (Capstone Part 1)    |
| `capstone/packages/dsp-core/`        | C++                   | Dependency-free DSP                                  |
| `capstone/packages/dsp-core/wasm/`   | C++                   | Thin Emscripten adapter                              |
| `capstone/services/backend/`         | Python                | FastAPI backend, `wwwroot/`, sessions and security   |
| `capstone/services/ml/`              | Python                | FastAPI ML service, training, inference, ONNX export |
| `labs/`                              | Per phase             | Experiments and reports                              |
| `docs/`                              | Markdown              | ADRs, logs and thesis                                |
| `benchmarks/`                        | Appropriate language  | Reproducible performance tests                       |

The React application must **not own the audio graph directly**.

The audio engine belongs outside React.

Datasets and model weights are not committed to the repository.

---

# 5. Real-Time Audio Rules

These rules apply to `AudioWorkletProcessor.process()` and every C++ function reachable from it.

A 128-frame quantum at 44.1 kHz is approximately **2.9 ms**.

Target:

```text
process() p99 < 50% of the audio quantum
```

### Never do inside the audio path

* Heap allocation
* Blocking operations
* Locks
* `Atomics.wait`
* Network or file I/O
* Logging
* Dynamic imports
* Uncontrolled object creation
* C++ `new/delete`
* `malloc`
* Growing vectors
* `std::string`
* `std::function`
* `std::mutex`
* Exceptions
* Unbounded loops
* System calls

### Always

* Preallocate real-time buffers.
* Use indexed loops over reusable buffers.
* Keep `process()` allocation-free.
* Use SPSC queues for communication.
* Handle denormals in feedback/IIR paths.
* Smooth parameter changes.
* Use Direct Form II Transposed for biquads.
* Keep real-time processing deterministic.

Lifecycle:

```text
prepare(sampleRate, maxBlockSize)
        ↓
     process()
        ↓
      reset()
```

`process()` should be `noexcept` in the C++ engine.

---

# 6. SharedArrayBuffer / SPSC Rules

Each ring buffer has:

* One producer
* One consumer
* One writer per index

Use:

* Power-of-two capacity
* Monotonically increasing indices
* Masking with `capacity - 1`
* Atomic publication of write/read indices
* Separate cache lines for producer/consumer indices

Never block.

On underrun:

```text
Output silence
      +
Increment underrun counter
```

On overflow, follow the documented drop policy.

---

# 7. WASM Rules

* Do not perform network loading from the AudioWorklet.
* Compile/load WASM outside the real-time path.
* Transfer the compiled `WebAssembly.Module` when appropriate.
* Be careful with WASM memory growth.
* Do not retain typed-array views across operations that may grow memory.
* Keep the DSP core independent of Emscripten headers where possible.

The core should remain reusable:

```text
dsp-core
   │
   ├── Native C++ (JUCE prototype, Capstone Part 1)
   │
   └── WASM adapter (WAM v2, Capstone Part 2)
```

ONNX/WebGPU model loading and inference follow the same rule: load and run outside the real-time audio path (see Section 10).

---

# 8. Backend / Frontend Hosting

The Python backend uses FastAPI and serves the compiled React application as static files from a dedicated `wwwroot/` directory.

Recommended structure:

```text
capstone/
├── apps/
│   ├── web/
│   │   ├── src/
│   │   └── dist/                 # React build output
│   │
│   └── native-plugin/            # JUCE desktop plugin prototype (Capstone Part 1)
│
└── services/
    ├── backend/
    │   ├── app/
    │   │   └── main.py
    │   └── wwwroot/          # deployed React static files
    │
    └── ml/
        └── app/             # separate FastAPI ML service
```

The frontend build is copied/generated into `services/backend/wwwroot/`. FastAPI serves that directory and the normal API routes take precedence over frontend files. Client-side routing must fall back to `index.html`.

Use FastAPI's frontend/static-file support rather than introducing another web server framework for the capstone.

# 9. Security Rules

The backend is implemented with **Python + FastAPI**. It serves the built React frontend from `wwwroot/` and exposes the application API. A separate Python/FastAPI ML service handles model inference. FastAPI is not limited to API-only applications; it can serve static frontend builds and HTML.

### Session

Use:

```text
__Host-<name>
HttpOnly
Secure
SameSite=Strict
Path=/
```

Do not set `Domain`.

### Architecture

The browser communicates with the application through the same-origin FastAPI backend.

Do not introduce permissive CORS merely to solve an integration problem.

### Cross-Origin Isolation

Use:

```text
Cross-Origin-Opener-Policy: same-origin
Cross-Origin-Embedder-Policy: require-corp
```

Verify:

```ts
crossOriginIsolated === true
```

Maintain an appropriate CSP. Note that loading ONNX Runtime Web / WebGPU may have its own CSP and cross-origin-isolation requirements — verify these when that work begins in Year 4 – Semester 2.

### ML Service

The ML functionality runs in the Python backend boundary. Keep ML inference code separated from ordinary application routes and never place ML work in the real-time audio path.

Use a machine-to-machine API key:

* Never commit it.
* Never log it.
* Store only a secure representation when persistence is required.
* Compare securely.
* Support rotation.

### Uploads

Treat uploaded audio as untrusted.

Apply:

* File-size limits
* Duration limits
* Input validation
* Defensive decoding

### Secrets

Never commit:

```text
.env
API keys
tokens
session IDs
passwords
```

Use `.gitignore` appropriately.

### Dependency Auditing

Use the appropriate ecosystem tools:

```text
npm audit
pip-audit
```

Do not introduce Node.js/npm tooling for the backend; the backend is Python/FastAPI.

---

# 10. ML Rules

### Baseline First

Start with:

```text
MFCC
  ↓
Classical Model
  ↓
Evaluation
```

Then introduce:

```text
Mel Spectrogram
  ↓
CNN
  ↓
Evaluation
```

Only then consider temporal models or attention.

### Dataset

Use artist-disjoint splits.

Never split tracks randomly if that allows the same artist to appear across train and test sets.

### Feature Extraction

Audio ML features are calculated on the server using Librosa.

The client does not calculate model features.

### Edge Export

Once a model is trained and evaluated server-side:

* Export it to ONNX as a separate, documented step (not part of the training loop).
* Validate that ONNX output matches the original PyTorch output before shipping it to the browser.
* Browser-side inference (ONNX Runtime Web + WebGPU) is a deployment target, not a training environment — never train or fine-tune in the browser.

### Reproducibility

Experiments must have:

* Fixed seeds
* Configuration files
* Reproducible preprocessing
* Documented datasets
* Documented metrics

Report:

* Macro-F1
* PR-AUC
* Confidence intervals
* Error analysis

Create a model card for the final model.

### Critical Rule

**ML is never part of the real-time audio path.** This includes ONNX/WebGPU inference — it runs outside `AudioWorkletProcessor.process()`.

---

# 11. AI Delegation Rules

AI assistance is encouraged, but critical engineering code requires human review.

### Review Required

Never blindly generate or accept:

* AudioWorklet processors
* Lock-free queues
* Atomic synchronization
* Inner DSP loops
* Real-time C++ code
* Memory-management code

For these changes, document:

* Thread ownership
* Memory-ordering assumptions
* Preallocation assumptions
* Possible races
* Possible underruns
* Possible hidden allocations

Before considering the change complete, check:

1. Any allocation reachable from `process()`?
2. Any blocking or locking?
3. Any unverified thread-safety assumption?
4. Any API that may have been hallucinated?
5. Any violation of the architecture boundary?
6. Are tests covering the change?

---

# 12. Testing & Verification

### DSP Oracles

Reference implementations live in:

```text
labs/05-dsp/
```

The C++ implementation must be compared against the reference implementations.

### Native / WASM Parity

Run equivalent tests against:

```text
Native C++ (JUCE prototype)
    ↕
WebAssembly (WAM v2)
```

### ONNX / PyTorch Parity

Run equivalent tests against:

```text
PyTorch model
    ↕
Exported ONNX model (browser-side)
```

### Allocation Testing

Use allocation-counting tests to verify that `process()` performs zero allocations.

### Golden Audio

Use deterministic audio rendering and compare results against reference output.

### Real-Time Testing

Measure:

* Per-quantum processing time
* p50
* p95
* p99
* CPU usage
* Underruns
* Long-duration stability

Target:

```text
30-minute soak
+
0 underruns
```

Also test under CPU pressure.

### Browser Testing

Audio-path changes should be checked against:

* Chrome
* Firefox
* Safari

WebGPU/ONNX Runtime Web availability varies by browser — verify a fallback or clear error path where it's unsupported.

---

# 13. Coding Conventions

### TypeScript

* `strict: true`
* Avoid `any`
* Avoid unnecessary type assertions
* No unexplained `@ts-ignore`
* Use discriminated unions for worklet messages
* Use branded types for units such as Hz, dB and linear gain

### React

* Audio graph lives outside React.
* Components hold references to audio objects.
* Effects must clean up correctly.
* Do not use React state for 60 Hz audio-meter updates.
* Use Canvas / `requestAnimationFrame` or an external store.
* Never perform audio work during render.

### C++

* RAII
* Value semantics
* Preallocated buffers
* No exceptions in `dsp-core`
* No unnecessary RTTI
* No external dependencies in the core DSP library (the JUCE-based native prototype in `apps/native-plugin/` is the one exception, since it depends on JUCE by design)

### Python

* Type hints
* Fixed seeds
* Configuration-driven experiments
* Reproducible environments

### Tooling

Propose new frameworks, formatters, linters or dependencies before adding them.

---

# 14. Documentation

### ADRs

Architecture decisions belong in:

```text
docs/adr/
```

Accepted ADRs should not be silently rewritten.

Supersede decisions with a new ADR.

Important decisions include:

* ML is never in the audio path.
* C++ is used for `dsp-core`.
* JUCE is used for the native desktop plugin prototype in Capstone Part 1, before the DSP is ported to WebAssembly in Capstone Part 2.
* Static client-side web architecture.
* Server-side ML feature extraction.
* ONNX + WebGPU (via ONNX Runtime Web) is the locked approach for browser-side edge inference.
* **Python + FastAPI is the locked backend architecture.**

### Weekly Logs

Located in:

```text
docs/log/YYYY-Www.md
```

These are maintained by me.

If a design decision is significant and not obvious, propose an ADR rather than hiding it in implementation code.

---

# 15. Git Conventions

Commit format:

```text
stage: message
```

where `stage` is one of: `prereq`, `y3s1`, `y3s2`, `y4s1`, `y4s2`.

Keep commits focused on one concern.

Do not modify unrelated files.

Stage completion tags:

```text
prereq-done
y3s1-done
y3s2-done
y4s1-done
y4s2-done
```

Progress tracking is maintained manually by me.

---

# 16. Keep This File Honest

If an instruction becomes outdated, conflicts with an ADR, or no longer matches the project architecture:

**tell me and propose the change.**

Do not silently work around the rules.

The current application architecture is:

```text
React / TypeScript
        ↓
Python / FastAPI
        ├── wwwroot/ → static React build
        ├── API      → application backend
        └── ML       → PyTorch + Librosa → ONNX export

Web Audio → AudioWorklet → C++ / WASM DSP engine (WAM v2, ported from the C++/JUCE native prototype)

Browser edge inference → ONNX Runtime Web + WebGPU (loads the exported model directly, outside the real-time audio path)
```
