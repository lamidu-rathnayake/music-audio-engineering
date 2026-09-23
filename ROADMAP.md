# Web-Native Audio Production Environment — 2-Year Learning Roadmap

> **Scope rule:** This roadmap contains only the technologies, concepts, and deliverables defined in the original 2-year plan. Do not add unrelated technologies or parallel learning tracks.

---

# Year 3 — Semester 1
## Months 1–6: Frontend Architecture & Audio Graph Management

### 1. TypeScript & React Fundamentals
- [ ] TypeScript fundamentals — a typed superset of JavaScript that catches type errors at compile time
  - [ ] Strongly typed variables and functions — declaring explicit types for values and function signatures
  - [ ] Interfaces and type definitions — describing the shape of an object or data contract
  - [ ] Typed arrays and audio-related data structures — typing collections like `Float32Array` used for audio samples
  - [ ] Type-safe component props and state — typing what a component receives and holds internally
  - [ ] Type-safe event handling — typing DOM/React event objects and handler signatures
- [ ] React fundamentals — a component-based UI library built around declarative rendering
  - [ ] Components — reusable, self-contained units that render part of the UI
  - [ ] Props — read-only data passed from a parent component to a child
  - [ ] State — data owned by a component that changes over time and triggers a re-render
  - [ ] Component lifecycle management — mounting, updating, and unmounting behavior (via hooks/effects)
  - [ ] Component composition — building complex UI by combining smaller components
  - [ ] Separating UI concerns from audio-system concerns — keeping rendering logic independent of audio-engine logic
- [ ] Multitrack timeline interface — the visual editor showing tracks and clips along a shared time axis
  - [ ] Track representation — the data model for a single audio track (name, volume, mute, etc.)
  - [ ] Timeline representation — the data model for time positions, zoom level, and playhead
  - [ ] Audio clip representation — the data model for a segment of audio placed on a track
  - [ ] Playback position representation — tracking and rendering the current play cursor
  - [ ] Basic track controls — UI for mute, solo, volume, and track selection
  - [ ] Strongly typed timeline data structures — TypeScript types/interfaces for tracks, clips, and timeline state

### 2. Web Audio API
- [ ] Web Audio API fundamentals — the browser's native system for generating and processing audio
  - [ ] Audio context — the object that manages and creates all audio nodes
  - [ ] Audio graph concept — modeling audio processing as connected nodes signal flows through
  - [ ] Audio nodes — individual units that generate, process, or output audio
  - [ ] Node connections — wiring the output of one node to the input of another
  - [ ] Audio routing — directing signal paths from sources through effects to output
- [ ] OscillatorNode — a node that generates a periodic waveform (sine, square, etc.)
  - [ ] Creating oscillators — instantiating an OscillatorNode from an AudioContext
  - [ ] Starting and stopping oscillators — controlling when a tone begins and ends
  - [ ] Frequency control — setting/automating the pitch of the generated tone
  - [ ] Connecting oscillator output — routing the oscillator into the rest of the graph
- [ ] BiquadFilterNode — a configurable filter node (low-pass, high-pass, etc.)
  - [ ] Creating filter nodes — instantiating a BiquadFilterNode
  - [ ] Filter types — lowpass, highpass, bandpass, notch, peaking, shelving filters
  - [ ] Frequency control — setting the filter's cutoff/center frequency
  - [ ] Q control — controlling filter resonance/bandwidth
  - [ ] Gain control where applicable — boosting/cutting for shelving and peaking filter types
  - [ ] Connecting filters into the audio graph — wiring a filter between a source and destination
- [ ] Basic playback and routing — chaining nodes to move audio from source to speakers
  - [ ] Source → processing node → output flow — the fundamental signal-chain pattern
  - [ ] Multiple nodes in a graph — chaining more than one processing node together
  - [ ] Basic multitrack audio routing — mixing several track outputs into one destination

### 3. State Decoupling & Real-Time Audio Architecture
- [ ] UI state vs. real-time audio state — why audio-processing state can't live on React's render clock
- [ ] SharedArrayBuffer fundamentals — a memory buffer shared between the main thread and the audio thread
  - [ ] Shared memory concept — a single memory region accessible from multiple execution contexts
  - [ ] SharedArrayBuffer creation and usage — allocating and passing a SharedArrayBuffer between threads
  - [ ] Shared data structures — designing layouts (e.g., typed-array views) for shared memory
  - [ ] Reading shared state — safely reading values written by another thread
  - [ ] Writing shared state — safely writing values another thread will read
