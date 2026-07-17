---
description: Vetted GitHub tool config for Repo Assist — hardened, limited toolsets.
tools:
  github:
    toolsets: [repos, issues, pull_requests]
    # Gateway v0.4.x defaults to forcePublicRepos:true (spec §4.1.3.8) + DIFC
    # secrecy filtering (§10.8), which scope the agent to repos="public" and block
    # ALL private-repo content as "private-scoped data" — even owner-authored items.
    # Repo Assist reads a private repo and writes back to that SAME private repo
    # (no private→public leak), so opt out. The compiler translates this to
    # gateway.forcePublicRepos:false and skips the sink-visibility override.
    # Requires guards_mode=filter (our mode), not strict.
    private-to-public-flows: allow
network:
  allowed:
    - api.github.com
---

# GitHub Tools (Repo Assist)

Provides issue/PR/repo read (and write-via-safe-outputs) capabilities.
Toolsets are intentionally limited to `repos`, `issues`, `pull_requests`.
The built-in GitHub MCP server image is managed and version-pinned by gh-aw itself,
so there is no user-facing container digest to maintain here.
