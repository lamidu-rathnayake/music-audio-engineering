# CLAUDE.md

Project instructions for coding agents working in `music-audio-engineering/`. Read this fully before making changes. `README.md` holds the roadmap and progress; this file holds the rules.

## 1. What this repo is

A learning lab plus a university capstone (**Audio Studio**: a browser-native, loudness-aware mastering assistant with a C++/WASM real-time engine and a server-side ML tagger). It has two kinds of code:

- `labs/`: phase experiments. The goal is **my understanding**, not just working code.
- `capstone/`: the product. The goal is correctness, measured real-time behavior, and a defensible thesis.

Current phase and progress: read the header of `README.md`. Don't assume, and **never tick README checkboxes or edit the progress line**. I do that myself.

## 2. How to work with me

- I'm a student building depth on purpose. **Explain the mechanism, not just the fix.** State the failure mode, why it happens, and the general principle so it transfers.
- **Engine-First.** In `labs/04-audioworklet`, `labs/05-dsp`, and `labs/07-cpp-wasm`, implement the mechanic by hand before reaching for a library. Ask before adding a dependency to a lab.
- Be direct and technically rigorous. If my code or idea is wrong, say so plainly and explain why. Don't soften errors or praise by default.
- When several valid approaches exist, name the trade-offs (latency vs throughput, safety vs performance, simplicity vs flexibility). Recommend one.
- If you aren't sure an API exists or behaves as you claim (Web Audio, `Atomics`, Emscripten flags, Librosa), **say so** and point to the spec/MDN/docs instead of guessing.
- Keep diffs small and focused. Don't refactor unrelated code.

## 3. Capstone technology boundary (locked)

Allowed:

