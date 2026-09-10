# Music & Audio Engineering — 2-Year Roadmap

**Timeline:** September 2026 → September 2028  
**Career target:** Music / Audio Software Engineer  
**Current stage:** HTML fundamentals; completing 2nd-year university finals and preparing for 3rd year.

## Mission

Build one evolving web-based music/audio application with Web Audio, DSP, Music Information Retrieval (MIR), and selected AI/ML capabilities while developing the engineering ability to understand, debug, profile, and extend the system without depending on AI.

> **Learn → Implement → Test → Profile → Document → Revisit Deeply**

## Learning Sequence

```text
HTML
 ↓
CSS
 ↓
JavaScript + DOM + Browser APIs
 ↓
Web Audio API
 ↓
Canvas + Audio Visualization
 ↓
DSP + Mathematics
 ↓
AudioWorklet + Real-Time Audio
 ↓
TypeScript
 ↓
React / Next.js
 ↓
Music Information Retrieval
 ↓
Python + ML
 ↓
C++ / JUCE
 ↓
Optional WebAssembly
 ↓
University Final Audio + AI Project
```

# Complete Roadmap

## Year 1 — Web + Audio Engineering

### Months 1–2 — Web Foundations

**HTML:** semantic HTML, document structure, `html/head/body`, metadata, `title`, `meta`, `link`, scripts, headings, paragraphs, lists, links, images, `figure/figcaption`, forms, labels, inputs, buttons, selects, textareas, validation, `<audio>`, `<video>`, `<source>`, file input, `data-*`, accessibility, ARIA, keyboard/focus, DOM structure, attributes vs properties, resource loading.

**CSS:** selectors, cascade, specificity, inheritance, box model, display, positioning, Flexbox, Grid, responsive design, media queries, units, variables, transitions, transforms, animations, typography, accessibility.

**JavaScript:** variables/types, operators, conditionals, loops, functions, scope, closures, arrays, objects, destructuring, spread/rest, modules, classes, errors, Promises, async/await, events, DOM, browser APIs, JSON, Fetch, local storage basics, debugging.

**Programming:** abstraction, decomposition, state, control flow, functions, modularity, data transformation, encapsulation, immutability basics, debugging, error handling.

**Project — Audio Laboratory v0.1:** load audio, play/pause, seek, volume, playback speed, track information, using vanilla HTML/CSS/JS.

### Months 3–4 — Web Audio API

Learn `AudioContext`, `AudioNode`, `AudioParam`, source/destination nodes, `GainNode`, `StereoPannerNode`, `BiquadFilterNode`, `DelayNode`, `AnalyserNode`, `OscillatorNode`, `AudioBufferSourceNode`, connections, graph architecture, lifecycle and cleanup.

Programming: composition, interfaces, dependencies, event-driven programming, state machines, resource ownership/lifecycle.

**Project:**
```text
Source → Gain → Filter → Pan → Analyser → Destination
```

### Months 5–6 — Visualization + Performance

Canvas 2D, drawing, coordinates, animation loops, `requestAnimationFrame`, waveform, amplitude, RMS, peak, frequency spectrum, FFT concept, frequency bins, sample rate, typed arrays, buffers, producer/consumer thinking, time complexity, memory allocation.

**Project:**
```text
Audio → AnalyserNode → TypedArray → Canvas
```

Build waveform, spectrum, RMS and peak visualizers.

### Months 7–8 — DSP Fundamentals

**Math:** algebra, trigonometry, logarithms, complex numbers, vectors, basic calculus, discrete mathematics, sampling, Nyquist-Shannon theorem, aliasing, quantization, time/frequency domains, convolution.

**DSP:** oscillators, FIR, IIR, biquads, low/high/band-pass, notch, delay, gain, distortion, envelope, compression basics.

**Numerical programming:** floating-point behavior, precision, typed arrays, numerical stability, complexity, modular DSP.

**Project:** interactive DSP chain with filter, gain, delay and distortion.

### Months 9–10 — AudioWorklet + Real-Time Audio

AudioWorklet, AudioWorkletNode, AudioWorkletProcessor, worklet global scope, render quantum, MessagePort, parameter automation, main-thread/worklet communication, real-time constraints.

Study allocation avoidance, blocking, synchronization, messaging overhead, garbage generation, buffer handling and latency.

```text
Main Thread → AudioWorkletNode → AudioWorkletProcessor → DSP
```

### Months 11–12 — TypeScript + React

**TypeScript:** primitive types, interfaces, type aliases, unions, narrowing, generics, utility types, modules, strict mode, type-safe APIs.

**React:** components, props, state, hooks, effects, refs, context, composition, controlled components, rendering behavior, memoization and performance.

Architecture:
```text
UI → Application State → Audio Engine → Web Audio → AudioWorklet
```

Keep DSP out of React components.

**Project:** Audio Studio v1.0.

# Year 2 — Music Intelligence + Native Audio + Final Project

### Months 13–14 — Music Information Retrieval

STFT, windowing, FFT, spectrograms, Mel scale, MFCC, spectral centroid, rolloff, flux, zero-crossing rate, chroma, autocorrelation, pitch detection, onset detection, beat tracking and tempo estimation.

```text
Audio → STFT → Feature Extraction → Music Features
```

### Months 15–16 — Python + ML