- [ ] React UI / audio processing separation — isolating rendering from real-time audio work
  - [ ] Keep UI state independent from real-time processing state — avoid React state driving audio timing
  - [ ] Prevent UI updates from blocking audio processing — keep the audio thread free of render work
  - [ ] Design the 60-FPS UI independently of the audio processing graph — decouple frame rate from sample-accurate audio
- [ ] Real-time audio graph state management — tracking the live state of nodes/connections outside React
  - [ ] Represent audio graph state separately from visual UI state — a dedicated audio-engine state model
  - [ ] Synchronize required information between UI and processing state — passing only what's needed across the boundary

### 4. Software Architecture Application
- [ ] Apply software architecture concepts to the audio application — structuring the codebase with clear boundaries
  - [ ] Define frontend architectural boundaries — deciding what belongs in UI vs. engine vs. state layers
  - [ ] Separate UI responsibilities from audio responsibilities — enforcing the separation architecturally, not just by convention
  - [ ] Define clear component responsibilities — single-responsibility scoping for each component/module
  - [ ] Keep audio graph management independent from presentation logic — an audio-engine layer with no UI dependencies
  - [ ] Design for later integration of DSP and ML components — leaving extension points for future native/AI modules

### 5. Software Quality Assurance
- [ ] Automated UI testing — writing tests that verify component behavior without manual clicking
  - [ ] Test React components — rendering components in isolation and asserting output
  - [ ] Test user interactions — simulating clicks/inputs and checking resulting behavior
  - [ ] Test timeline behavior — verifying zoom, scroll, and playhead logic
  - [ ] Test track-related UI behavior — verifying mute/solo/volume controls behave correctly
- [ ] Audio node routing tests — verifying the audio graph is wired as intended
  - [ ] Test node creation — asserting nodes are instantiated with correct parameters
  - [ ] Test node connections — asserting expected connections exist between nodes
  - [ ] Test routing changes — asserting the graph updates correctly when routing changes
  - [ ] Test expected audio graph structure — asserting the overall shape of the graph matches the design
- [ ] Apply SQA concepts to the project — general software quality assurance practices
  - [ ] Define testable behaviors — specifying what "correct" looks like before writing tests
  - [ ] Create repeatable automated tests — tests that run consistently in CI/CD
  - [ ] Validate changes without breaking existing behavior — regression testing

### Semester 1 Milestone
- [ ] Working React + TypeScript multitrack timeline interface
- [ ] Basic Web Audio playback and routing
- [ ] OscillatorNode implementation
- [ ] BiquadFilterNode implementation
- [ ] UI/audio state separation using SharedArrayBuffer
- [ ] Automated UI tests
- [ ] Audio graph/node routing tests

---

# Year 3 — Semester 2
## Months 7–12: Mathematical DSP & Machine Learning Foundations

### 1. Mathematical Foundations for Audio
- [ ] Linear algebra fundamentals for audio — vectors and matrices as they apply to signal processing
  - [ ] Vectors — ordered lists of numbers representing signals or feature data
  - [ ] Matrices — 2D arrays used for transformations and batched signal operations
  - [ ] Arrays as mathematical representations of signals — treating a waveform as a numeric sequence
  - [ ] Basic operations used in signal manipulation — addition, scaling, and dot products applied to signals
- [ ] Discrete mathematics concepts relevant to audio processing — math for signals sampled at discrete points in time
  - [ ] Discrete representations — modeling continuous sound as a finite sequence of samples
  - [ ] Discrete operations used in signal processing — summation, differencing, and convolution on discrete data
  - [ ] Logical and mathematical reasoning for algorithms — formal reasoning used to design and verify DSP algorithms
- [ ] Audio signals as arrays — the core mental model connecting sound to code
  - [ ] Samples — individual numeric measurements of amplitude at a point in time
  - [ ] Sample sequences — an ordered series of samples forming a waveform
  - [ ] Numerical manipulation of signals — applying math operations directly to sample arrays

