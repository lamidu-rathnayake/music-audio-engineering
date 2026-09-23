# 🎵 Music & Audio Engineering

> A 24-month journey into **Web Audio, DSP, real-time audio, C++/WASM, and Audio ML**.

**Timeline:** September 2026 → September 2028  
**Stack:** TypeScript · Python · C++

## 🎯 Goal

Build a research-driven **Web Audio + AI/ML capstone** while developing strong foundations in audio software engineering.

The project focuses on:

- 🌐 **Frontend:** TypeScript + React
- 🐍 **Backend:** Python + FastAPI
- 🤖 **ML:** Python + PyTorch + Librosa
- 🎛️ **DSP:** C++ + JUCE (native prototype) + WebAssembly (browser)
- 🎧 Web Audio API + AudioWorklet
- 🧠 ONNX + WebGPU edge inference in the browser
- ⚡ Real-time systems and performance
- 🔐 Backend security and evaluation

**Target:** building toward roles at companies like Spotify and other DAW / digital-audio-software teams.

## 🏗️ Capstone — Web-Native Audio Production Environment

*(previously "Audio Studio")*

A browser-based, loudness-aware audio processing and analysis application.

```text
React / TypeScript
        ↓
Web Audio API
        ↓
AudioWorklet
        ↓
C++ DSP Engine
        ↓
WebAssembly
```

The Python backend serves the React application and communicates with a separate Python ML service:

```text
Python + FastAPI Backend
      ├── wwwroot/  → React static build
      └── API       → Application backend
             ↓
      Python + FastAPI ML Service
             └── PyTorch + Librosa → ONNX export
                     ↓
             Browser: ONNX Runtime Web + WebGPU (edge inference)
```

## 🗺️ 24-Month Journey

| Period | Focus |
|---|---|
| **Prerequisites** | HTML, CSS, JavaScript, browser-based programming, Python & FastAPI foundations |
| **Year 3 – Semester 1** (Months 1–6) | Frontend Architecture & Audio Graph Management |
| **Year 3 – Semester 2** (Months 7–12) | Mathematical DSP & Machine Learning Foundations |
| **Year 4 – Semester 1** (Months 13–18) | Deep Learning & Native C++/JUCE Plugins — Capstone Part 1 |
| **Year 4 – Semester 2** (Months 19–24) | WebAssembly, WAMs & Edge Integration — Capstone Part 2 |

📖 **Detailed roadmap:** [`ROADMAP-2.md`](./ROADMAP-2.md)  
🧱 **Prerequisites:** [`ROADMAP-PREREQUISITES.md`](./ROADMAP-PREREQUISITES.md)

## 📁 Repository

```text
docs/        → Research, ADRs, logs & thesis
labs/        → Learning experiments
capstone/    → Main application
benchmarks/  → Performance experiments
books/       → Study references
roadmaps/    → Planning material
```

## 🚦 Milestones

**M0** — Prerequisites Complete · **M1** — Semester 1 Milestone (Y3S1) · **M2** — Semester 2 Milestone (Y3S2) · **M3** — Capstone Part 1 Milestone (Y4S1) · **M4** — Final Capstone Milestone (Y4S2) · **🎓 Final** — Thesis & Defense

## 📊 Current Progress

**Month:** 0 / 24  
**Stage:** Prerequisites  
**Progress:** not yet started — see `ROADMAP-PREREQUISITES.md`  
**Next Milestone:** M0 — Prerequisites Complete

> **Build it. Measure it. Understand it. Defend it.**
