---
theme : "white"
transition: "slide"
highlightTheme: "monokai"
logoImg: "https://avatars.githubusercontent.com/u/3112460"
slideNumber: true
title: "DIP & IoC Talk"
---

# DIP & IoC Talk

The talk about DIP & IoC including theory and examples.


<div style="margin-top: 6em; font-size: 16pt;">
slides using Markdown with <a href="https://marketplace.visualstudio.com/items?itemName=evilz.vscode-reveal">vscode-reveal</a>
</div>

---

## DIP

> The 5th principle in SOLID

![NDepend - Dependency Inversion Principle](https://blog.ndepend.com/wp-content/uploads/DIP.png)

--

## DIP's characteristics - 1/2

- **High level modules** should not depend on **low level modules**; both should depend on **abstractions**.

```mermaid
classDiagram
    HighLevelModule --> Abstraction
    LowLovelModule --|> Abstraction
```

--

## DIP's characteristics - 2/2

- `Abstractions` should not depend on `details`.  Details should depend upon abstractions

```mermaid
classDiagram
    HighLevelModule --> Abstraction
    LowLovelModule --|> Abstraction

    class Abstraction {
        + doSomething(arg)
    }

    class LowLovelModule {
        + doSomething(arg)
        + doSomething(arg, argX)
    }
```