### 2. Modern C++ Fundamentals
- [ ] C++17/C++20 fundamentals — modern C++ syntax and language features used in audio software
  - [ ] Core language syntax — basic C++ syntax: statements, control flow, types
  - [ ] Functions — declaring and calling functions, including overloading and parameters
  - [ ] Classes — user-defined types bundling data and behavior
  - [ ] Structs — plain data-holding types, similar to classes with public members by default
  - [ ] References — aliases to existing variables, used to avoid copies
  - [ ] Pointers — variables holding memory addresses, used for direct memory access
  - [ ] Const correctness — using `const` to express and enforce immutability
- [ ] C++ memory management basics — how C++ manually manages memory (unlike garbage-collected languages)
  - [ ] Stack vs. heap — automatic, scoped memory vs. manually managed dynamic memory
  - [ ] Object lifetime — when an object is constructed and destroyed
  - [ ] Dynamic allocation — allocating memory at runtime (`new`/`malloc` and modern alternatives)
  - [ ] RAII fundamentals — tying resource lifetime to object lifetime for automatic cleanup
  - [ ] Ownership concepts — who is responsible for freeing a given piece of memory
- [ ] C++ for audio-oriented numerical processing — applying C++ specifically to sample-level processing
  - [ ] Working with arrays of samples — reading/writing contiguous blocks of audio data
  - [ ] Processing sample data — applying per-sample or per-block computations
  - [ ] Writing simple signal-processing routines — implementing basic DSP functions in C++

### 3. Mathematical DSP Foundations
- [ ] Digital audio signal representation — how continuous sound becomes discrete digital data
  - [ ] Waveform as sampled numerical data — a waveform expressed as a sequence of amplitude values
  - [ ] Sample-by-sample processing — applying an operation to each sample individually
  - [ ] Basic signal transformations — simple operations like gain, offset, and clipping
- [ ] DSP implementation fundamentals in C++ — the general shape of a DSP processing function
  - [ ] Input sample arrays — receiving a block of samples to process
  - [ ] Processing operations — applying the actual DSP algorithm to the input
  - [ ] Output sample arrays — writing the processed result to an output buffer
  - [ ] Efficient numerical processing basics — writing processing loops that avoid unnecessary overhead

### 4. Audio Feature Extraction — Python & Librosa
- [ ] Python fundamentals required for audio ML work — the Python basics needed before using ML/audio libraries
  - [ ] Variables and data structures — Python's core types: lists, dicts, tuples, etc.
  - [ ] Functions — defining and calling reusable blocks of Python code
  - [ ] Numerical data handling — working with numeric arrays (e.g., via NumPy)
  - [ ] Basic file/data processing — reading and writing audio and data files in Python
- [ ] Librosa fundamentals — a Python library for analyzing and extracting features from audio
  - [ ] Loading audio files — reading an audio file into a NumPy array with Librosa
  - [ ] Waveform analysis — inspecting amplitude/time-domain characteristics of loaded audio
  - [ ] Spectrogram generation — converting a waveform into a time-frequency image (via STFT)
  - [ ] Mel-frequency representations — spectrograms scaled to match human pitch perception
  - [ ] MFCC extraction — extracting Mel-frequency cepstral coefficients, compact features used in audio ML
- [ ] Audio feature datasets — assembling extracted features into a usable ML dataset
  - [ ] Prepare waveform-derived features — turning raw waveforms into structured feature arrays
  - [ ] Organize spectrogram data — storing/labeling spectrograms for model input
  - [ ] Organize MFCC data — storing/labeling MFCC features for model input
  - [ ] Prepare features for machine learning — formatting features into the shape a model expects

### 5. Introductory PyTorch
- [ ] PyTorch fundamentals — a Python deep learning framework built around tensors
  - [ ] Tensors — PyTorch's core multi-dimensional array type
  - [ ] Tensor shapes — the dimensions of a tensor and why they must align between layers
  - [ ] Basic tensor operations — indexing, reshaping, and math operations on tensors
  - [ ] Datasets — PyTorch's abstraction for accessing training examples
  - [ ] Data loading — batching and shuffling data efficiently with DataLoader
  - [ ] Training loop fundamentals — the forward/loss/backward/step cycle used to train a model
