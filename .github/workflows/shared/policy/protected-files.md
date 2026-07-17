---
description: Fintech no-touch file policy (documentation fragment + reference list).
---

# Protected files (do-not-automate)

The agent must never auto-modify these paths (enforced via `protected-files` on
safe-outputs). On a match it files an issue instead.

- Payment / ledger / financial calculation logic
- Database migrations
- Infrastructure as Code (Terraform / Bicep / CloudFormation)
- CI / `.github/` workflows and actions
- Security configs, secrets, manifests
- Dependency lockfiles
