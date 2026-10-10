---
layout: center
---

<TakeawayTitle id="resilience" focus-note="Victor Frye's session was about chaos engineering. We're focusing on resilience, and using chaos only to prove it works." />

---

# What it is

Keeping your system working when the things it depends on fail.

<div class="grid grid-cols-2 gap-4 mt-8">
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Retry</div>
    <div class="opacity-80 mt-1">It failed? Wait a moment and try again. Many failures are temporary.</div>
  </div>
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Circuit breaker</div>
    <div class="opacity-80 mt-1">It keeps failing? Stop calling it for a while, so you don't make things worse.</div>
  </div>
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Timeout</div>
    <div class="opacity-80 mt-1">It's taking too long? Give up, rather than leave the user waiting.</div>
  </div>
  <div class="border-2 border-primary rounded-lg p-4">
    <div class="text-xl font-bold">Fallback</div>
    <div class="opacity-80 mt-1">Still failing? Return something sensible instead, such as cached data.</div>
  </div>
</div>

<div class="mt-6 text-center opacity-80"><strong>Polly</strong> is the .NET library for all of these.</div>

<!--
Non-Developer Angle: resilience decides whether one slow partner system means "this page is a bit slower today" or "the whole site is down".
-->

---
layout: center
class: text-center
---

# The problem it solves

<div class="text-3xl leading-relaxed">
Every remote call can fail.<br>
An unprotected one becomes <strong>your</strong> outage.
</div>

<div class="mt-12 opacity-80">The network, a database, a partner API, your own other service.</div>

---

# One line of resilience

<<< @/snippets/resilience-pipeline.cs {3-6}

<!--
Microsoft.Extensions.Http.Resilience wraps Polly with sensible defaults. You can tune each strategy later, but the defaults are a good start.
-->

---

# Prove it works: inject a fault

<<< @/snippets/resilience-chaos.cs {8,10-16}

<div class="mt-2 opacity-80">
The caller almost never sees the 500s: the standard handler retries them. Polly's telemetry shows each one, so watch it happen in the Aspire dashboard.
</div>

<!--
Order matters: the standard handler goes first (outer), and chaos goes after it (inner), so the resilience strategies get to handle the injected fault. That's from Microsoft's own guidance on chaos with Polly v8. Keep the rate below the circuit breaker's 10% failure ratio, or the breaker will open, which is a different demo.
Polly reports retries and injected outcomes as metrics on the "Polly" meter and in logs; add .WithMetrics(m => m.AddMeter("Polly")) to the OpenTelemetry setup to see them in Aspire.
-->

---

# First Step

<div class="text-3xl mt-12 leading-relaxed">
Add the standard resilience handler to one flaky <code>HttpClient</code>.
</div>

<div class="mt-12 opacity-80">
One package, one line. Then add the chaos handler in dev, and watch it hold up.
</div>

<!--
If someone asks about the database: EF Core's SQL Server provider has its own retry. Call EnableRetryOnFailure() in UseSqlServer(..., sql => sql.EnableRetryOnFailure()) to retry transient SQL errors.
-->

---
layout: center
class: text-center
---

# Discussion Prompt

<div class="text-3xl mt-8 leading-relaxed">{{ takeaway.discussionPrompt }}</div>

<script setup>
import { takeawayById } from '../data/takeaways'
const takeaway = takeawayById('resilience')
</script>
