# 📊 The Checklist

### 🟧 Month 0: Setup (Sep 2026, now)

### 🟦 Level 3, Semester 1 (Months 1–6)

#### 🎓 University track
- [ ] 🎓 **CCS2360 Technology Challenge Competition**: prototype vehicle *only if* the topic is free (A5)
- [ ] 🎓 **CCS3300 Software Architecture**: feeds C4 diagrams, ADRs, and the real-time budget as a quality attribute
- [ ] 🎓 **CCS3310 Software Engineering Methods**: feeds requirements for the charter and iteration planning
- [ ] 🎓 **CCS3311 Software Quality Assurance**: feeds the test strategy and CI gates
- [ ] 🎓 **CCS3356 Natural Language Processing** *(elective)*: feeds sequence-modeling/attention concepts for the Phase 8 temporal ablation

#### Phase 1: Web Foundations & Secure Delivery: Month 1 (`01-web-foundations/`)
*Capstone component: the secure host. Exit: `crossOriginIsolated === true` verified by an automated test.*

- [x] 📖 Document structure & metadata **[DOM parsing, render blocking]**
- [x] 📖 Semantic HTML **[accessibility tree, screen-reader traversal]**
- [ ] 📖 HTML5 media (`<audio>`, `preload`, `data-*`) and HTTP Range/206 streaming from ASP.NET **[native decoding, buffering, partial content]**
- [ ] 📖 Forms and native constraint validation **[event delegation]**
- [ ] 📖 CSS box model, Flexbox/Grid **[style → layout → paint → composite]**
- [x] 📖 Secure architecture (ASP.NET `wwwroot`, `__Host-` cookies) **[same-origin policy, stateful vs stateless auth]**
- [ ] 📖 Cross-origin isolation: `Cross-Origin-Opener-Policy: same-origin`, `Cross-Origin-Embedder-Policy: require-corp`, baseline CSP **[why SharedArrayBuffer is gated: Spectre]**
- [ ] 📖 JS runtime internals: event loop, microtasks vs macrotasks, closures, async error propagation
- [ ] 🔀 Vitest + Playwright smoke test in CI **[applies CCS3311]**
- [ ] 📖 **Deliverable:** Audio Laboratory v0.1: securely hosted vanilla player with Range-request streaming

#### Phase 2: Web Audio API: Months 2–3 (`02-web-audio/`)
*Capstone component: engine host and test harness. Exit: no clicks on parameter changes (offline-render discontinuity check); scheduler drift-free for 10 minutes.*

- [ ] 📖 `AudioContext` lifecycle: autoplay policy, `resume()`, `baseLatency`/`outputLatency`, device changes **[hardware audio clock vs jittery main-thread timers]**
- [ ] 📖 Native node graph: Gain, Biquad, Delay, Convolver, DynamicsCompressor, Panner **[DAG and signal flow]**
- [ ] 📖 `AudioParam` automation and lookahead scheduling; click/zipper-noise avoidance **[sample-accurate scheduling]**
- [ ] 📖 `decodeAudioData`, `AudioBuffer` memory cost, `OfflineAudioContext` **[real-time vs offline rendering, golden-file testing]**
- [ ] 📖 Chrome/Firefox/Safari check for every lab from here on
- [ ] 🔀 C4 diagram + first ADR for the effects rack **[applies CCS3300]**
- [ ] 📖 **Deliverable:** Interactive multi-node synthesizer / effects rack

#### Phase 3: Visualization & React–Audio Integration: Months 4–5 (`03-visualization/`)
*Capstone component: visuals layer and UI shell. Exit: analyzer holds frame time under budget in the profiler; StrictMode causes no duplicate audio nodes.*

- [ ] 📖 Canvas 2D at 60 fps: `requestAnimationFrame`, DPR scaling, dirty rects, frame-time profiling **[vsync-aligned callbacks vs rasterization cost]**
- [ ] 📖 `AnalyserNode`: `fftSize`, smoothing, dB scaling **[time vs frequency domain]**
- [ ] 📖 Strict TypeScript: discriminated-union message protocol, branded unit types (dB vs linear, Hz)
- [ ] 📖 React vs audio-node lifetimes: StrictMode double-invoked effects, refs, `useSyncExternalStore`, canvas outside React state
- [ ] 🔀 Component + E2E tests for the analyzer **[applies CCS3311]**
- [ ] 📖 **Deliverable:** Audio Waveform & Frequency Spectrograph Analyzer (React + strict TS)

