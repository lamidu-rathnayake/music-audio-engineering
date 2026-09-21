# 🎵 Music & Audio Engineering Handbook (2026–2028)

My 24-month plan (Sep 2026 → Sep 2028) to build and defend a **Web Audio + AI/ML capstone**, understand the real-time engineering beneath web audio platforms, and become hireable at **Spotify** (first choice) and **digital audio software companies**. This repo holds my findings, lab sub-projects, and the capstone code.

> **Now:** Month 0 (Sep 2026), before Level 3 Semester 1
> **Progress:** `[█░░░░░░░░░░░░░░░░░░░]` 3 / 116 milestones (3%)
> **Next gate:** G1 Walking Skeleton (Month 8)

---

## 🔑 1. How to Use This File

| Tag | Meaning | Tick it when… |
|---|---|---|
| 🎓 **University** | Taught in a course. I do **not** self-study the theory. | The course has covered it and I can restate it without notes. |
| 📖 **Self-study** | Not in my curriculum. I learn it myself. | Its exit criterion is met and the result is committed. |
| 🔀 **Hybrid** | Theory from a course, application built by me. | The applied result is committed to the repo. |
| 🚦 **Gate** | Go/no-go checkpoint. | Every criterion holds. |

**Weekly ritual (Sunday, 20 min):** update checkboxes and the progress line, write `docs/log/YYYY-Www.md` (hours spent, done, blocked, one thing measured). At each phase exit, tag the repo `phase-NN-done`.

**If I fall behind:** apply the cut order in Section 10. Never silently extend a phase.

> ⚠️ 🎓 tags are **inferred from module titles**. I haven't seen the syllabi. In Weeks 1–2 of each semester, compare the outline with the 🎓 items and downgrade to 📖 whatever the course doesn't actually teach.

---

## 🎯 2. Success Criteria (Month 24)

1. A deployed, secured, browser-based audio application whose DSP core is **C++ compiled to WASM, running in an AudioWorklet**, with measured latency headroom and zero dropouts in a soak test.
2. An ML tagger that **beats a classical baseline** on a leakage-free split, with error analysis and a model card.
3. A written and defended **evaluation** (engine correctness, real-time behavior, model quality, security audit).
4. A public repo and write-ups that let me explain every layer from the audio callback to the login cookie.

---

## 🧪 3. Assumptions to Verify (Weeks 1–2)

The plan is built on these. If one is wrong, fix the plan, not the reality.

| # | Assumption | Verify with | If wrong |
|---|---|---|---|
| A1 | Semesters run roughly Oct–Mar, Apr–Sep, and each ends with an exam/assignment month | Academic calendar | Shift months; keep one buffer month per semester |
| A2 | **ML and Linear Algebra** run in L3 S2; **Deep Learning and Tensors & Graphs** in L4 S1; **Functional Programming and Application Security** in L4 S2 (the tables list these electives without fixing a semester) | Timetable / registrar | ML earlier is fine. If Deep Learning lands in L4 S2, Phase 8 loses course support and leans on self-study. If Application Security lands in L4 S1, OIDC work in Phase 9 gets theory first (better). |
| A3 | **Industrial Training** (mandatory internship, 6 credits) is heavy and runs alongside Capstone Part 2 | Department | If part-time, spend the extra hours on Should items |
| A4 | Capstone Part 1/2 have proposal, design, prototype, and defense milestones on university dates | Capstone handbook, supervisor | Move gates G2–G4 to match |
| A5 | Technology Challenge Competition has fixed rules/teams | Course outline | Never depend on it. Use it as a capstone prototype only if the topic is free. |
| A6 | NLP, ML, DL, Tensors & Graphs, Application Security teach what their titles imply | Syllabi | Downgrade 🎓 to 📖 and re-plan that item |
| A7 | Self-study capacity: ~10 h/week (L3), ~12 h/week (L4 S1, counting Capstone Part 1 hours), ~6 h/week (L4 S2) | Log actual hours for 4 weeks | Apply the cut order if under 70% of these |
| A8 | Levels 1–2 (not visible to me) may already cover C/C++ or web basics | Old transcripts | Tick those items after a short refresher |
| A9 | Internship placement is arranged by me or by the department | Department | If self-arranged, protect Months 14–17 for applications |

