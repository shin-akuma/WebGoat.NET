---
description: Output controls for code-writing variant — draft PRs, own-branch pushes.
safe-outputs:
  # Mint a short-lived GitHub App installation token INSIDE the safe_outputs job
  # (step id: safe-outputs-app-token) and use it for PR create/push. A token minted
  # in the agent job (e.g. via a custom steps: block) is NOT visible here — step
  # outputs don't cross jobs — so PRs would fall back to GITHUB_TOKEN and be blocked
  # by "Allow GitHub Actions to create and approve pull requests". The App needs
  # Contents: write + Pull requests: write and must be installed on the repo.
  github-app:
    app-id: ${{ vars.REPO_ASSIST_APP_ID }}
    private-key: ${{ secrets.REPO_ASSIST_APP_PRIVATE_KEY }}
  create-pull-request:
    draft: true
    title-prefix: "[repo-assist] "
    labels: [automation, repo-assist]
    protected-files: fallback-to-issue
    if-no-changes: ignore
    max: 3
  push-to-pull-request-branch:
    required-title-prefix: "[repo-assist] "
    protected-files: fallback-to-issue
    max: 3
---
