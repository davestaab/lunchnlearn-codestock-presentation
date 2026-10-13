---
layout: center
---

<TakeawayTitle id="observability" />

---
layout: center
class: text-center
---

# Shift Left

<div class="text-3xl mt-6">Observability starts in <strong>dev</strong>, not in production.</div>

<div class="mt-10 text-xl opacity-80">
Add telemetry from day one, so dev and prod tell the same story.
</div>

<!--
This was Victor Lyuboslavsky's central theme. The usual pattern is "add observability later, when prod breaks". His argument: by then it's too late to learn how the system actually behaves.
-->

---

# What it is

Making a system's internal behavior visible, using the **OpenTelemetry** standard.

<div class="grid grid-cols-3 gap-4 mt-10">
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Traces</div>
    <div class="opacity-80 mt-2">Follow one request through the system, so it leaves a trail.</div>
  </div>
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Logs</div>
    <div class="opacity-80 mt-2">Timestamped records with the details.</div>
  </div>
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Metrics</div>
    <div class="opacity-80 mt-2">Measurements over time, such as request counts and timings. The summary view.</div>
  </div>
</div>

<div class="mt-8 text-center opacity-80">The trace gives the map; the logs give the notes.</div>

<!--
Non-Developer Angle: traces turn "the app is slow" into "this one call to inventory takes 2 seconds", which is something QA can report and a manager can prioritize.
-->

---
layout: center
class: text-center
---

# The problem it solves

<div class="text-2xl">Code intent ≠ runtime behavior</div>

<div class="text-3xl mt-12 italic leading-relaxed">
"The response was correct, but the path it took was not."
</div>

<div class="mt-12 opacity-80">Without telemetry, you only ever see the response.</div>

<!--
E.g. the endpoint returns the right data, but it called the database 40 times to get there. Tests pass; prod falls over under load.
-->

---

# The pipeline

<div class="flex items-center justify-center gap-4 mt-10 text-xl">
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">App</div>
    <div class="text-sm opacity-70">OpenTelemetry SDK</div>
  </div>
  <div class="text-3xl opacity-50">→</div>
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">Collector</div>
    <div class="text-sm opacity-70">optional: filter, batch, route</div>
  </div>
  <div class="text-3xl opacity-50">→</div>
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">Backend</div>
    <div class="text-sm opacity-70">Aspire dashboard locally;<br>Grafana, New Relic in prod</div>
  </div>
</div>

<Callout label="Recurring Signal" class="mt-10">
The <strong>Aspire dashboard</strong> came up in <em>both</em> the observability and the resilience sessions, independently, as the place to start before production tooling.
</Callout>

<!--
The app only speaks OTLP, the standard protocol, so you can swap the backend without touching code.

The ORNL uses __ (find out what it uses) as a backend.
-->

---

# Turn it on: tracing setup

<<< @/snippets/otel-setup.cs {6-11}

<!--
Most of the value comes from the two instrumentation lines: every incoming request and every outgoing HTTP call becomes a span without writing any tracing code.
-->

---

# Anatomy of a trace

<div class="mt-6 font-mono text-sm space-y-2">
  <div class="flex items-center gap-3"><span class="w-56 opacity-70">POST /orders</span><div class="h-6 rounded bg-[#5d8392]/60" style="width: 600px" /></div>
  <div class="flex items-center gap-3"><span class="w-56 opacity-70 pl-4">PlaceOrder (custom)</span><div class="h-6 rounded bg-[#5d8392]/45" style="width: 540px; margin-left: 20px" /></div>
  <div class="flex items-center gap-3"><span class="w-56 opacity-70 pl-8">SELECT carts</span><div class="h-6 rounded bg-green-500/50" style="width: 80px; margin-left: 30px" /></div>
  <div class="flex items-center gap-3"><span class="w-56 opacity-70 pl-8">POST inventory-service</span><div class="h-6 rounded bg-yellow-500/50" style="width: 380px; margin-left: 120px" /></div>
  <div class="flex items-center gap-3"><span class="w-56 opacity-70 pl-8">INSERT orders</span><div class="h-6 rounded bg-red-500/60 flex items-center px-2 text-xs text-white" style="width: 50px; margin-left: 505px">✗</div></div>
</div>

<div class="h-4" />

1. A request starts a span. Most frameworks already do this.
2. Child spans come from libraries, or you add your own.
3. DB calls and outgoing HTTP calls get their own spans. Errors are marked on the span.

<div class="mt-2 opacity-80"><strong>Latency has an address</strong>: the trace shows where the time goes.</div>

---

# Your own spans

<<< @/snippets/otel-custom-span.cs {5,9-10,19}

<!--
ActivitySource is .NET's built-in tracing API, so there's no OpenTelemetry dependency in your business code. The source name has to match the AddSource("OrdersApi") in the setup.
-->

---

# First Step

<div class="text-2xl mt-6">Run the Aspire dashboard locally and look at <strong>one</strong> trace.</div>

<div class="mt-8">

<<< @/snippets/aspire-dashboard.sh

</div>

<div class="mt-6 opacity-80">
Point your app's OTLP exporter at it (the default <code>localhost:4317</code> already does), make one request, and open <code>http://localhost:18888</code>.
</div>

<!--
Starting from zero: no production tooling, no budget, no approvals. One container and the setup snippet from two slides ago.
-->
