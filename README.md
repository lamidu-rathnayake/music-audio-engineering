# 🎵 Music & Audio Engineering Handbook (2026–2028)

Welcome to my personal handbook and repository for my 2-year self-learning journey in **Music and Audio Software Engineering**. This workspace serves as my learning lab, reference manual, and incubator for my **University Capstone Project** (Web Audio + AI/ML Application).

Targeting top-tier creative technology companies like [Spotify](https://www.spotify.com/) and [Ableton](https://www.ableton.com/), this handbook tracks my progression through frontend foundations, real-time Digital Signal Processing (DSP), Music Information Retrieval (MIR), Machine Learning (ML), and enterprise-grade system security.

---

## 📊 2-Year Roadmap & Progress Tracker

> **Current Phase:** 🟩 Phase 1: Web Foundations & Secure Delivery (Months 1–2)  
> **Progress:** [░░░░░░░░░░░░░░░░░░░░] 0% Complete

### Year 3: Foundations, Web Audio & Academic Core (Level 3)
*Academic Alignment:* Natural Language Processing (CCS3356), Machine Learning (CCS4340), Linear Algebra (SMA2202).

- [ ] **Phase 1: Web Foundations & Secure Delivery** (`01-web-foundations/`)
    - [x] Document Structure & Metadata (`<!DOCTYPE>`, `<html>`, viewport).
    - [x] Semantic HTML Markup (`<header>`, `<main>`, `<section>`, `<footer>`).
    - [ ] HTML5 Media Elements (`<audio>`, `<source>`, `preload`, `data-*`).
    - [ ] Form Controls, State Limits (`readonly`, `min`, `max`), and Web Accessibility (A11y).
    - [ ] CSS Box Model, Flexbox/Grid, and Custom Properties.
    - [x] **Secure Architecture:** Same-Origin setup via ASP.NET Core `wwwroot`, CORS elimination, `__Host-` cookies, `SameSite=Strict`.
    - [ ] **Deliverable:** Audio Laboratory v0.1 (Securely hosted vanilla audio player).
- [ ] **Phase 2: Web Audio API** (`02-web-audio/`)
    - [ ] `AudioContext` lifecycle and native node routing (`GainNode`, `BiquadFilterNode`).
    - [ ] Core audio graph architecture and precise scheduling.
    - [ ] **Deliverable:** Interactive Multi-Node Synthesizer/Web Effects Rack.
- [ ] **Phase 3: Visualization & Performance** (`03-visualization/`)
    - [ ] Canvas 2D API for 60fps real-time rendering.
    - [ ] `AnalyserNode`, FFT bins, waveforms, and spectrums.
    - [ ] **Deliverable:** Audio Waveform & Frequency Spectrograph Analyzer.
- [ ] **Phase 4: DSP Fundamentals** (`04-dsp/`)
    - [ ] Sampling Theorem, aliasing, quantization, complex numbers.
    - [ ] Convolution, impulse response, and IIR/FIR filter design.
    - [ ] **Deliverable:** Custom DSP Filtering Engine.
- [ ] **Phase 5: AudioWorklet & Real-Time Audio** (`05-audioworklet/`)
    - [ ] Multi-threaded audio rendering with `AudioWorkletProcessor`.
    - [ ] Lock-free ring buffer communication and `MessagePort` data passing.
    - [ ] **Deliverable:** Low-Latency Real-Time Synthesizer (Zero main-thread blocking).
- [ ] **Phase 6: React State Architecture & Frontend Integration (`06-typescript-react/`)
    - [ ] React Reconciliation vs. The V8 Engine: Mastering useRef, useMemo, and useEffect to manipulate DOM nodes and C++ WebAssembly modules without triggering re-renders that stall the audio thread.
    - [ ] Decoupled State Management: Architecting a strict boundary between the React Virtual DOM (which handles UI rendering) and the AudioContext (which handles the DSP graph).
    - [ ] Audio Node Binding: Safely passing user input from React components directly into AudioParam scheduling methods (linearRampToValueAtTime) without creating memory leaks.
    - [ ] Build Tooling Agnosticism: Configuring Vite or Next.js purely to bundle your TypeScript and React code into static assets for your secure ASP.NET Core wwwroot environment.
    - [ ] Secure API Consumption: Fetching presets and heavy audio buffers from your backend using strictly typed requests that automatically forward your __Host- cookies.
    - [ ] **Deliverable:** Audio Studio v1.0.

### Year 4: Specialization, Native Systems & Capstone (Level 4)
*Academic Alignment:* Deep Learning (CCS4310), Tensors & Graphs (CCS4354), Functional Programming (CCS4351), Application Security (CCS4352).

- [ ] **Phase 7: Music Information Retrieval (MIR)** (`07-mir/`)
    - [ ] STFT spectrograms, MFCC feature extraction, zero-crossing rate.
    - [ ] Pitch detection, beat tracking, and tempo estimation.
    - [ ] **Deliverable:** Feature Extraction Pipeline.
- [ ] **Phase 8: Python, Machine Learning & M2M Security** (`08-machine-learning/`)
    - [ ] Scientific computing (NumPy, SciPy, PyTorch) for spectrographic neural networks.
    - [ ] Sequence modeling and transformers (leveraging NLP foundation).
    - [ ] **M2M Security:** Machine-to-Machine authentication (API Keys/OAuth Client Credentials) for the Python ML service.
    - [ ] **Deliverable:** Securely Connected ML Audio Classifier Service.
- [ ] **Phase 9: C++ & Native Audio** (`09-cpp-audio/`)
    - [ ] Modern C++, stack vs. heap, RAII, real-time-safe coding disciplines.
    - [ ] JUCE framework for desktop/native audio plugins.
    - [ ] **Deliverable:** Native DSP audio effect plugin (VST3/AU).
- [ ] **Phase 10: WebAssembly Research & Integration** (`10-wasm/`)
    - [ ] Benchmarking JavaScript vs. C++/Rust compiled to WebAssembly (WASM).
    - [ ] SharedArrayBuffer implementations in WASM.
    - [ ] **Deliverable:** High-Performance WASM-Based Web Audio Worklet.
- [ ] **Phase 11: Capstone Architecture & Security Design** (`11-final-project/`)
    - [ ] System architecture, audio graph flow, and ML pipeline mapping.
    - [ ] **Enterprise Identity:** Backend-For-Frontend (BFF) Pattern using OAuth 2.0 / OpenID Connect (OIDC).
    - [ ] **Deliverable:** System Architecture Documentation & Core Multi-Service Build.
- [ ] **Phase 12: Hardening, Security Review & Defense** (`12-defense/`)
    - [ ] Comprehensive security audit (XSS, CSRF, CORS).
    - [ ] Audio engine latency testing, buffer underrun profiling.
    - [ ] **Deliverable:** Final Production Release & University Capstone Defense.
---

## 🏛️ University Academic Alignment

My specialized SLTC coursework directly drives the engineering required for my 2-year technical roadmap.

### Level 3 (Year 3)
*   **L3 Semester 1:** Software Architecture, SE Methods, SQA, Technology Challenge.
    *   *Specialization:* **Natural Language Processing (CCS3356)** – Foundational sequence modeling and attention mechanisms for generative audio.
*   **L3 Semester 2:** Research Methods, Advanced Software Design, Discrete Mathematics.
    *   *Specialization:* **Linear Algebra (SMA2202)** – Vector spaces and matrix operations crucial for FFTs and neural embeddings.
    *   *Specialization:* **Machine Learning (CCS4340)** – Core algorithms for MIR, feature extraction, and audio classification.

### Level 4 (Year 4)
*   **L4 Semester 1:** Capstone Project-Part 1, Artificial Intelligence, Human Behavior and Ethics.
    *   *Specialization:* **Deep Learning (CCS4310)** – Training CNNs and PyTorch models on spectrographic audio data.
    *   *Specialization:* **Tensors and Graphs (CCS4354)** – Mathematical mapping for Web Audio node routing and computational graphs.
*   **L4 Semester 2:** Capstone Project-Part 2, Industrial Training.
    *   *Specialization:* **Functional Programming (CCS4351)** – Stateless execution models critical for lock-free audio stream processing.
    *   *Specialization:* **Application Security (CCS4352)** – BFF architecture, OAuth 2.0/OIDC validation, and strict cookie hardening.

---

## 📂 Repository Structure

```text
music-audio-engineering/
├── README.md                  # Handbook guide & progress tracker
├── 01-web-foundations/        # HTML, CSS, & Vanilla JS experiments
├── 02-web-audio/              # Web Audio API graphs & scheduling
├── 03-visualization/          # Canvas 2D & GPU-accelerated visualizations
├── 04-dsp/                    # Mathematics & Digital Signal Processing algorithms
├── 05-audioworklet/           # Real-time multi-threaded audio processing
├── 06-typescript-react/       # State architecture & type-safe audio apps
├── 07-mir/                    # Feature extraction & Music Info Retrieval
├── 08-machine-learning/       # PyTorch, models, & M2M secure endpoints
├── 09-cpp-audio/              # Low-level systems, C++, and JUCE plugins
├── 10-wasm/                   # WebAssembly compilation & optimization
├── 11-final-project/          # University capstone project directory & BFF architecture
├── 12-defense/                # Security audits, performance benchmarks & dissertation
├── books/                     # Electronic textbooks and slides library
└── roadmaps/                  # Detailed reference roadmaps and checklists