#### Month 6 buffer: exams (light work only)
- [ ] 🔀 Charter v0 (one page: problem, draft RQs, candidate datasets) **[uses CCS3310 requirements]**
- [ ] 📖 Python environment + NumPy primer (starts Lane B)

---

### 🟩 Level 3, Semester 2 (Months 7–12)

#### 🎓 University track
- [ ] 🎓 **CCS3302 Introduction to Research Methods**: feeds Charter v1, RQs, evaluation design, literature review
- [ ] 🎓 **CCS3313 Advanced Software Design**: feeds `dsp-core` API design and message-protocol patterns
- [ ] 🎓 **SMA2307 Discrete Mathematics**: feeds graph theory (routing DAG) and modular arithmetic (ring-buffer masking)
- [ ] 🎓 **CCS4340 Machine Learning** *(elective)*: feeds baselines, metrics, cross-validation, overfitting
- [ ] 🎓 **SMA2202 Linear Algebra** *(elective)*: feeds vector spaces, DFT as a matrix, PCA/SVD

#### Phase 4: AudioWorklet, Shared Memory & First WASM: Months 7–8 (`04-audioworklet/`)
*Capstone component: the real-time transport. Exit: 30-minute soak, 0 underruns; allocation audit shows nothing attributable to `process()`.*

- [ ] 📖 `AudioWorkletProcessor`: 128-frame quantum, `process()` rules (no allocation, no locks, no blocking), `MessagePort` for non-critical messages only **[dedicated real-time thread with its own global scope, still garbage-collected]**
- [ ] 🔀 SPSC ring buffer on `SharedArrayBuffer` + `Atomics`: power-of-two capacity with masking **[modular arithmetic from SMA2307]**, one writer per index, publication order, cache-line padding, never block
- [ ] 📖 **WASM-in-worklet spike:** compile on the main thread, transfer the `WebAssembly.Module`, instantiate synchronously (no `fetch` in the worklet), preallocate memory, handle `memory.grow` detaching typed-array views
- [ ] 📖 Per-quantum timing telemetry into a shared stats block; soak-test harness
- [ ] 📖 FastAPI basics; FastAPI stub `/analyze` returning dummy tags behind the BFF proxy
- [ ] 📖 **Deliverable:** Low-latency real-time synthesizer + WASM spike report
- [ ] 🚦 **G1 Walking Skeleton (Month 8):** from a clean clone one command starts everything; the UI loads with isolation on; a trivial C++ WASM kernel plays audio in the worklet; the BFF proxies `/analyze` to the stub; CI is green.

#### Phase 5: DSP Fundamentals: Months 9–10 (`05-dsp/`)
*Capstone component: reference "oracles" the C++ engine must later match. Exit: FFT matches NumPy, biquad response matches SciPy `freqz`, impulse and frequency-response tests pass.*

- [ ] 📖 Sampling, aliasing, quantization, dither, SNR **[continuous vs discrete-time signals]**
- [ ] 📖 Complex numbers, Euler's formula, phasors
- [ ] 🔀 DFT as a matrix **[applies SMA2202]** → radix-2 FFT from scratch in TS; windowing and spectral leakage
- [ ] 📖 LTI systems and convolution; FIR vs IIR; biquads (RBJ cookbook), Direct Form II Transposed; poles/zeros and stability
- [ ] 📖 Levels and loudness: dB scales, RMS, peak, BS.1770 K-weighting + gating (reference implementation)
- [ ] 📖 Python oracles: NumPy/SciPy comparisons (`fft`, `freqz`); test vectors committed
- [ ] 📖 **Deliverable:** DSP reference library (TS + Python) with test vectors

#### Phase 6: MIR Features, Dataset & Baseline: Month 11 (`06-mir/`)
*Capstone component: research foundation. Exit: baseline reproducible from a clean clone; results with bootstrap CIs.*