- [ ] Neural network fundamentals — the core building blocks of a trainable model
  - [ ] Model definition — declaring a network's layers and structure
  - [ ] Inputs and outputs — what data goes into and comes out of the model
  - [ ] Forward pass — computing a prediction by passing input through the network
  - [ ] Loss — a function measuring how wrong a prediction is
  - [ ] Backpropagation — computing gradients of the loss with respect to model weights
  - [ ] Optimization — updating weights using gradients (e.g., via SGD/Adam)
- [ ] Audio classification — training a model to label audio clips by category
  - [ ] Use Librosa-extracted features as model inputs — feeding spectrograms/MFCCs into a neural net
  - [ ] Build a basic audio classification model — a small network for classifying audio features
  - [ ] Train the model — running the training loop until the model converges
  - [ ] Evaluate classification results — measuring accuracy and other metrics on held-out data

### 6. Music Information Retrieval (MIR) Research
- [ ] MIR fundamentals — the field of extracting meaningful information from music audio
  - [ ] Definition and purpose of MIR — what problems MIR research addresses
  - [ ] Audio representations used in MIR — common inputs (waveform, spectrogram, MFCC) for MIR models
  - [ ] Audio feature analysis — interpreting extracted features in a musical context
- [ ] Research current MIR architectures — surveying the field before building your own model
  - [ ] Read research papers — reading published MIR/audio-ML papers
  - [ ] Identify major model approaches — recognizing common architecture families (CNN, RNN, transformer, etc.)
  - [ ] Compare model inputs and outputs — understanding what each architecture consumes and produces
  - [ ] Identify approaches relevant to the capstone — narrowing research to what applies to your DAW/stem-separation goals
- [ ] Stem separation research — studying how models isolate vocals, drums, bass, etc. from a mix
  - [ ] Understand the stem separation problem — separating a mixed track into its component sources
  - [ ] Study current architectures — researching models like Demucs, Spleeter, and similar approaches
  - [ ] Study training data requirements — what paired mix/stem datasets a model needs
  - [ ] Study evaluation approaches — metrics used to judge separation quality (e.g., SDR)

### Semester 2 Milestone
- [ ] Understand audio signals as numerical arrays
- [ ] Basic modern C++17/C++20 programming
- [ ] Basic C++ memory management
- [ ] C++ signal-processing exercises
- [ ] Python + Librosa audio feature extraction
- [ ] Spectrogram generation
- [ ] MFCC extraction
- [ ] Introductory PyTorch neural network
- [ ] Audio classification model
- [ ] MIR research foundation
- [ ] Stem separation research foundation

---

# Year 4 — Semester 1
## Months 13–18: Deep Learning & Native C++ Plugins (Capstone Part 1)

### 1. C++ & JUCE
- [ ] Advanced C++ for audio software — deeper C++ skills specific to real-time audio code
  - [ ] Deeper memory management — advanced allocation strategies (pools, avoiding allocation in the audio thread)
  - [ ] Efficient object and data handling — minimizing copies and overhead in hot code paths
  - [ ] Audio-oriented C++ programming — writing C++ tuned for real-time, low-latency constraints
- [ ] JUCE fundamentals — a C++ framework for building audio applications and plugins
  - [ ] JUCE project structure — how a JUCE project/module is organized
  - [ ] JUCE audio concepts — JUCE's audio-buffer, processor, and graph abstractions
  - [ ] JUCE plugin development fundamentals — the basics of building a plugin with JUCE
- [ ] Native audio plugin development — building a plugin that runs inside a DAW
  - [ ] Audio input/output flow — how audio enters and exits a plugin
  - [ ] Real-time audio processing structure — the constraints and structure of the audio callback
  - [ ] Plugin parameter handling — exposing adjustable parameters (e.g., gain, frequency) to the host
  - [ ] Audio processing callbacks — the function a host repeatedly calls to process audio blocks