| Layer | Technology |
|---|---|
| UI | React, strict TypeScript, **client-side static export** |
| Audio engine | Web Audio API, AudioWorklet, **C++ compiled to WASM** (Emscripten) |
| Visuals | **Canvas 2D** on `requestAnimationFrame` |
| Host / BFF | ASP.NET Core (C#), YARP reverse proxy, OIDC (code + PKCE, optional) |
| ML service | FastAPI, PyTorch, Librosa, scikit-learn |

**Do not introduce** (deferred or out of scope): SSR/RSC/Next.js API routes, WebGL, ONNX Runtime Web / TensorFlow.js, Media Source Extensions streaming, Rust, JUCE/VST3/AU/CLAP, Web MIDI, generative audio model training, single-browser-only features. If I ask for one, remind me it's outside the boundary and point to `README.md` Section 12. Proceed only if I explicitly confirm an override, and record it in an ADR.

Undecided (see `docs/adr/`): Vite vs Next static export (ADR-003). Until it's decided, don't scaffold framework server features.

## 4. Layers, languages, and directories

One language per layer. Don't cross layers.

| Path | Language | Responsibility |
|---|---|---|
| `capstone/apps/web/` | TypeScript (strict) + React | UI, controls, state. **Never owns the audio graph.** |
| `capstone/packages/dsp-core/` | C++17/20 | Dependency-free DSP: biquad EQ, BS.1770 meter, limiter, compressor. No Emscripten/JUCE headers in the core. |
| `capstone/packages/dsp-core/wasm/` *(proposed)* | C++ | Thin Emscripten adapter only |
| `capstone/services/bff/` | C# | Static hosting, session, proxy, security headers |
| `capstone/services/ml/` | Python | Feature extraction, training, inference API |
| `labs/*` | per phase | Experiments and reports |
| `docs/adr/`, `docs/log/`, `docs/thesis/` | Markdown | Decisions, weekly logs, thesis |
| `benchmarks/` | any | Reproducible perf harnesses and results |

Datasets and model weights are **not committed**. Reference them via config paths.

## 5. Real-time rules (audio thread)

These apply to `AudioWorkletProcessor.process()` and every C++ function reachable from it. Budget: a 128-frame quantum is about 2.9 ms at 44.1 kHz. Target `process()` p99 **under 50% of the quantum**.

**Never inside the audio path:**

- Heap allocation. In JS this includes `new Float32Array`, object/array/closure literals, spread, array destructuring, `.map/.filter/.slice/.concat`, string building, template literals. Use indexed `for` loops over preallocated buffers.
- `console.log`, `fetch`, dynamic `import()`, `postMessage` every quantum, or any I/O.
- Locks, `Atomics.wait`, blocking of any kind.
- C++: `new/delete/malloc`, `std::vector` growth, `std::string`, `std::function`, iostream, exceptions, `std::mutex`, unbounded loops, syscalls.

**Always:**

- **Preallocate everything on the hot path** in the constructor (JS) or `prepare()` (C++). Lifecycle: `prepare(sampleRate, maxBlockSize)` → `process(...)` → `reset()`. `process()` is `noexcept`.
- Telemetry goes through a shared stats block or an SPSC ring, not messages or logs.
- Handle **denormals** in feedback/IIR paths (WASM has no flush-to-zero mode: flush state manually).
- Smooth parameter changes to avoid zipper noise and clicks. Use Direct Form II Transposed for biquads.
- Only `std::atomic` types with `is_always_lock_free` (static_assert it).

**SPSC ring buffer over `SharedArrayBuffer`:**

- Exactly one producer and one consumer per ring; exactly one writer per index.
- Power-of-two capacity, indices as monotonically increasing unsigned integers masked by `capacity - 1`.
- Producer writes data, *then* publishes the write index with `Atomics.store`. Consumer loads the index, *then* reads data.
- Pad head and tail indices onto separate cache lines.
- Never block. On empty: output silence and increment an atomic underrun counter. On full: apply the documented drop policy.

**WASM in the worklet:**

- No `fetch` in the worklet scope, and `TextDecoder`/`TextEncoder` may be missing. Compile on the main thread, transfer the `WebAssembly.Module`, instantiate synchronously.
- `memory.grow` **detaches typed-array views.** Preallocate memory and never hold a view across a call that could grow it.

**Never write these files wholesale from a prompt** (see Section 8): worklet processors, lock-free queues, inner DSP loops.

## 6. Security rules

- Session cookie: `__Host-` prefix, `HttpOnly; Secure; SameSite=Strict; Path=/`, no `Domain`.
- **No CORS.** Everything is same-origin through the BFF. Don't add permissive CORS to make something work.
- Send `Cross-Origin-Opener-Policy: same-origin` and `Cross-Origin-Embedder-Policy: require-corp`. Verify `crossOriginIsolated === true`. Keep a CSP.
- The ML service is reachable **only** from the BFF (private network) and requires an API key: hashed at rest, constant-time compare, rotatable.
- Treat uploads as hostile: enforce size and duration limits, validate with Pydantic, decode untrusted audio defensively.
- No secrets in the repo. `.env` files are gitignored. Never log tokens, keys, or session IDs.
- Dependency audits: `npm audit`, `pip-audit`, `dotnet list package --vulnerable`.

## 7. ML rules

- **Baseline first** (MFCC + SVM/logistic regression), then the CNN, then any temporal ablation.
- **Artist-disjoint** train/val/test splits. Never split by track.
- Features are computed **only on the server** with Librosa (ADR-004). The client never computes model features.
- Seed everything; keep configs in files; report macro-F1 and PR-AUC with bootstrap confidence intervals; write a model card.
- ML is never in the audio path.

## 8. Delegation boundaries and review protocol

**Draft-only, review-required.** For worklet processors, lock-free queues, inner DSP loops, and anything with a hard deadline:

- Keep the diff small. Don't refactor around it.
- State the invariants (thread ownership, memory ordering, preallocation) in a comment or in your reply.
- List how it could fail: race, underrun, hidden allocation, view detachment.
- Mark the change as needing my line-by-line review.

**Before you report any change done, check your own diff:**

1. Any allocation, lock, or blocking call reachable from `process()`?
2. Any thread-safety, aliasing, or ordering assumption I haven't verified?
3. Any API you used but haven't confirmed exists (hallucination check)?
4. Any violation of the Section 3 boundary or Section 4 layering?
5. Are there tests, and do they fail without your fix?

**Tests are ground truth.** Never change expected values, tolerances, test vectors, or reference oracles (`labs/05-dsp/`) to make a test pass. If you think a test is wrong, explain why and wait for me.

## 9. Testing and verification

- **Oracles:** the Phase 5 TS/Python reference implementations. The C++ engine must match them within tolerance.
- **Native and WASM parity:** run the same tests against native and WASM builds (WASM under Node).
- **Zero-allocation proof (C++):** a test with an `operator new` counting hook asserts zero calls inside `process()`.
- **Golden files:** render with `OfflineAudioContext` and compare.
- **Real-time behavior:** per-quantum timing into the stats block; 30-minute soak with 0 underruns; repeat under 4× CPU throttle.
- **Browsers:** check Chrome, Firefox, and Safari for every lab that touches the audio path.

**Commands** (fill in as each layer is created; don't invent commands, ask me):

| Task | Command |
|---|---|
| Web dev / test | TODO |
| dsp-core native build + tests | TODO |
| dsp-core WASM build | TODO |
| BFF run / test | TODO |
| ML service run / test | TODO |
| Benchmarks | TODO |

## 10. Conventions

- **Commits:** `phase-NN: message`. One concern per commit. Tag `phase-NN-done` at each phase exit (I do this).
- **TypeScript:** `strict: true`. No `any`. No `@ts-ignore` or `@ts-expect-error` without a comment explaining why. `as` casts need a justification. Model worklet messages as discriminated unions. Use branded types for units (dB vs linear, Hz).
- **React:** the audio graph lives in a plain TS class outside React; components hold a handle in a ref. Effects must be idempotent and clean up (StrictMode double-invokes them). Meter and visual data go to the canvas via `requestAnimationFrame` or `useSyncExternalStore`, never `useState` at 60 Hz. No audio work in render.
- **C++:** value semantics, RAII, preallocated buffers, no exceptions/RTTI in the `dsp-core` target, no dependencies in `dsp-core`.
- **Python:** type hints, fixed seeds, config-driven experiments.
- **C#:** nullable reference types enabled.
- **Tooling:** propose before adding a linter, formatter, or framework.

## 11. Documentation

- **ADRs** in `docs/adr/`, numbered and immutable once accepted. To change a decision, add a new ADR that supersedes the old one. Existing: ADR-001 (ML never in the audio path), ADR-002 (C++ for `dsp-core`), ADR-003 (static export tooling), ADR-004 (server-side features only).
- **Weekly logs** in `docs/log/YYYY-Www.md`. I write these.
- When you make a design decision that isn't obvious, propose an ADR instead of burying it in a comment.

## 12. Keep this file honest

If a rule here is wrong, outdated, or conflicts with an ADR, tell me and propose the edit. Don't silently work around it.