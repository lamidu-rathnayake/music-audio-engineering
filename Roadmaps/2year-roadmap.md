# Advanced Frontend Engineer + Music Technology Engineer — 2-Year Checklist

Check items off as you learn them. Ordered by category, not by month — pace using the earlier Year 3/Year 4 mapping. Items marked **(2026+)** reflect current tooling; items marked **(30-yr bet)** are the durable, harder-to-automate skills worth over-investing in.

---

## 0. AI-Native Engineering Workflow (do this from day one, it compounds)
- [ ] Working fluency with an AI coding agent (Claude Code, Copilot, Cursor) as a daily tool, not a novelty
- [ ] Writing project/skill config files (e.g. `CLAUDE.md`, agent skill files) that encode your conventions so AI output matches your codebase **(2026+)**
- [ ] Prompt/agent orchestration for code — directing multiple agents on parallel tasks
- [ ] Review judgment: reading AI-generated code critically, catching subtle architectural mismatches **(30-yr bet)**
- [ ] Knowing what NOT to hand to an agent: real-time audio code, anything with hard timing constraints **(30-yr bet)**

---

## 1. Web Foundation (learned through the company project, not separate study)
- [ ] HTML semantics, forms, accessibility landmarks
- [ ] CSS: box model, Flexbox, Grid, responsive/media queries, custom properties
- [ ] JavaScript: closures, scope, `this`, prototypes, the event loop
- [ ] JavaScript async: promises, async/await, microtask vs. task queue
- [ ] TypeScript: interfaces vs. types, generics, discriminated unions, narrowing, strict mode
- [ ] React: hooks (`useState`, `useEffect`, `useRef`, `useMemo`, `useCallback`, `useContext`)
- [ ] React: rendering model, why re-renders happen, custom hooks
- [ ] Next.js: App Router, layouts, Server vs. Client Components, data fetching/caching

---

## 2. Advanced Frontend Engineering **(30-yr bet — this is where human judgment stays valuable)**
- [ ] Rendering performance: avoiding unnecessary re-renders at scale, memoization strategy
- [ ] Bundle size, code-splitting, lazy loading
- [ ] Core Web Vitals and how to measure/fix them
- [ ] SSR vs. CSR vs. static generation vs. streaming — when each is right
- [ ] State architecture: local vs. context vs. external store, avoiding state sprawl
- [ ] Canvas API — direct pixel/frame control **(needed for audio visualizers)**
- [ ] WebGL basics (or a wrapper like Three.js/PixiJS) for GPU-accelerated visuals
- [ ] Design systems and composable component architecture
- [ ] Testing: unit (Vitest), integration, visual regression, e2e (Playwright)
- [ ] Accessibility depth: keyboard nav, ARIA, screen reader behavior
- [ ] Build tooling literacy: what Vite/webpack/Next's bundler actually does under the hood

---

## 3. Math & DSP Theory (non-negotiable foundation)
- [ ] Continuous vs. discrete signals
- [ ] Sampling theorem (Nyquist–Shannon), quantization, aliasing
- [ ] Complex numbers, phasors, Euler's formula
- [ ] Fourier series → Fourier Transform → DFT
- [ ] FFT algorithm (understand it, not just call it)
- [ ] Short-Time Fourier Transform (STFT), spectrograms
- [ ] Windowing functions (Hann, Hamming, Blackman), spectral leakage
- [ ] Convolution, impulse response
- [ ] FIR vs. IIR filters, biquad filters
- [ ] Frequency response (magnitude/phase), filter types (LP/HP/BP/notch)
- [ ] Z-transform basics
- [ ] dB scale, loudness, envelopes (ADSR), compression/limiting basics
- [ ] PCM, sample rate, bit depth, WAV format internals

## 4. Music Theory (enough to build real tools)
- [ ] Pitch/frequency relationship, equal temperament
- [ ] Intervals, scales, chords (basic vocabulary)
- [ ] Rhythm, tempo, BPM
- [ ] MIDI: note numbers, velocity, message structure, Web MIDI API

---