**Python:** Python fundamentals, NumPy, SciPy, pandas, matplotlib, scientific computing, notebooks.

**ML:** datasets, preprocessing, features, labels, train/validation/test, loss, optimization, overfitting, regularization, metrics.

**Deep learning:** tensors, neural networks, activations, backpropagation, CNNs, embeddings, basic attention.

Choose **one** main audio-ML problem: classification, instrument recognition, similarity, mood or genre classification.

```text
Audio → Spectrogram → Feature Representation → Model → Prediction
```

### Months 17–18 — C++ + Native Audio

C++ memory, pointers, references, RAII, classes, templates, STL, vectors, smart pointers, move semantics, const correctness, compilation, linking, debugging and profiling.

Audio buffers, sample processing, real-time constraints, threading basics, lock avoidance and parameter handling. Then investigate JUCE.

Implement one meaningful DSP component in C++; do not rewrite the whole web application.

### Months 19–20 — WebAssembly Research

WASM is optional and evidence-driven.

```text
C++ → WebAssembly → AudioWorklet → Web Audio
```

Benchmark JS vs C++ vs WASM for execution time, memory, latency, throughput, complexity and bundle size. A result showing WASM is unnecessary is a valid engineering conclusion.

### Months 21–22 — University Final Project

**Requirements:** problem statement, objectives, stakeholders, functional/non-functional requirements, constraints, assumptions, use cases and success criteria.

**Research:** existing audio applications, MIR methods, ML models, browser limitations, performance constraints and academic literature.

**Design:** system architecture, component diagram, data flow, audio graph, ML pipeline, database/API design if required, deployment architecture.

Build incrementally.

### Months 23–24 — Finalization

Engineering: testing, profiling, security, accessibility, error handling, documentation, deployment, monitoring.

Academic: experiments, evaluation, results, limitations, future work, report, presentation and demonstration.

# DSA Track

Run DSA in parallel.

**Year 1:** Big-O, arrays, strings, linked lists, stacks, queues, hash tables, recursion, sorting, binary search, trees, heaps.

**Year 2:** graphs, BFS, DFS, shortest paths, dynamic programming, greedy algorithms, advanced trees, priority queues, optimization.

Audio applications:
```text
Priority Queue → audio event scheduling
Ring Buffer → streaming audio
Graph → audio routing
Hash Map → preset/parameter lookup
Heap → scheduling
```

# Performance Engineering

Progressively learn memory allocation, garbage collection, typed arrays, event loop, microtasks, `requestAnimationFrame`, debouncing, throttling, memoization, workers, transferable objects, shared-memory concepts, profiling, CPU/memory snapshots, network profiling, frame-rate monitoring, audio latency, buffer underruns, cache behavior and concurrency.

Rule:
```text
Measure → Find bottleneck → Understand cause → Optimize → Measure again
```

# Testing

Start with manual/browser testing, then unit tests, integration tests, audio-processing tests, regression tests, performance benchmarks, memory/long-running tests, cross-browser testing and ML evaluation.

# SDLC

Every major feature follows:
```text
Requirements
 ↓
Research / Feasibility
 ↓
Architecture & Design
 ↓
Implementation
 ↓
Testing
 ↓
Deployment
 ↓
Monitoring
 ↓
Evaluation
 ↓
Iteration
```

# AI-Assisted Engineering Policy

AI is an accelerator, not a substitute for engineering.

**Good uses:** API explanations, test cases, edge cases, architecture review, bug investigation, compiler errors, comparisons, boilerplate, documentation summaries and performance investigation.

**Do not outsource:** architecture you cannot explain, DSP you do not understand, algorithms you cannot implement, academic reasoning, experiments/conclusions, or debugging you have not attempted.

For important concepts:
```text
Learn → Implement Yourself → Break It → Debug Yourself → Read Docs → Ask AI → Verify
```

# Technology Stack

```text
Web: HTML, CSS, JavaScript, TypeScript, React, Next.js
Audio: Web Audio API, AudioWorklet, DSP
AI: Python, NumPy, SciPy, pandas, PyTorch, MIR
Native: C++, JUCE
Optional: WebAssembly
Engineering: DSA, algorithms, mathematics, testing, architecture, performance, Git, Linux, networking, security
```

# Repository Structure

```text
music-audio-engineering/
├── README.md
├── 01-web-foundations/
├── 02-web-audio/
├── 03-visualization/
├── 04-dsp/
├── 05-audioworklet/
├── 06-typescript-react/
├── 07-mir/
├── 08-machine-learning/
├── 09-cpp-audio/
├── 10-wasm/
└── 11-final-project/
```

# Progress Checklist

For every important concept:
```text
[ ] Understand theory
[ ] Explain without notes
[ ] Implement a basic example
[ ] Debug a broken example
[ ] Use it in the project
[ ] Test it
[ ] Profile it when relevant
[ ] Document it
```

# Career Target

The long-term target is **Music / Audio Software Engineer**, with depth across Web Audio, DSP, C++, TypeScript, ML/MIR, algorithms and software engineering. The objective is to become capable of taking an unfamiliar audio problem, researching it, designing a solution, implementing it, testing it, profiling it, explaining it and improving it independently.

> **Build the web interface. Understand the audio engine. Understand the mathematics. Understand the algorithms. Understand the AI. Remain capable of solving the problem without AI.**
