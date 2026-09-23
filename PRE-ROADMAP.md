# Pre-Roadmap Foundations — Prerequisites for the 2-Year Roadmap

> **Scope rule:** This covers only the general web, browser, and backend-API foundations the 2-year roadmap assumes but does not itself teach (it starts directly at TypeScript/React and Web Audio). Master these first, then begin `ROADMAP-2.md`.

---

# Phase 0: Prerequisite Foundations

### 1. HTML Fundamentals
- [ ] HTML fundamentals — the markup language that structures content on a web page
  - [ ] Document structure — the basic skeleton of an HTML page (`<!DOCTYPE>`, `<html>`, `<head>`, `<body>`)
  - [ ] Common elements — text, headings, lists, links, images, tables, and their tags
  - [ ] Forms and inputs — collecting user input with `<form>`, `<input>`, `<button>`, `<select>`
  - [ ] Semantic HTML — using tags that convey meaning (`<nav>`, `<section>`, `<article>`, `<header>`)
  - [ ] Attributes — configuring elements with `id`, `class`, `href`, `src`, `data-*`, etc.
- [ ] Accessibility basics — writing markup that works for all users and assistive tech
  - [ ] ARIA roles and labels — describing custom UI to screen readers
  - [ ] Keyboard navigation — ensuring interactive elements work without a mouse

### 2. CSS Fundamentals
- [ ] CSS fundamentals — the language that styles and lays out HTML content
  - [ ] Selectors and specificity — targeting elements and understanding which rules win
  - [ ] Box model — margin, border, padding, and content sizing
  - [ ] Flexbox — one-dimensional layout for rows/columns of UI elements
  - [ ] CSS Grid — two-dimensional layout for complex page/app structures
  - [ ] Responsive design — adapting layout across screen sizes with media queries
- [ ] Modern CSS tooling — the ecosystem around writing and organizing CSS at scale
  - [ ] CSS-in-JS or utility-first CSS (e.g., Tailwind) — common styling approaches used with React
  - [ ] CSS variables — reusable custom properties for theming

### 3. JavaScript Fundamentals
- [ ] Core JavaScript syntax — the base language TypeScript builds on top of
  - [ ] Variables and scope — `let`, `const`, `var`, and block vs. function scope
  - [ ] Data types — strings, numbers, booleans, objects, arrays, `null`/`undefined`
  - [ ] Functions — declarations, expressions, arrow functions, default parameters
  - [ ] Control flow — conditionals, loops, and switch statements
- [ ] Objects and arrays — JavaScript's core data structures
  - [ ] Object literals and property access — creating and reading key/value data
  - [ ] Array methods — `map`, `filter`, `reduce`, and other functional array operations
  - [ ] Destructuring and spread/rest — concise syntax for extracting and combining values
- [ ] Asynchronous JavaScript — handling operations that don't complete immediately
  - [ ] Callbacks — passing functions to run once an operation finishes
  - [ ] Promises — objects representing a future success or failure value
  - [ ] async/await — writing asynchronous code in a synchronous-looking style
- [ ] ES Modules — organizing code into reusable files with `import`/`export`

### 4. Browser-Based Programming
- [ ] The DOM (Document Object Model) — the browser's live, in-memory tree representation of a page
  - [ ] Selecting and traversing elements — finding and navigating nodes in the tree
  - [ ] Creating and modifying elements — building/updating UI with JavaScript
  - [ ] Event handling — responding to clicks, input, and other user actions
  - [ ] Event bubbling and delegation — how events propagate through the DOM tree
- [ ] Browser runtime model — how a browser actually executes your code
  - [ ] The event loop — how JavaScript handles concurrency on a single thread
  - [ ] Call stack, task queue, and microtask queue — the mechanics behind async execution order
  - [ ] Web Workers — running JavaScript off the main thread for heavier work
- [ ] Networking from the browser — how a web app talks to a server
  - [ ] HTTP fundamentals — requests, responses, methods, status codes, and headers
  - [ ] Fetch API / XHR — making network requests from JavaScript
  - [ ] REST API concepts — the request/response conventions most backends (including FastAPI) follow
  - [ ] CORS — the browser security model governing cross-origin requests
