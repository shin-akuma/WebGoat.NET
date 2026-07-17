---
description: Output controls for triage variant — comments, labels, tracking issue.
safe-outputs:
  add-comment:
    max: 10
    target: "*"
    hide-older-comments: true
  add-labels:
    allowed: [bug, enhancement, "help wanted", "good first issue", documentation, question, duplicate, wontfix, "needs triage", "needs investigation", performance, security, refactor]
    max: 30
    target: "*"
  create-issue:
    title-prefix: "[repo-assist] "
    labels: [automation, repo-assist]
    max: 4
---