- [ ] 🔀 STFT, mel filterbank, MFCC, chroma, spectral centroid/flatness/roll-off **[DSP from Phase 5 + Librosa]**
- [ ] 📖 Dataset pipeline: license check, **artist-disjoint** train/val/test splits
- [ ] 🔀 Baseline: MFCC + SVM / logistic regression **[applies CCS4340]**
- [ ] 📖 Evaluation harness: macro-F1, PR-AUC, bootstrap CIs, seeded reproducible configs
- [ ] 🔀 Charter v1: RQs, dataset + license, metrics, budget, MoSCoW, ADR-001 (ML never in the audio path), ADR-002 (C++ for `dsp-core`), ADR-003 (Vite vs Next static export), ADR-004 (features computed only on the server) **[applies CCS3302]**
- [ ] 📖 **Deliverable:** Feature pipeline + baseline report
- [ ] 🚦 **G2 Charter v1 + Baseline (Month 11):** charter reviewed by a lecturer/supervisor; dataset license cleared; baseline reproducible.

#### Month 12 buffer: exams (reading only)
- [ ] 📖 Job-posting diff #1 (Spotify + DAW companies)
- [ ] 📖 C++ memory model and `std::atomic` reading (before Phase 7)

---

### 🟨 Level 4, Semester 1 (Months 13–18)

#### 🎓 University track
- [ ] 🎓 **CCS3301 Capstone Project–Part 1**: proposal, design, prototype milestones (dates per A4)
- [ ] 🎓 **CCS3440 Artificial Intelligence** *(4 credits)*: feeds AI/ML foundations
- [ ] 🎓 **IHM1301 Human Behavior and Ethics**: feeds ethics approval for the listening test and dataset consent/licensing
- [ ] 🎓 **CCS4310 Deep Learning** *(elective)*: feeds CNN training for Phase 8
- [ ] 🎓 **CCS4354 Tensors and Graphs** *(elective)*: feeds computation graphs, autodiff, tensor programming

#### Phase 7: C++ Real-Time DSP Engine → WASM: Months 13–15 (`07-cpp-wasm/`)
*Capstone component: the engine (RQ1). Exit: matches oracles within tolerance; an `operator new` hook proves zero allocations in `process()`; p99 within the 50% budget.*

- [ ] 📖 Modern C++ (17/20) for real time: RAII, value semantics, preallocated buffers, `constexpr`, no exceptions or allocation on the hot path
- [ ] 📖 `std::atomic`, memory orders, alignment, false sharing
- [ ] 📖 Toolchain: CMake, Emscripten, `-O3`, `-msimd128`, `wasm-opt`, threads/atomics flags
- [ ] 🔀 `dsp-core` API (`prepare`/`process`/`reset`), dependency-free **[applies CCS3313]**
- [ ] 📖 Implement biquad EQ, BS.1770 meter, limiter (compressor = Should); handle denormals in feedback paths
- [ ] 📖 Native tests (GoogleTest/Catch2) and the same tests against the WASM build under Node, compared to Phase 5 oracles
- [ ] 📖 Benchmark JS vs WASM vs WASM+SIMD: per-quantum time, boundary and copy cost
- [ ] 📖 **Deliverable:** WASM engine in the worklet + benchmark report

#### Phase 8: Deep Model & ML Service: Months 15–17 (`08-machine-learning/`)
*Capstone component: the tagger (RQ2). Exit: beats the baseline outside bootstrap CI on the artist-disjoint test set; p95 inference latency documented.*

- [ ] 🔀 PyTorch training loop; mel-spectrogram CNN; SpecAugment **[theory from CCS4310, CCS3440, CCS4354]**
- [ ] 🔀 Temporal ablation (CRNN/attention) **[concepts from CCS3356]** *(Should)*
- [ ] 📖 Error analysis, calibration, model card
- [ ] 📖 FastAPI service: Pydantic validation, upload size/duration limits, safe decoding of untrusted audio, private-network only
- [ ] 📖 M2M auth: API key hashed at rest, rotation
- [ ] 📖 **Deliverable:** ML tagger service + model card

#### Phase 9: BFF, OIDC & Integration: Months 16–17 (`09-integration/`)
*Capstone component: the secure spine. Timebox it; the audio/ML core is the differentiator.*

- [ ] 🔀 ASP.NET Core BFF: OIDC code + PKCE *(Should)* **[theory from CCS4352 if it lands in this semester, otherwise self-study]**
- [ ] 📖 `__Host-` session cookie (`HttpOnly; Secure; SameSite=Strict`), anti-forgery, CSP, isolation headers
- [ ] 📖 YARP reverse proxy to FastAPI; same-origin only (no CORS); rate limits
- [ ] 📖 End-to-end integration UI ↔ engine ↔ BFF ↔ ML, with structured logging
- [ ] 🚦 **G3 Feature Freeze (Month 17):** all Must items complete; evaluation harness runs end to end. After this: bug fixes, tests, docs, evaluation only.