- [ ] Browser storage and media — client-side capabilities used by web apps
  - [ ] localStorage/sessionStorage — storing small amounts of data in the browser
  - [ ] File and Blob APIs — handling user-uploaded or generated audio files in-browser

### 5. Python Fundamentals (for the Web Backend)
- [ ] Core Python syntax — the base language FastAPI is written in and used with
  - [ ] Variables and data types — Python's core types: strings, numbers, lists, dicts, tuples
  - [ ] Functions — defining, calling, and typing functions with type hints
  - [ ] Control flow — conditionals, loops, and comprehensions
  - [ ] Modules and packages — organizing and importing Python code
- [ ] Object-oriented Python — classes and objects as used throughout typical backend code
  - [ ] Classes and instances — defining custom types and creating objects from them
  - [ ] Inheritance and composition — reusing and extending behavior across classes
- [ ] Python type hints — annotating function signatures and data models
  - [ ] Basic type annotations — typing variables, parameters, and return values
  - [ ] Pydantic-style data models — declaring structured data with built-in validation (used heavily by FastAPI)
- [ ] Python tooling — the ecosystem needed to run and manage a Python backend
  - [ ] Virtual environments — isolating project dependencies (`venv`, `poetry`, etc.)
  - [ ] Package management with pip — installing and managing libraries

### 6. FastAPI Fundamentals (chosen over Django)
- [ ] Why FastAPI for this project — a lightweight, async-first Python framework suited to a React SPA + API backend, with automatic docs and native Pydantic validation, versus Django's heavier, more opinionated full-stack approach
- [ ] FastAPI fundamentals — the core framework used to build the backend API
  - [ ] Path operations — defining routes with `@app.get`, `@app.post`, etc.
  - [ ] Request/response models — using Pydantic models to validate input and shape output
  - [ ] Path, query, and body parameters — the ways a client can send data to an endpoint
  - [ ] Dependency injection — FastAPI's system for sharing logic (auth, DB sessions) across routes
- [ ] Async endpoints — writing non-blocking route handlers
  - [ ] `async def` route handlers — defining endpoints that can await I/O without blocking
  - [ ] When to use async vs. sync — understanding which operations actually benefit from async
- [ ] File and data handling — capabilities the audio backend will need
  - [ ] File uploads — receiving audio files from the client
  - [ ] Streaming responses — sending audio or large data back without loading it all into memory
  - [ ] Background tasks — running work (e.g., processing) after a response is returned
- [ ] API documentation and testing — tools built into FastAPI's workflow
  - [ ] Automatic OpenAPI/Swagger docs — FastAPI's auto-generated interactive API documentation
  - [ ] Basic endpoint testing — using `TestClient` to verify routes work as expected
- [ ] Connecting frontend to backend — the glue between React and FastAPI
  - [ ] Calling FastAPI endpoints from React — using `fetch`/Axios against your API
  - [ ] Handling CORS between the React dev server and FastAPI — configuring FastAPI to accept frontend requests

### Prerequisite Milestone
- [ ] Comfortable reading and writing basic HTML/CSS layouts
- [ ] Comfortable writing plain JavaScript (functions, arrays, async/await)
- [ ] Understand the DOM, events, and how a browser talks to a server over HTTP
- [ ] Comfortable writing basic Python (functions, classes, type hints)
- [ ] Can build and run a simple FastAPI backend with at least one working endpoint
- [ ] Can call a FastAPI endpoint from a simple JavaScript/React frontend

---

# Prerequisite Completion Checklist

## Frontend Fundamentals
- [ ] HTML
- [ ] CSS
- [ ] JavaScript (ES6+)
- [ ] DOM manipulation
- [ ] Events and event delegation

## Browser & Networking
- [ ] Event loop and async JavaScript
- [ ] HTTP fundamentals
- [ ] Fetch API / REST concepts
- [ ] CORS
- [ ] Browser storage and file APIs

## Backend Fundamentals
- [ ] Python fundamentals
- [ ] Object-oriented Python
- [ ] Python type hints / Pydantic
- [ ] Virtual environments & pip

## FastAPI
- [ ] Path operations
- [ ] Request/response models
- [ ] Dependency injection
- [ ] Async route handlers
- [ ] File uploads & streaming responses
- [ ] Background tasks
- [ ] Automatic API docs
- [ ] Frontend-backend integration
