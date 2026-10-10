// Single source of truth for per-Takeaway facts. The agenda, each Takeaway's
// title slide, its Discussion Prompt slide and the Discussion slide all render
// from here, so they can't drift apart. Terms follow CONTEXT.md.

export interface SourceSession {
  title: string
  speaker: string
}

export type TakeawayId = 'structured-ai' | 'adrs' | 'observability' | 'resilience'

export interface Takeaway {
  id: TakeawayId
  name: string
  tool: string
  arcStep: string
  source: SourceSession
  discussionPrompt: string
}

// In Arc order (requirement 1.2).
export const takeaways: Takeaway[] = [
  {
    id: 'structured-ai',
    name: 'Structured AI Development',
    tool: 'Kiro & Skill Packs',
    arcStep: 'Plan before you prompt',
    source: {
      title: 'What the Spec! Battle-Tested Practices for Spec-Driven Development Using Kiro',
      speaker: 'Chris Gonzalez',
    },
    discussionPrompt: 'With AI writing more of the code, “you’re now an architect and decision maker.” Agree or disagree?',
  },
  {
    id: 'adrs',
    name: 'Architecture Decision Records',
    tool: 'ADRs',
    arcStep: 'Record why',
    source: {
      title: 'Navigating the Maze of Communicating Architecture Decisions',
      speaker: 'Chad Green',
    },
    discussionPrompt: 'Name a decision in our codebase nobody can explain anymore. What would it have cost to write it down?',
  },
  {
    id: 'observability',
    name: 'Observability',
    tool: 'OpenTelemetry',
    arcStep: 'See it run',
    source: {
      title: 'Shift Observability Left: Why It Starts in Dev',
      speaker: 'Victor Lyuboslavsky',
    },
    discussionPrompt: 'Do our dev and prod environments tell the same story?',
  },
  {
    id: 'resilience',
    name: 'Resilience',
    tool: 'Polly',
    arcStep: 'Keep it running',
    source: {
      title: 'Polly Want a 500? Chaos Engineering for .NET Apps',
      speaker: 'Victor Frye',
    },
    discussionPrompt: 'Which dependency, if it went down for 10 minutes, would take us down with it?',
  },
]

export function takeawayById(id: TakeawayId): Takeaway {
  const takeaway = takeaways.find(t => t.id === id)
  if (!takeaway)
    throw new Error(`Unknown Takeaway id: ${id}`)
  return takeaway
}
