---
on:
  reaction: eyes
  schedule: daily
  slash_command:
    name: repo-assist-triage
permissions: read-all
if: ${{ github.repository != 'shin-akuma/xero-agentic-workflows' }}
imports:
- shin-akuma/xero-agentic-workflows/.github/workflows/config/org-defaults.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/mcp/github.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/guard/integrity-permissive.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/safe-outputs/triage-outputs.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/telemetry/otlp.md@a9d1469e393dd6110a1dd518de2037c7303ac091
engine: copilot
sandbox:
  mcp:
    version: v0.4.1
source: shin-akuma/xero-agentic-workflows@a9d1469e393dd6110a1dd518de2037c7303ac091
strict: false
timeout-minutes: 15
tools:
  bash: true
  repo-memory: true
  web-fetch: null
---

# Repo Assist — Triage

Label and comment on open issues/PRs. Never opens PRs. Always polite, concise,
AI-disclosed. Maintain the monthly activity tracking issue.