---

## 📜 4. Ground Rules & Conflict Design

**Ground rules**

1. **Engine-First.** Implement core mechanics by hand (FFT, biquad, loudness meter, ring buffer) as a reference before using any abstraction.
2. **Capstone Gate.** Anything that doesn't directly build a capstone component is cut or moved to Post-Defense (Section 12).
3. **Capstone technology boundary (locked).** UI: React client-side rendering via static export, no SSR. Engine and visuals: Web Audio API, AudioWorklet, C++ compiled to WASM, Canvas 2D at 60 fps. Security: ASP.NET Core BFF, `__Host-` cookies, `SameSite=Strict`, no CORS. ML: isolated FastAPI service with PyTorch and Librosa, machine-to-machine API key.
4. **Tier 3 exit.** A phase isn't done until its deliverable is Tier 3: memory preallocated, lock-free inter-thread communication, numerically stable DSP, real tests.
5. **AI-native, with a hard boundary.** Agents accelerate me; every diff is reviewed. Never delegate wholesale: audio-thread code, lock-free queues, inner DSP loops.
6. **Every assignment with a free topic choice becomes a capstone prototype.** If the topic is fixed, I do it normally and don't force it.
7. **One language per layer:** TypeScript (UI/glue), C++ (DSP core), C# (BFF), Python (ML).

**How this plan avoids conflicts with the university schedule**

- **Prerequisite order:** no self-study item needs a course concept before that course's semester (subject to A2).
- **Buffer months (6, 12, 18, 24):** exam/assignment/defense periods carry only light work.
- **One heavy track at a time.** The only overlaps (Months 15–17) are marked and covered by the cut order.
- **Courses are accelerators, not dependencies.** The plan never waits on an assignment topic or a lecturer's schedule.
- **L4 S2 has zero feature work.** All features freeze at Month 17, before the internship semester.

I can't see your timetable, so "non-conflicting" means: no structural conflicts visible from the curriculum tables. The assumptions above are where a conflict would hide.

---

## 🗓️ 5. Timeline at a Glance

| Month | Calendar (assumed) | Semester | Mode | Self-study phase |
|---|---|---|---|---|
| 0 | Sep 2026 | Before L3 S1 | Setup | **P0** Repo & workflow |
| 1 | Oct 2026 | L3 S1 | Active | **P1** Web foundations & secure delivery |
| 2–3 | Nov–Dec 2026 | L3 S1 | Active | **P2** Web Audio API |
| 4–5 | Jan–Feb 2027 | L3 S1 | Active | **P3** Visualization & React–audio integration |
| 6 | Mar 2027 | L3 S1 | **Buffer** | Charter v0, Python primer |
| 7–8 | Apr–May 2027 | L3 S2 | Active | **P4** AudioWorklet, shared memory, first WASM · 🚦 **G1 Walking skeleton** |
| 9–10 | Jun–Jul 2027 | L3 S2 | Active | **P5** DSP fundamentals |
| 11 | Aug 2027 | L3 S2 | Active | **P6** MIR features, dataset, baseline · 🚦 **G2 Charter v1 + baseline** |
| 12 | Sep 2027 | L3 S2 | **Buffer** | Reading only |
| 13–15 | Oct–Dec 2027 | L4 S1 | Active | **P7** C++ real-time DSP engine → WASM |
| 15–17 | Dec 2027–Feb 2028 | L4 S1 | Active | **P8** Deep model & ML service *(overlaps P7 in M15)* |
| 16–17 | Jan–Feb 2028 | L4 S1 | Active | **P9** BFF, OIDC & integration · 🚦 **G3 Feature freeze (M17)** |
| 18 | Mar 2028 | L4 S1 | **Buffer** | Reading, internship logistics |
| 19–21 | Apr–Jun 2028 | L4 S2 | Internship + Capstone 2 | **P10** Evaluation, hardening & audit · 🚦 **G4 Audit closed (M21)** |
| 21–24 | Jun–Sep 2028 | L4 S2 | Internship + Capstone 2 | **P11** Thesis, defense & applications |
| 24 | Sep 2028 | L4 S2 | **Defense** | 🎯 Final release & defense |