## 5. Web Audio Engineering (your primary delivery platform)
- [ ] `AudioContext` lifecycle (suspended state, `resume()` after user interaction)
- [ ] Audio graph model, source nodes (`OscillatorNode`, `AudioBufferSourceNode`)
- [ ] Processing nodes (`GainNode`, `BiquadFilterNode`, `ConvolverNode`, `DynamicsCompressorNode`)
- [ ] `AnalyserNode` for FFT-based visualization
- [ ] Precise scheduling with `currentTime`, `OfflineAudioContext` for rendering
- [ ] `AudioWorkletProcessor`/`AudioWorkletNode` — the real-time processing layer **(2026+: Baseline widely available, this is the standard now)**
- [ ] Real-time constraints inside `process()` — must complete well under the ~128-sample deadline, every time, not most of the time
- [ ] Message passing between audio thread and main thread (`postMessage`, or a lock-free ring buffer for high-frequency data)
- [ ] `AudioParam` automation
- [ ] Web MIDI API, `getUserMedia`/`MediaStream` for mic input
- [ ] Awareness of existing libraries in this space (Tone.js for higher-level work, Superpowered SDK for optimized low-latency processing) **(2026+)**

---

## 6. WASM + Systems Layer (native-speed DSP in the browser — your bridge to desktop) **(30-yr bet)**
- [ ] WebAssembly fundamentals: linear memory model, what and why to compile to WASM
- [ ] **Decide: Rust or C++ for your DSP core** (recommendation: Rust — active audio ecosystem, memory safety without GC pauses)
- [ ] If Rust: ownership/borrowing basics, `wasm-bindgen`/`wasm-pack`
- [ ] Rust audio crates to know: `fundsp` (DSP graph library), `cpal` (device I/O, has WASM support), `symphonia` (format decoding), `rubato` (resampling) **(2026+, active ecosystem)**
- [ ] If C++: Emscripten toolchain
- [ ] Real-time-safe coding discipline: no heap allocation, no locking, inside the audio callback
- [ ] `SharedArrayBuffer` for efficient buffer passing between WASM and AudioWorklet
- [ ] Lock-free single-producer/single-consumer ring buffers (the standard pattern for audio-thread-to-worker communication)
- [ ] Profiling and optimizing WASM audio code

---

## 7. Systems Design & Software Engineering, applied to audio **(30-yr bet)**
- [ ] Real-time system constraints: deadlines, buffer underruns/xruns
- [ ] Producer–consumer patterns for audio-thread/UI-thread separation
- [ ] Plugin/effect-chain architecture (node graphs, signal routing)
- [ ] Testing DSP code: unit tests for algorithms, golden-file/reference comparisons
- [ ] Performance profiling: Chrome DevTools performance tab, Web Audio-specific tooling

---

## 8. Audio ML / AI (weight toward Year 4, once the DSP core works)
- [ ] Feature extraction: MFCCs, spectral centroid, chroma features, zero-crossing rate
- [ ] Applied ML: classification (genre/instrument/mood), clustering
- [ ] Client-side inference: TensorFlow.js or ONNX Runtime Web **(2026+)**
- [ ] MIR basics: pitch detection (autocorrelation, YIN), onset/beat detection
- [ ] Optional stretch: CNNs on spectrogram images, sequence models at a conceptual level

---

## 9. Research & Evaluation (final project write-up)
- [ ] Experimental design for evaluating an audio system
- [ ] Objective metrics vs. user studies — picking the right fit
- [ ] Literature review practice specific to Web Audio / MIR
- [ ] Writing a methodology section that holds up under examination

---

## Explicitly deferred (not this 2 years — later career stages)
- Native plugin formats (VST3/AU/CLAP) and JUCE desktop plugin development — **note: a community-driven JUCE-to-WASM port exists (not an official JUCE target yet), built on Emscripten's Audio Worklet support; real projects like webOBXD use it**, so the gap between web and native JUCE work is narrowing but still has rough edges — revisit once your web engine is solid
- Training large audio ML models from scratch
- Chasing every new browser API — the list above covers what a real audio tool needs

---

## Company project (next 2 months) — separate track, ships first
- [ ] Requirements locked in week 1
- [ ] Architecture decisions documented briefly as you go (one-line ADRs)
- [ ] No new libraries/frameworks unless something is actually broken without them
- [ ] Last 1-2 weeks reserved for testing/hardening/deployment, no new features
