# Share the deck on Netlify plus a PDF export, not Vercel

The deck is shared after the talk in two ways: as a site hosted on Netlify, and as a PDF export for people who just want a file. The Slidev template shipped with both `netlify.toml` and `vercel.json`. We kept Netlify and deleted the Vercel config so there is only one deployment target to maintain.
