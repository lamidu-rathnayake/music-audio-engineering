# 🎵 Music & Audio Engineering Handbook (2026–2028)

Welcome to my personal handbook and repository for my 2-year self-learning journey in **Music and Audio Software Engineering**. This workspace will serve as my learning lab, reference manual, and incubator for my **University Capstone/Final Project** (a Web-Based Audio + AI/ML Application).

Targeting top-tier creative technology and audio companies (like Spotify, Ableton, and more), this handbook tracks my transition from frontend foundations to real-time Digital Signal Processing (DSP), Music Information Retrieval (MIR), and Machine Learning (ML).

---

## 📊 Learning Timeline & Progress Tracker

Track my active progress and completed milestones below. Each phase corresponds to a folder in this workspace.

> **Current Phase:** 🟩 Phase 1: Web Foundations (Months 1–2)  
> **Progress:** [░░░░░░░░░░░░░░░░░░░░] 0% Complete

### Year 3: Foundations & Web Audio

- [ ] **Phase 1: Web Foundations** (Months 1–2) — `01-web-foundations/`
    - [ ] HTML Semantic Elements, Forms & Accessibility Landmarks
        - [x] Document Structure & Metadata (`<!DOCTYPE>`, `<html>`, `<head>`, `<body>`, `<meta>`, viewport, favicon)
        - [X] Semantic HTML Markup (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<aside>`, `<footer>`, headings, lists, `<figure>`)
        - [ ] HTML5 Media Elements (`<audio>`, `<video>`, `<source>`, `<track>`, preloading, `data-*` attributes)
        - [ ] Advanced Form Controls & Validation (`<form>`, `<label>`, `<input>` types, `<select>`, `<textarea>`, autocomplete, browser validation)
        - [ ] Web Accessibility (A11y) & Landmarks (`aria-*`, keyboard focus navigation, screen reader landmarks, accessible names)
    - [ ] CSS Box Model, Flexbox/Grid, Custom Properties & Animations
    - [ ] JS Scope, Closures, Event Loop, Promises & Async/Await
    - [ ] **Deliverable:** Audio Laboratory v0.1 _(Simple vanilla audio player)_
- [ ] **Phase 2: Web Audio API** (Months 3–4) — `02-web-audio/`
    - [ ] AudioContext, base nodes (`GainNode`, `BiquadFilterNode`, etc.)
    - [ ] Core audio graph architecture & precise scheduling
    - [ ] **Deliverable:** Interactive Multi-Node Synthesizer/Web Effects Rack
- [ ] **Phase 3: Visualization & Performance** (Months 5–6) — `03-visualization/`
    - [ ] Canvas 2D API for real-time visualization
    - [ ] AnalyserNode, FFT bins, waveforms, and spectrums
    - [ ] **Deliverable:** Audio Waveform & Frequency Spectrograph Analyzer
- [ ] **Phase 4: DSP Fundamentals** (Months 7–8) — `04-dsp/`
    - [ ] Sampling Theorem (Nyquist-Shannon), aliasing, and complex numbers
    - [ ] Convolution, impulse response, and IIR/FIR filter design
    - [ ] **Deliverable:** Custom DSP Filtering Engine
- [ ] **Phase 5: AudioWorklet & Real-Time Audio** (Months 9–10) — `05-audioworklet/`
    - [ ] Multi-threaded audio rendering with AudioWorkletProcessor
    - [ ] MessagePort data passing (main thread ↔ audio thread)
    - [ ] **Deliverable:** Low-Latency Real-Time Synthesizer (Zero main-thread blocking)
- [ ] **Phase 6: TypeScript & React** (Months 11–12) — `06-typescript-react/`
    - [ ] Component architecture, React state vs. Audio processing state
    - [ ] TypeScript strict mode, generics, type-safe audio parameters
    - [ ] **Deliverable:** Audio Studio v1.0 (Completed Year 3 Milestone)

### Year 4: Specialization & University Capstone

- [ ] **Phase 7: Music Information Retrieval (MIR)** (Months 13–14) — `07-mir/`
    - [ ] STFT spectrograms, MFCC feature extraction, zero-crossing rate
    - [ ] Pitch detection, beat tracking, and tempo estimation
    - [ ] **Deliverable:** Feature Extraction Pipeline (Audio Analyzer)
- [ ] **Phase 8: Python & Machine Learning** (Months 15–16) — `08-machine-learning/`
    - [ ] PyTorch basics, deep learning for audio, spectrographic neural networks
    - [ ] Training/Evaluation of an audio classifier (genre/instrument recognition)
    - [ ] **Deliverable:** Trained ML Audio Classifier
- [ ] **Phase 9: C++ & Native Audio** (Months 17–18) — `09-cpp-audio/`
    - [ ] Modern C++, stack vs. heap, RAII, real-time-safe coding disciplines
    - [ ] JUCE Framework for desktop/native audio plugins
    - [ ] **Deliverable:** Native DSP audio effect plugin (VST3/AU)
- [ ] **Phase 10: WebAssembly Research** (Months 19–20) — `10-wasm/`
    - [ ] C++/Rust compilation to WebAssembly (WASM)
    - [ ] SharedArrayBuffer and lock-free ring buffers in WASM
    - [ ] **Deliverable:** High-Performance WASM-Based Web Audio Worklet
- [ ] **Phase 11: University Final Project** (Months 21–24) — `11-final-project/`
    - [ ] Comprehensive research, design, implementation, and dissertation
    - [ ] **Deliverable:** Final Capstone Project (Web Audio + AI/ML App)

---

## 📂 Repository Structure

The workspace is organized logically into chapters corresponding to the learning phases:

```text
music-audio-engineering/
├── README.md                  # This handbook guide & progress tracker
├── 01-web-foundations/        # HTML, CSS, & Vanilla JS experiments
├── 02-web-audio/              # Web Audio API graphs & scheduling
├── 03-visualization/          # Canvas 2D & GPU-accelerated visualizations
├── 04-dsp/                    # Mathematics & Digital Signal Processing algorithms
├── 05-audioworklet/           # Real-time multi-threaded audio processing
├── 06-typescript-react/       # State architecture & type-safe audio apps
├── 07-mir/                    # Feature extraction & Music Info Retrieval
├── 08-machine-learning/       # PyTorch, models, & client-side inference
├── 09-cpp-audio/              # Low-level systems, C++, and JUCE plugins
├── 10-wasm/                   # WebAssembly compilation & optimization
├── 11-final-project/          # University capstone project directory
├── books/                     # Electronic textbooks and slides library
└── roadmaps/                  # Detailed, comprehensive reference roadmaps
```

---

## 🛠️ Technology Stack

- **Frontend/Web:** HTML5, CSS3, JavaScript (ES6+), TypeScript, React, Next.js
- **Audio Engine:** Web Audio API, Canvas (Visuals), AudioWorklets
- **DSP & Systems:** C++, CMake, JUCE, WebAssembly (WASM)
- **AI & Machine Learning:** Python, NumPy, SciPy, PyTorch, Librosa
- **Engineering Tools:** Git, Docker, Chrome DevTools (Performance/Memory profiling)

---

## 🧠 Core Philosophy & Learning Policy

> "AI is an accelerator, not a substitute for understanding."

For every core concept, I follow this loop:

1. **Learn:** Study the underlying mathematics/theory.
2. **Implement:** Write the implementation yourself from scratch (No AI generation).
3. **Break & Debug:** Intentionally break the code and debug it using browser tools/debuggers.
4. **Test & Profile:** Benchmark performance, ensuring no memory allocations on the audio thread.
5. **Verify with AI:** Review with an AI coding assistant to find edge cases, refine performance, and write exhaustive tests.

_For detailed learning sheets, weekly study schedules, and exhaustive topic lists, refer to the [Full 2-Year Roadmap](./roadmaps/music_audio_ai_two_year_roadmap.md) and the [Advanced Checklist](./roadmaps/2year-roadmap.md)._
