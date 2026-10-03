# CodeStock Lunch & Learn

A slideshow for an internal Lunch & Learn, "What I Brought Back From CodeStock", which shares ideas the presenter picked up at the CodeStock tech conference and then opens the floor for discussion.

## Language

**CodeStock**:
The community-run tech conference in Knoxville that the presenter attended earlier this year, where the Takeaways came from.
_Avoid_: the conference, the event

**Lunch & Learn**:
The informal internal session where the slideshow is presented. Attendees bring their own lunch.
_Avoid_: talk, presentation, brown bag

**Takeaway**:
One of the four ideas from CodeStock that the presenter chose to share. Each one gets a short highlights section.
_Avoid_: topic, session, lesson

**Highlights**:
The brief run-through of what matters most about a single Takeaway. It is meant as an overview, not a deep dive.
_Avoid_: deep dive, tutorial

**Discussion**:
The open part of the Lunch & Learn after the Highlights, where attendees bring their own takeaways, questions and opinions.
_Avoid_: Q&A

**Discussion Prompt**:
The deliberately provocative question that ends each Takeaway. All four are collected again to open the Discussion, and the room picks which one to start with.
_Avoid_: question, talking point

**Audience**:
The people at the Lunch & Learn. Most are developers (largely .NET, and the frontend developers know the backend well enough), joined by managers, QA, designers and others. Every Takeaway has to make sense to people who don't write code.

## Structure

**The Arc**:
The thread connecting the four Takeaways in order: *plan before you prompt* (structured AI development) → *record why* (ADR) → *see it run* (observability) → *keep it running* (resilience). It is stated on the agenda.
_Avoid_: flow, theme

**Beats**:
The five-part shape every Takeaway follows: what it is → the problem it solves → a concrete example → First Step → Discussion Prompt.
_Avoid_: sections, template

**First Step**:
The one small, concrete action the Audience could take next week to start a Takeaway. It assumes the team is starting from zero, or for OpenTelemetry, extending it to projects that don't use it yet.
_Avoid_: next steps, action items, how it applies here

**Non-Developer Angle**:
An optional one-liner per Takeaway explaining why it matters to managers, QA and designers. It can be dropped without changing the deck.

**Dogfood**:
Using the deck's own repo as a worked example of the Takeaways it presents, e.g. its specs and ADRs.
_Avoid_: meta example, behind the scenes

## The Takeaways

**Structured AI Development**:
Giving AI-assisted coding a deliberate workflow (specs, interviews, plans, tests) instead of ad-hoc prompting. Its examples are Kiro and Skill Packs.
_Avoid_: spec-driven development (one technique within it), vibe coding (its opposite)

**Kiro**:
An AI IDE with structured development built in. It walks you from requirements to design to tasks before any code is written. It is where the presenter first saw the idea at CodeStock.

**Skill Pack**:
A published set of agent skills that brings structured development to general-purpose coding agents. Examples: Matt Pocock's skills and poteto's pstack.
_Avoid_: plugin, prompt library

**Architecture Decision Records (ADRs)**:
Short documents that each record one significant architectural decision and the reasons behind it.

**Observability (OpenTelemetry)**:
Making a system's internal behaviour visible through telemetry, using the OpenTelemetry standard.

**Resilience (Polly)**:
Keeping a system working when the things it depends on fail, using the Polly library.