### 2. Native DSP Algorithms
- [ ] Parametric equalizer — a filter that lets you shape specific frequency bands
  - [ ] Filter structure — the underlying filter type/topology (e.g., biquad) used to build the EQ
  - [ ] Frequency control — setting the center/cutoff frequency of each EQ band
  - [ ] Gain control — boosting or cutting a frequency band
  - [ ] Q control — controlling how narrow or wide a band's effect is
  - [ ] Real-time processing implementation — implementing the EQ to run inside an audio callback
- [ ] Dynamic compressor — an effect that automatically reduces the volume of loud signals
  - [ ] Input level analysis — measuring the incoming signal's level in real time
  - [ ] Threshold — the level above which compression begins to apply
  - [ ] Ratio — how much the signal is reduced once above the threshold
  - [ ] Attack — how quickly compression engages once the threshold is crossed
  - [ ] Release — how quickly compression disengages after the signal drops below the threshold
  - [ ] Gain processing — applying makeup gain to restore overall level after compression
  - [ ] Real-time processing implementation — implementing the compressor to run inside an audio callback
- [ ] DSP implementation discipline — coding practices required for reliable real-time audio
  - [ ] Process audio sample data in real time — meeting strict timing deadlines per audio block
  - [ ] Keep processing suitable for audio callbacks — avoiding locks, allocation, and blocking calls in the callback
  - [ ] Validate DSP behavior — testing that the algorithm produces correct output

### 3. Advanced Music AI — PyTorch
- [ ] Deep learning foundations for audio — applying deep learning specifically to audio data
  - [ ] Neural network architectures for audio — CNNs, RNNs, and transformers as applied to audio
  - [ ] Audio model inputs — the tensor formats (spectrograms, waveforms) fed to audio models
  - [ ] Audio model outputs — what an audio model predicts (labels, masks, separated stems)
  - [ ] Training workflow — the end-to-end process of training an audio model
  - [ ] Validation and evaluation — checking a model's performance on unseen data
- [ ] Music Information Retrieval models — building a model based on your earlier MIR research
  - [ ] Select a relevant MIR architecture from research — choosing a model design to implement
  - [ ] Prepare training data — assembling and formatting a dataset for the chosen model
  - [ ] Prepare model inputs — converting raw audio into the model's expected input format
  - [ ] Train the model — running the training loop to fit the model to data
  - [ ] Evaluate the model — measuring the trained model's performance
- [ ] AI stem separation — training a model to split a mix into individual instrument tracks
  - [ ] Define stem separation targets — deciding which sources the model will isolate
    - [ ] Vocals — isolating the vocal track from the mix
    - [ ] Drums — isolating the drum track from the mix
    - [ ] Bass — isolating the bass track from the mix
  - [ ] Prepare training data — assembling paired mix/stem audio for training
  - [ ] Design the separation model — choosing an architecture (e.g., mask-based or waveform-based)
  - [ ] Train the separation model — running training until stems separate cleanly
  - [ ] Evaluate separation quality — measuring separation with metrics like SDR
  - [ ] Produce separated stem outputs — exporting isolated vocal/drum/bass audio files

### 4. Capstone Part 1 Integration
- [ ] Native C++ audio plugin — the compiled plugin combining the EQ and compressor
  - [ ] Functional parametric equalizer — a working EQ inside the plugin
  - [ ] Functional dynamic compressor — a working compressor inside the plugin
  - [ ] Stable audio processing flow — the plugin runs without glitches or crashes
- [ ] Python/PyTorch model — the trained model produced from your AI work
  - [ ] Functional audio model — a model that runs inference correctly
  - [ ] Functional stem separation — the model reliably separates stems from input audio
  - [ ] Repeatable inference workflow — a script/pipeline that runs inference consistently
- [ ] Document the relationship between the native DSP and AI components — writing down how the two subsystems will eventually connect

### Semester 1 Milestone — Capstone Part 1
- [ ] Working native desktop C++/JUCE audio plugin
- [ ] Parametric equalizer implemented
- [ ] Dynamic compressor implemented
- [ ] Working PyTorch MIR/AI component
- [ ] Working stem separation model
- [ ] Vocals separation
- [ ] Drums separation
- [ ] Bass separation

---

# Year 4 — Semester 2
## Months 19–24: WebAssembly, WAMs & Edge Integration (Capstone Part 2)

