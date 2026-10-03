# Build the deck in Slidev, not PowerPoint or Google Slides

The Lunch & Learn deck is a Slidev project: the slides are Markdown files in a git repo. We chose Slidev because code snippets are the main visual (Shiki highlighting comes built in), and because a repo lets the deck Dogfood its own Takeaways, with specs, a `CONTEXT.md` and ADRs living next to the slides. The cost is that people who don't code can't easily edit the deck, and moving the content to another tool later would mean rebuilding every slide by hand.
