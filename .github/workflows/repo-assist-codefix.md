---
on:
  schedule: weekly
  slash_command:
    name: repo-assist-fix
  reaction: "eyes"
engine: copilot
timeout-minutes: 20
permissions: read-all
# Guard: never run against this central repo; consumers (any other repo) run normally.
if: ${{ github.repository != 'shin-akuma/xero-agentic-workflows' }}
imports:
  - /.github/workflows/config/org-defaults.md
  - /.github/workflows/shared/mcp/github.md
  - uses: /.github/workflows/shared/mcp/serena.md
    with:
      languages: "csharp"
  - /.github/workflows/shared/guard/integrity-strict.md
  - /.github/workflows/shared/safe-outputs/codefix-outputs.md
  - /.github/workflows/shared/policy/protected-files.md
  - /.github/workflows/shared/telemetry/otlp.md
tools:
  bash: true
  repo-memory: true
  web-fetch:
source: shin-akuma/xero-agentic-workflows@5df9da414c62ed8a71015940f1b57a8037cc3ee1
---

# Repo Assist — Code Fix

Investigate fixable issues; open minimal, tested draft PRs. Build + test before
every PR. Respect the protected-files policy. Never merge. AI-disclosed.