### 1. Emscripten & WebAssembly
- [ ] WebAssembly fundamentals — a low-level binary format that runs near-native code in the browser
  - [ ] WebAssembly execution model — how the browser loads and executes a WASM module
  - [ ] C++ → WebAssembly compilation concept — compiling native C++ into a WASM binary
  - [ ] Memory model relevant to compiled audio processing — how WASM's linear memory is used for audio buffers
- [ ] Emscripten toolchain — the compiler toolchain that turns C++ into WebAssembly
  - [ ] Configure C++ compilation for WebAssembly — setting up Emscripten build flags/targets
  - [ ] Compile C++ audio/DSP code to WebAssembly — building your EQ/compressor into a WASM module
  - [ ] Understand generated WebAssembly modules — reading the output artifacts Emscripten produces
  - [ ] Integrate compiled modules into the browser environment — loading and calling the WASM module from JavaScript
- [ ] Port the native DSP algorithms — moving your JUCE DSP code to run in the browser
  - [ ] Parametric equalizer → WebAssembly — compiling the EQ for browser use
  - [ ] Dynamic compressor → WebAssembly — compiling the compressor for browser use
  - [ ] Validate DSP output after compilation — confirming WASM output matches the native version

### 2. Web Audio Modules (WAM v2)
- [ ] WAM v2 fundamentals — a standard for packaging Web Audio plugins so they interoperate across hosts
  - [ ] WAM architecture — how a WAM plugin is structured and loaded
  - [ ] WAM plugin structure — the required interface/files a WAM plugin exposes
  - [ ] WAM ↔ Web Audio integration — how a WAM plugin connects into a Web Audio graph
- [ ] Package C++/WASM DSP as WAM v2 — wrapping your compiled DSP as a standard WAM plugin
  - [ ] Define WAM plugin structure — implementing the WAM interface around your WASM module
  - [ ] Connect DSP processing to the browser audio graph — wiring the plugin into Web Audio nodes
  - [ ] Expose plugin parameters — surfacing EQ/compressor parameters for host/UI control
  - [ ] Process audio inside AudioWorklet — running the actual processing on the audio-rendering thread
- [ ] AudioWorklet integration — using the Web Audio API's dedicated real-time processing thread
  - [ ] AudioWorklet processing model — how AudioWorklet runs isolated from the main thread
  - [ ] Real-time processing inside AudioWorklet — meeting real-time constraints inside the worklet
  - [ ] Connect WAM processing to the multitrack environment — wiring the WAM plugin into your DAW's track chain

### 3. ONNX Model Export
- [ ] PyTorch → ONNX workflow — converting a trained PyTorch model into a portable format
  - [ ] Understand ONNX model representation — ONNX's graph-based format for representing models
  - [ ] Export the trained PyTorch model — converting your stem-separation model to ONNX
  - [ ] Validate the exported model — confirming the ONNX model produces the same output as PyTorch
  - [ ] Prepare the model for browser inference — optimizing/formatting the model for browser runtimes

### 4. Edge Inference with WebGPU
- [ ] Browser-side inference fundamentals — running a trained model directly in the browser instead of a server
  - [ ] Local model execution concept — running inference on the user's device
  - [ ] Edge inference concept — performing computation close to the data source rather than in the cloud
  - [ ] Audio model inference workflow — the steps from audio input to model output in the browser
- [ ] ONNX inference in the browser — running an ONNX model client-side (e.g., via ONNX Runtime Web)
  - [ ] Load ONNX model locally — loading the exported model file in the browser
  - [ ] Prepare audio input tensors — converting audio into the tensor shape the model expects
  - [ ] Run inference locally — executing the model in the browser
  - [ ] Retrieve model outputs — reading and using the model's predicted output
- [ ] WebGPU acceleration — using the browser's GPU API to speed up model inference
  - [ ] WebGPU fundamentals for tensor computation — how WebGPU exposes GPU compute to the browser
  - [ ] GPU-accelerated model execution — running inference on the GPU instead of the CPU
  - [ ] Connect WebGPU-backed inference to the audio workflow — wiring GPU inference into your DAW pipeline
- [ ] Browser-based stem separation — running the full separation model end-to-end in-browser
  - [ ] Vocal stem output — producing an isolated vocal track in the browser
  - [ ] Drum stem output — producing an isolated drum track in the browser
  - [ ] Bass stem output — producing an isolated bass track in the browser
  - [ ] Validate local inference results — comparing browser inference output against the server/PyTorch version