#### Month 18 buffer: exams (reading and logistics)
- [ ] 📖 Job-posting diff #2
- [ ] 📖 Confirm internship start date and hours; adjust L4 S2 capacity (A3, A7)

---

### 🟥 Level 4, Semester 2 (Months 19–24): internship + Capstone Part 2

**No new features.** Budget ~6 h/week (A7).

#### 🎓 University track
- [ ] 🎓 **CCS4601 Industrial Training** *(mandatory internship, 6 credits, non-GPA)*
- [ ] 🎓 **CCS4301 Capstone Project–Part 2**: thesis and defense
- [ ] 🎓 **CCS4351 Functional Programming** *(elective)*: feeds pure DSP kernels and immutable message protocols (a testing/design benefit; it is *not* what makes code lock-free)
- [ ] 🎓 **CCS4352 Application Security** *(elective)*: feeds the threat model and audit

#### Phase 10: Evaluation, Hardening & Security Audit: Months 19–21 (`10-evaluation/`)
*Capstone component: the evidence. Uses the harness built in Phases 6 and 8, so this is running and fixing, not building.*

- [ ] 📖 Engine verification: loudness compliance signals, filter response, distortion tests, 30-min soak, 4× CPU throttle, Chrome/Firefox/Safari matrix
- [ ] 🔀 Final ML evaluation: ablations, bootstrap CIs **[CCS4340/CCS4310 concepts]**
- [ ] 🔀 Blind A/B listening test with ethics approval *(Should)* **[IHM1301, CCS3302]**
- [ ] 🔀 Security audit: STRIDE, XSS/CSRF/session/cookie review, upload abuse, dependency audits (`npm audit`, `pip-audit`, `dotnet list package --vulnerable`), ZAP **[CCS4352]**
- [ ] 📖 **Deliverable:** Evaluation Report + Security Report
- [ ] 🚦 **G4 Audit Closed (Month 21):** no unresolved High findings; results locked; thesis draft complete.

#### Phase 11: Thesis, Defense & Applications: Months 21–24 (`11-defense/`)

- [ ] 🔀 Thesis and architecture documentation: consolidated ADRs, C4 diagrams, derivations (biquad, K-weighting) **[CCS4301, CCS3300]**
- [ ] 📖 Reproducibility package (`make reproduce`), deployed instance, demo video
- [ ] 📖 Defense rehearsal: whiteboard the ring buffer, a biquad derivation, the cookie/BFF threat model, the artist-disjoint split rationale
- [ ] 📖 Applications: portfolio site, one-page CV, targeted applications
- [ ] 📖 **Deliverable:** Final production release & capstone defense (Month 24)

---

## 🔁 10. Parallel Lanes, Gates & Risk

### Lane A: C++ & Coding Practice (from Month 3)
- [ ] 📖 Modern C++ fundamentals (value semantics, RAII, templates, STL): target Month 9; refresher only if Levels 1–2 covered it (A8)
- [ ] 📖 Implement by hand in C++: dynamic array, hash map, heap, ring buffer: target Month 10
- [ ] 📖 Interview-style DSA practice, 2–3 problems/week *(optional; first thing to drop when behind)*

### Lane B: Python (from Month 6)
- [ ] 📖 NumPy/SciPy fundamentals: Months 6–8
- [ ] 📖 Librosa + scikit-learn: Months 10–11
- [ ] 📖 PyTorch practice: before Phase 8 (Months 13–14)

### Lane C: Career (capstone-derived only)
- [ ] 🔀 Write-up 1 (Month 8): "AudioWorklet + SharedArrayBuffer ring buffers: what actually breaks". Doubles as a thesis chapter seed.
- [ ] 🔀 Write-up 2 (Month 15): C++/WASM benchmark results
- [ ] 🔀 Write-up 3 (Month 20): BS.1770 from scratch, or evaluation results
- [ ] 📖 Internship placement: learn the process (Month 9); CV/portfolio ready (Month 14); apply/confirm (Months 14–17)
- [ ] 📖 Applications to target companies (Months 20–24). Eligibility and location rules vary by role; check each posting.
