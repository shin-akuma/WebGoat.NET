---
description: Vetted GitHub tool config for Repo Assist — hardened, limited toolsets.
tools:
  github:
    toolsets: [repos, issues, pull_requests]
network:
  allowed:
    - api.github.com
---

# GitHub Tools (Repo Assist)

Provides issue/PR/repo read (and write-via-safe-outputs) capabilities.
Toolsets are intentionally limited to `repos`, `issues`, `pull_requests`.
The built-in GitHub MCP server image is managed and version-pinned by gh-aw itself,
so there is no user-facing container digest to maintain here.
