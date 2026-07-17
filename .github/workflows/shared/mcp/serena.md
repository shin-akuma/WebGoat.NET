---
description: Serena semantic code-navigation MCP server (optional; for code-writing tasks).
import-schema:
  languages:
    type: string
    required: true
mcp-servers:
  serena:
    # Tag-pinned, not digest-pinned: gateway v0.3.30's `container` field rejects
    # the `@sha256:` form (pattern ^[a-zA-Z0-9][a-zA-Z0-9/:_.-]*$). Renovate keeps
    # this tag current; revisit digest pinning when the bundled gateway supports it.
    container: "ghcr.io/oraios/serena:1.5.3"
    env:
      SERENA_LANGUAGES: ${{ github.aw.import-inputs.languages }}
---

# Serena (code navigation)

Enable for the code-fix variant to improve fix accuracy on large codebases.
The image is tag-pinned (`1.5.3`) via the gateway-native `container` field; the
gateway (v0.3.30) rejects `@sha256:` digests here, so Renovate tracks the tag.