### 5. Final Web-Native Audio Production Environment
- [ ] React + TypeScript multitrack UI
  - [ ] Timeline
  - [ ] Track management
  - [ ] Audio clip representation
  - [ ] Playback controls
- [ ] Web Audio graph
  - [ ] Multitrack routing
  - [ ] Audio processing chain
  - [ ] Audio graph management
- [ ] WAM v2 / WebAssembly DSP
  - [ ] Parametric equalizer
  - [ ] Dynamic compressor
  - [ ] AudioWorklet processing
- [ ] ONNX + WebGPU AI
  - [ ] Local model loading
  - [ ] Local inference
  - [ ] Stem separation
- [ ] End-to-end integration
  - [ ] Connect UI to audio graph
  - [ ] Connect audio graph to WAM plugins
  - [ ] Connect AI inference to the production workflow
  - [ ] Verify the complete browser-based workflow

### 6. Capstone Part 2 Integration
- [ ] React multitrack interface integrated
- [ ] Web Audio audio graph integrated
- [ ] WebAssembly DSP integrated
- [ ] WAM v2 plugins integrated
- [ ] AudioWorklet processing integrated
- [ ] ONNX model integrated
- [ ] WebGPU inference integrated
- [ ] Browser-based stem separation integrated
- [ ] Complete Web-Native Audio Production Environment working end-to-end

### Semester 2 Milestone — Final Capstone
- [ ] C++/JUCE DSP compiled to WebAssembly using Emscripten
- [ ] DSP packaged as WAM v2
- [ ] WAM running through AudioWorklet
- [ ] PyTorch model exported to ONNX
- [ ] ONNX model executing locally in the browser
- [ ] WebGPU acceleration working
- [ ] Stem separation running on the edge
- [ ] React multitrack UI connected to the complete audio system
- [ ] Final Web-Native Audio Production Environment completed

---

# 2-Year Final Completion Checklist

## Web Audio & Frontend
- [ ] TypeScript
- [ ] React
- [ ] Multitrack timeline UI
- [ ] Web Audio API
- [ ] OscillatorNode
- [ ] BiquadFilterNode
- [ ] Audio graph management
- [ ] SharedArrayBuffer state decoupling
- [ ] UI/audio processing separation

## DSP & C++
- [ ] Linear algebra for audio
- [ ] Discrete mathematics for audio
- [ ] Audio represented as numerical arrays
- [ ] C++17/C++20
- [ ] C++ memory management
- [ ] Mathematical DSP foundations
- [ ] JUCE
- [ ] Parametric equalizer
- [ ] Dynamic compressor
- [ ] Real-time audio processing

## Audio ML & MIR
- [ ] Python for audio ML
- [ ] Librosa
- [ ] Spectrograms
- [ ] MFCCs
- [ ] PyTorch
- [ ] Neural network fundamentals
- [ ] Audio classification
- [ ] MIR
- [ ] MIR architecture research
- [ ] Stem separation research
- [ ] Deep learning for music/audio
- [ ] AI stem separation
- [ ] Vocal separation
- [ ] Drum separation
- [ ] Bass separation

## WebAssembly & Browser-Native DSP
- [ ] WebAssembly fundamentals
- [ ] Emscripten
- [ ] C++ → WebAssembly compilation
- [ ] WAM v2
- [ ] WAM plugin packaging
- [ ] AudioWorklet
- [ ] Browser-based native DSP integration

## Edge AI
- [ ] ONNX
- [ ] PyTorch → ONNX export
- [ ] Browser-side ONNX inference
- [ ] WebGPU
- [ ] Tensor computation with WebGPU
- [ ] Edge audio inference
- [ ] Browser-based stem separation

## Final System
- [ ] React multitrack UI
- [ ] Web Audio graph
- [ ] WAM v2 DSP plugins
- [ ] WebAssembly DSP
- [ ] AudioWorklet processing
- [ ] ONNX AI model
- [ ] WebGPU acceleration
- [ ] Local stem separation
- [ ] Complete Web-Native Audio Production Environment