**Highest-risk stretch: Months 15–17** (five courses plus three overlapping phases). The cut order exists for this.

---

## 🧭 6. University vs Self-Study Coverage

| Area | 🎓 Covered by university | 📖 Self-study (not in the curriculum tables) |
|---|---|---|
| Architecture, process, quality, design | Software Architecture, SE Methods, SQA, Advanced Software Design | Audio-specific testing: golden files, `OfflineAudioContext`, real-time soak tests |
| Mathematics | Discrete Mathematics, Linear Algebra | Complex numbers/Euler, Fourier series, DFT/FFT, LTI systems, convolution, Z-transform, filter design, numerical stability (Numerical Analysis isn't in my plan) |
| ML / AI | Machine Learning, AI, Deep Learning, Tensors & Graphs, NLP | Audio features (STFT/mel/MFCC), MIR, dataset leakage, PyTorch practice, FastAPI serving, evaluation on audio |
| Security | Application Security | BFF, cookies, COOP/COEP, OIDC implementation, auditing my own system |
| Research and ethics | Research Methods, Human Behavior & Ethics | Perceptual audio evaluation (A/B, MUSHRA-lite), loudness standards |
| Functional programming | Functional Programming | Applying it to pure DSP kernels |
| Web (HTML/CSS/JS/TS/React) | Not in the L3–L4 tables | All of it: media, forms, layout, JS internals, strict TS, React–audio lifecycle |
| Web Audio, AudioWorklet, SharedArrayBuffer, WASM | Nothing | All of it |
| C++ and real-time systems | Nothing in the L3–L4 tables | All of it (refresher only if Levels 1–2 covered it) |

**The hardest self-study block is DSP.** No course in the tables teaches signals, Fourier analysis, or filters. Linear Algebra and Discrete Math help, but they aren't a substitute.

---

## 🏗️ 7. Capstone Reference Concept: **Audio Studio**

> A reference concept. I can replace it at **G2 (Month 11)** if the replacement still has: a measurable real-time constraint, an ML component with a baseline, and a written evaluation plan.

**A browser-native, loudness-aware mastering assistant.** Streaming platforms normalize loudness, so mastering choices (integrated loudness, true-peak headroom, dynamics, spectral balance) affect playback. Audio Studio measures them in real time on the client (C++/WASM), classifies the track with a server-side ML tagger, and recommends target settings. (Platforms use their own targets. Spotify's default is commonly cited as around −14 LUFS. Verify against current documentation before hard-coding.)

**Research questions**
- **RQ1.** Can a C++/WASM engine in an AudioWorklet run a metering + processing chain inside a fixed fraction of the render quantum, and how does it compare with plain JS and native reference results?
- **RQ2.** Does a mel-spectrogram CNN beat an MFCC + classical baseline on an artist-disjoint split, and does temporal modeling add anything?
- **RQ3 (Should).** Do tag-informed suggestions beat generic presets in a blind A/B test?

```mermaid
flowchart LR
  subgraph Browser["Browser: one origin, cross-origin isolated"]
    UI["React UI (static export)"]
    CV["Canvas 2D renderer"]
    WK["Worker: decode and IO"]
    AW["AudioWorklet: C++ WASM engine"]
    UI -- "MessagePort (control)" --> AW
    WK -- "SPSC ring buffer (SAB)" --> AW
    AW -- "SPSC ring buffer (meters)" --> CV
  end
  UI -- "HTTPS + __Host- cookie" --> BFF["ASP.NET Core BFF: OIDC, YARP"]
  BFF -- "OIDC code + PKCE" --> IDP["Identity Provider"]
  BFF -- "M2M API key, private network" --> ML["FastAPI + PyTorch + Librosa"]
```

**Design rules:** ML is never in the audio path. The client never computes model features (the server does, with Librosa), which removes train/serve skew (ADR-004). `dsp-core` has no Emscripten or JUCE dependency, so a native wrapper is possible after the defense.

**Real-time budget:** 128-frame quantum ≈ 2.9 ms at 44.1 kHz. Target: `process()` p99 under **50% of the quantum** on my reference machine (a target I chose; tune after measuring). Zero heap allocations attributable to `process()`.

**Scope tiers**
- **Must:** WASM engine (biquad EQ, BS.1770 loudness meter, limiter), spectrum/waveform on Canvas 2D, ML tagger beating baseline, hardened BFF session (`__Host-`, `SameSite=Strict`, no CORS, M2M key), evaluation report, security audit.
- **Should:** compressor, suggestion engine + A/B test (RQ3), OIDC login, temporal (CRNN/attention) ablation, Chrome/Firefox/Safari matrix.
- **Could:** extra effects, session save/load.

**Evaluation plan**

| Component | Claim | Method | Pass criterion |
|---|---|---|---|
| Loudness meter | Conforms to BS.1770 / EBU R128 | Published compliance test signals | Within the test set's tolerance (typically ±0.1 LU) |
| Filters / EQ | Response matches design | Compare with SciPy `freqz` | Max error target under 0.05 dB, 20 Hz–20 kHz |
| Real-time behavior | No dropouts | 30-min soak; repeat under 4× CPU throttling | 0 underruns at 1×; degradation documented at 4× |
| WASM vs JS | Speedup and boundary cost | Benchmark harness, per-quantum timing | Ratios with variance; no pre-committed number |
| ML tagger | Beats baseline | Artist-disjoint test split; macro-F1 and PR-AUC with bootstrap CIs | Improvement outside CI |
| Suggestions | Preferred over presets | Blind A/B, n ≥ 10, ethics approval | Win rate with CI |
| Security | No serious findings | STRIDE, manual checklist, ZAP scan | Zero unresolved High findings |

---

## 🎯 8. Career Targets

> Hiring requirements change. At Months 12 and 18, pull ~10 current postings per company and diff them against this plan.

| Skill | Where I build it | Evidence |
|---|---|---|
| Web player engineering (React/TS, performance, a11y) | P1, P3 | Perf numbers, a11y audit |
| Loudness and audio processing | P5, P7 | `dsp-core` + compliance report |
| Audio ML / MIR | P6, P8 | Model card, baselines, ablations |
| Services and security | P8–P10 | BFF + ML service, audit report |
| Real-time profiling | P4, P7, P10 | Benchmark reports |
| **Streaming (MSE, adaptive streaming), JUCE/native plugins** | *Outside the capstone boundary → Post-Defense (Section 12)* | — |

**Honest trade-off:** Spotify's core streaming skills (Media Source Extensions, adaptive streaming) aren't in the capstone boundary, so they wait until after the defense. The mandatory internship is the natural place to get backend/streaming exposure. Study their open source meanwhile: **Basic Pitch** (polyphonic pitch detection with a browser-side TypeScript port) and **Pedalboard** (Python audio-effects library backed by JUCE).

---

## 📊 9. The Checklist

### 🟧 Month 0: Setup (Sep 2026, now)

*Exit: a working repo, CI, and a log habit before classes start.*

- [ ] 📖 Create GitHub repo `music-audio-engineering` with the structure in Section 12
- [ ] 📖 Add this README; commit convention `phase-NN: message`; tag `phase-NN-done` at each phase exit
- [ ] 📖 Write `CLAUDE.md`: layer languages, capstone boundary, audio-thread rules (no allocation, no locks, no blocking)
- [ ] 📖 CI skeleton (lint + unit tests on push)
- [ ] 📖 Weekly log template `docs/log/YYYY-Www.md`
- [ ] 📖 Send the assumption questions (Section 3) to the department/registrar

---

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

### Lane D: AI-native workflow (ongoing, no checkbox)
Keep `CLAUDE.md` current. Log AI-written diffs that failed review (hallucinated APIs, hidden allocations, races) in the weekly log.

### Gates

| Gate | Month | Must be true to proceed |
|---|---|---|
| G1 Walking skeleton | 8 | One command starts all services; isolation on; WASM kernel audible; BFF → FastAPI stub works; CI green |
| G2 Charter v1 + baseline | 11 | Charter reviewed; dataset license cleared; baseline reproducible with CIs |
| G3 Feature freeze | 17 | All Must items done; evaluation harness runs end to end |
| G4 Audit closed | 21 | No unresolved High findings; results locked; thesis draft complete |

### Cut order (apply top to bottom)
1. Could items → 2. Compressor and temporal (CRNN/attention) ablation → 3. Suggestion engine, RQ3, A/B test → 4. OIDC (fall back to hardened cookie-session BFF) → 5. Safari from the browser matrix (keep Chrome + Firefox).

### Risk register

| Risk | Early signal | Mitigation |
|---|---|---|
| Months 15–17 overload | Phase 7 not done by Month 15 | Cut order; Capstone Part 1 hours go to Phase 8/9 |
| Internship compresses L4 S2 | Hours below ~6/week | Freeze at Month 17; thesis writing starts in Month 13 |
| Electives land in different semesters | Timetable disagrees with A2 | Re-map 🎓 items; move the affected phase |
| Hidden allocation/GC in the audio thread | Clicks under load; unstable `process()` time | Allocation audits, soak tests, no unreviewed AI-written audio-thread code |
| Cross-browser audio differences | Works only in Chrome | Browser check in every lab from Phase 2 |
| Dataset license/compute limits | No clean, legal, artist-labeled set | Decide at G2; keep models small; free GPU tiers |
| Course topics don't match capstone | Assignment topics fixed | Do them normally; don't force capstone fit (Rule 6) |

---

## 📚 11. Reading & Reference List

- **DSP:** Smith, *The Scientist and Engineer's Guide to DSP* (free online); J.O. Smith, *Introduction to Digital Filters* (CCRMA, free online); RBJ *Audio EQ Cookbook*.
- **Real-time audio:** Bencina, *Real-time audio programming 101: time waits for nothing*; Renn-Giles & Rowland, *Real-time 101* (ADC 2019).
- **Web Audio:** W3C Web Audio API spec; MDN; Wilson, *A Tale of Two Clocks*.
- **Loudness:** ITU-R BS.1770 and EBU R128.
- **MIR / ML:** Müller, *Fundamentals of Music Processing*; *Dive into Deep Learning* (free).
- **C++:** Stroustrup, *A Tour of C++*; Williams, *C++ Concurrency in Action*.
- **Security:** OWASP ASVS and cheat sheets; IETF draft *OAuth 2.0 for Browser-Based Applications* (the BFF pattern).

---

## 📂 12. Repository Structure & Post-Defense

```text
music-audio-engineering/
├── README.md                  # This handbook and progress tracker
├── docs/
│   ├── adr/                   # Architecture Decision Records
│   ├── charter.md             # Charter v0 → v1
│   ├── log/                   # Weekly logs
│   └── thesis/                # Drafts, derivations, figures
├── labs/                      # Phase experiments and reports
│   ├── 01-web-foundations/
│   ├── 02-web-audio/
│   ├── 03-visualization/
│   ├── 04-audioworklet/
│   ├── 05-dsp/                # Reference "oracles" (TS + Python)
│   ├── 06-mir/
│   ├── 07-cpp-wasm/
│   ├── 08-machine-learning/
│   ├── 09-integration/
│   ├── 10-evaluation/
│   └── 11-defense/
├── capstone/                  # Product code (grows from G1)
│   ├── apps/web/              # React static export
│   ├── services/bff/          # ASP.NET Core BFF
│   ├── services/ml/           # FastAPI + PyTorch + Librosa
│   └── packages/dsp-core/     # Dependency-free C++ DSP library
├── benchmarks/                # Reproducible perf harnesses and results
├── books/                     # Textbooks and slides
└── roadmaps/                  # Reference checklists
```

**Post-defense (not counted, not started before Month 24):** native bridge (wrap `dsp-core` in JUCE/CLAP, VST3/AU/CLAP plugin passing `pluginval`, tested in a DAW); Streaming Lab (Media Source Extensions player, adaptive-bitrate heuristic); MIDI/Web MIDI; open-source contributions; Rust exploration.
