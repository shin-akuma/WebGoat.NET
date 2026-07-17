---
on:
  schedule: daily
  slash_command:
    name: repo-assist-triage
  reaction: "eyes"
engine: copilot
timeout-minutes: 15
permissions: read-all
# Guard: never run against this central repo; consumers (any other repo) run normally.
if: ${{ github.repository != 'shin-akuma/xero-agentic-workflows' }}
imports:
  - /.github/workflows/config/org-defaults.md
  - /.github/workflows/shared/mcp/github.md
  - /.github/workflows/shared/guard/integrity-permissive.md
  - /.github/workflows/shared/safe-outputs/triage-outputs.md
  - /.github/workflows/shared/telemetry/otlp.md
tools:
  bash: true
  repo-memory: true
  web-fetch:
source: shin-akuma/xero-agentic-workflows@1890426e53c1a1da9b16ec5e23c68995f54057a4
---

# Repo Assist — Triage

Label and comment on open issues/PRs. Never opens PRs. Always polite, concise,
AI-disclosed. Maintain the monthly activity tracking issue.
