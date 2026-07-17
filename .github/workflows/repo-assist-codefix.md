---
on:
  reaction: eyes
  schedule: weekly
  slash_command:
    name: repo-assist-fix
permissions: read-all
if: ${{ github.repository != 'shin-akuma/xero-agentic-workflows' }}
imports:
- shin-akuma/xero-agentic-workflows/.github/workflows/config/org-defaults.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/mcp/github.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/guard/integrity-strict.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/safe-outputs/codefix-outputs.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/policy/protected-files.md@a9d1469e393dd6110a1dd518de2037c7303ac091
- shin-akuma/xero-agentic-workflows/.github/workflows/shared/telemetry/otlp.md@a9d1469e393dd6110a1dd518de2037c7303ac091
engine: copilot
sandbox:
  mcp:
    version: v0.4.1
source: shin-akuma/xero-agentic-workflows@a9d1469e393dd6110a1dd518de2037c7303ac091
strict: false
timeout-minutes: 20
tools:
  bash: true
  repo-memory: true
  web-fetch: null
---

# Repo Assist — Code Fix

Investigate fixable issues; open minimal, tested draft PRs. Build + test before
every PR. Respect the protected-files policy. Never merge. AI-disclosed.