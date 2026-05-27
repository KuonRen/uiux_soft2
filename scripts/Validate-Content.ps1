$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$dataPath = Join-Path $root "wwwroot/data/osaka-topics.json"

if (-not (Test-Path -LiteralPath $dataPath)) {
    throw "Content data file was not found: $dataPath"
}

$topics = @(Get-Content -Raw -LiteralPath $dataPath | ConvertFrom-Json)

if ($topics.Count -eq 0) {
    throw "Content data must contain at least one topic."
}

$articleIds = New-Object System.Collections.Generic.HashSet[string]
$articleCount = 0

foreach ($topic in $topics) {
    foreach ($field in @("indexLabel", "title", "description", "iconType", "gradientClass")) {
        if ([string]::IsNullOrWhiteSpace($topic.$field)) {
            throw "Topic is missing required field '$field'."
        }
    }

    $articles = @($topic.articles)
    if ($articles.Count -eq 0) {
        throw "Topic '$($topic.title)' must contain at least one article."
    }

    foreach ($article in $articles) {
        $articleCount++

        foreach ($field in @("id", "title", "body", "imagePath")) {
            if ([string]::IsNullOrWhiteSpace($article.$field)) {
                throw "Article in topic '$($topic.title)' is missing required field '$field'."
            }
        }

        if (-not $articleIds.Add($article.id)) {
            throw "Duplicate article id found: $($article.id)"
        }

        if ($article.id -notmatch "^[a-z0-9]+(?:-[a-z0-9]+)*$") {
            throw "Article id must be a lowercase URL slug: $($article.id)"
        }

        $imagePath = Join-Path $root ("wwwroot/" + $article.imagePath)
        if (-not (Test-Path -LiteralPath $imagePath)) {
            throw "Image file was not found for article '$($article.id)': $($article.imagePath)"
        }
    }
}

Write-Host "Validated $($topics.Count) topics and $articleCount articles."
