$ErrorActionPreference = "Stop"

$outputPath = Join-Path (Get-Location) "大阪紹介_UIUX発表資料.pptx"
$iconPath = Join-Path (Get-Location) "wwwroot\images\osaka_icon.png"

$ppLayoutBlank = 12
$msoFalse = 0
$msoTrue = -1
$ppSaveAsOpenXMLPresentation = 24

function Rgb($r, $g, $b) {
    return $r + ($g * 256) + ($b * 65536)
}

$script:colors = @{
    Background = Rgb 248 250 252
    Surface = Rgb 255 255 255
    SurfaceSub = Rgb 241 245 249
    TextPrimary = Rgb 15 23 42
    TextSecondary = Rgb 71 85 105
    TextMuted = Rgb 100 116 139
    Border = Rgb 226 232 240
    Accent = Rgb 29 78 216
    Orange = Rgb 249 115 22
    Amber = Rgb 217 119 6
    Rose = Rgb 225 29 72
    Green = Rgb 22 163 74
    Dark = Rgb 15 23 42
}

function Add-TextBox($slide, $text, $x, $y, $w, $h, $fontSize, $bold = $false, $color = $script:colors.TextPrimary, $align = 1) {
    $shape = $slide.Shapes.AddTextbox(1, $x, $y, $w, $h)
    $shape.TextFrame.MarginLeft = 0
    $shape.TextFrame.MarginRight = 0
    $shape.TextFrame.MarginTop = 0
    $shape.TextFrame.MarginBottom = 0
    $shape.TextFrame.TextRange.Text = $text
    $shape.TextFrame.TextRange.Font.Name = "Yu Gothic"
    $shape.TextFrame.TextRange.Font.Size = [int][Math]::Round($fontSize)
    $shape.TextFrame.TextRange.Font.Bold = if ($bold) { $msoTrue } else { $msoFalse }
    $shape.TextFrame.TextRange.Font.Color.RGB = $color
    $shape.TextFrame.TextRange.ParagraphFormat.Alignment = $align
    return $shape
}

function Add-AccentBar($slide) {
    $bar = $slide.Shapes.AddShape(1, 0, 0, 960, 8)
    $bar.Fill.ForeColor.RGB = $script:colors.Accent
    $bar.Line.Visible = $msoFalse
}

function Add-Title($slide, $title, $subtitle = "") {
    Add-TextBox $slide $title 54 48 850 62 30 $true $script:colors.TextPrimary | Out-Null
    if ($subtitle.Length -gt 0) {
        Add-TextBox $slide $subtitle 56 108 830 30 12 $false $script:colors.TextMuted | Out-Null
    }
}

function Add-Card($slide, $x, $y, $w, $h, $title, $body, $accentColor = $script:colors.Accent) {
    $card = $slide.Shapes.AddShape(5, $x, $y, $w, $h)
    $card.Fill.ForeColor.RGB = $script:colors.Surface
    $card.Line.ForeColor.RGB = $script:colors.Border
    $card.Line.Weight = 1

    $dot = $slide.Shapes.AddShape(9, $x + 18, $y + 18, 13, 13)
    $dot.Fill.ForeColor.RGB = $accentColor
    $dot.Line.Visible = $msoFalse

    Add-TextBox $slide $title ($x + 40) ($y + 13) ($w - 56) 24 14 $true $script:colors.TextPrimary | Out-Null
    Add-TextBox $slide $body ($x + 18) ($y + 50) ($w - 36) ($h - 62) 11 $false $script:colors.TextSecondary | Out-Null
}

function Add-Bullets($slide, $items, $x, $y, $w, $fontSize = 14, $lineGap = 36) {
    $currentY = $y
    foreach ($item in $items) {
        $bullet = $slide.Shapes.AddShape(9, $x, $currentY + 8, 8, 8)
        $bullet.Fill.ForeColor.RGB = $script:colors.Accent
        $bullet.Line.Visible = $msoFalse
        Add-TextBox $slide $item ($x + 22) $currentY ($w - 22) 30 $fontSize $false $script:colors.TextSecondary | Out-Null
        $currentY += $lineGap
    }
}

function Add-Footer($slide, $number) {
    Add-TextBox $slide "大阪紹介 UI/UX Assignment" 54 516 350 18 8 $false $script:colors.TextMuted | Out-Null
    Add-TextBox $slide ("0" + $number) 872 516 34 18 8 $true $script:colors.TextMuted 3 | Out-Null
}

$ppt = New-Object -ComObject PowerPoint.Application
$ppt.Visible = $msoTrue
$presentation = $ppt.Presentations.Add()
$presentation.PageSetup.SlideWidth = 960
$presentation.PageSetup.SlideHeight = 540

try {
    for ($i = 1; $i -le 8; $i++) {
        $slide = $presentation.Slides.Add($i, $ppLayoutBlank)
        $slide.Background.Fill.ForeColor.RGB = $script:colors.Background
    }

    # 1. タイトル
    $slide = $presentation.Slides.Item(1)
    Add-AccentBar $slide
    Add-TextBox $slide "大阪紹介" 62 74 540 68 44 $true $script:colors.TextPrimary | Out-Null
    Add-TextBox $slide "観光地・歴史・食べ物を3つの視点から紹介するUI/UXアプリ" 66 150 690 34 16 $false $script:colors.TextSecondary | Out-Null
    Add-TextBox $slide "発表用資料" 66 208 220 30 14 $true $script:colors.Accent | Out-Null
    Add-TextBox $slide "Blazor Server / .NET 10 / Light & Dark UI" 66 242 430 28 12 $false $script:colors.TextMuted | Out-Null
    if (Test-Path $iconPath) {
        $slide.Shapes.AddPicture($iconPath, $msoFalse, $msoTrue, 720, 94, 118, 118) | Out-Null
    }
    Add-Card $slide 66 334 250 96 "目的" "大阪の情報を、短時間で分かりやすく閲覧できる形に整理する。" $script:colors.Accent
    Add-Card $slide 350 334 250 96 "画面構成" "カテゴリカード、ランダムhero、記事モーダル、画像プレビューで構成。" $script:colors.Orange
    Add-Card $slide 634 334 250 96 "対応" "ライトモードとダークモードの両方に対応。" $script:colors.Rose
    Add-Footer $slide 1

    # 2. 対象ユーザー（ペルソナ）
    $slide = $presentation.Slides.Item(2)
    Add-AccentBar $slide
    Add-Title $slide "対象ユーザー（ペルソナ）" "大阪に詳しくない人が、短時間で概要をつかめることを想定"
    Add-Card $slide 70 164 250 178 "ペルソナ" "名前: 佐藤さん / 年齢: 18〜22歳 / 目的: 大阪について課題や旅行前に軽く調べたい。" $script:colors.Accent
    Add-Card $slide 356 164 250 178 "困りごと" "検索結果は情報量が多く、どこから見ればよいか分かりにくい。" $script:colors.Orange
    Add-Card $slide 642 164 250 178 "求める体験" "観光・歴史・食べ物を分けて見たい。画像つきで直感的に知りたい。" $script:colors.Rose
    Add-Bullets $slide @(
        "長い文章より、短い説明と画像で概要を知りたい",
        "スマホでもPCでも、迷わず記事を開けるUIを求めている"
    ) 92 392 760 13 32
    Add-Footer $slide 2

    # 3. アプリの特徴
    $slide = $presentation.Slides.Item(3)
    Add-AccentBar $slide
    Add-Title $slide "アプリの特徴" "一覧性と詳細閲覧を両立した大阪紹介アプリ"
    Add-Card $slide 64 158 254 180 "3カテゴリ構成" "観光地・歴史・食べ物に分類し、情報の入口を分かりやすくした。" $script:colors.Accent
    Add-Card $slide 354 158 254 180 "ランダムhero" "topic画像をランダムに表示し、クリックで対応記事を直接開ける。" $script:colors.Orange
    Add-Card $slide 644 158 254 180 "記事モーダル" "ページ遷移なしで記事一覧と本文を切り替えられる。" $script:colors.Rose
    Add-Bullets $slide @(
        "画像拡大プレビューに対応",
        "ライトモード・ダークモード切替に対応",
        "キーボード操作時のフォーカス表示も用意"
    ) 94 382 760 13 30
    Add-Footer $slide 3

    # 4. 導入起動環境
    $slide = $presentation.Slides.Item(4)
    Add-AccentBar $slide
    Add-Title $slide "導入・起動環境" "開発環境と配布環境の両方を想定"
    Add-Card $slide 78 158 380 184 "開発時の起動" "必要環境: .NET 10 SDK / Windows / Visual Studio または dotnet CLI。起動コマンド: dotnet run" $script:colors.Accent
    Add-Card $slide 502 158 380 184 "配布時の起動" "dotnet publish -c Release で作成したpublishフォルダを配布。exe単体ではなくフォルダごと渡す。" $script:colors.Orange
    Add-Bullets $slide @(
        "ブラウザ: Microsoft Edge / Google Chrome など",
        "画像は wwwroot/images 配下の静的アセットとして利用",
        "起動後、表示されたローカルURLをブラウザで開く"
    ) 96 386 760 13 32
    Add-Footer $slide 4

    # 5. 仕様書（画面構成）
    $slide = $presentation.Slides.Item(5)
    Add-AccentBar $slide
    Add-Title $slide "仕様書（画面構成）" "ユーザーが見る主な画面要素"
    Add-Card $slide 66 156 250 176 "ヘッダー" "ロゴ、アプリ名、テーマ切替ボタンを配置。" $script:colors.Accent
    Add-Card $slide 356 156 250 176 "Home画面" "説明文、ランダムhero、3つのtopicカードを表示。" $script:colors.Orange
    Add-Card $slide 646 156 250 176 "モーダル" "topic内の記事一覧、本文、画像、閉じるボタンを表示。" $script:colors.Rose
    Add-Bullets $slide @(
        "画像クリック時はライトボックスで拡大表示",
        "フッターはコンテンツ量に合わせて下部に表示"
    ) 96 382 760 13 32
    Add-Footer $slide 5

    # 6. 仕様書（操作手順）
    $slide = $presentation.Slides.Item(6)
    Add-AccentBar $slide
    Add-Title $slide "仕様書（操作手順）" "基本操作を簡潔に整理"
    Add-Bullets $slide @(
        "1. Home画面を開く",
        "2. 右上のhero画像、または3つのtopicカードから興味のある項目を選ぶ",
        "3. モーダル内の左側または上部の記事一覧から記事を切り替える",
        "4. 記事画像をクリックすると、拡大プレビューを表示する",
        "5. 閉じるボタン、背景クリック、Escキーでモーダルを閉じる",
        "6. Modeボタンでライトモード / ダークモードを切り替える"
    ) 86 156 810 14 43
    Add-Footer $slide 6

    # 7. 使用言語
    $slide = $presentation.Slides.Item(7)
    Add-AccentBar $slide
    Add-Title $slide "使用言語・技術スタック" "アプリ制作で使用した言語・フレームワーク"
    Add-Card $slide 70 156 250 176 "C#" "Blazorコンポーネントの状態管理、モーダル制御、データサービスで使用。" $script:colors.Accent
    Add-Card $slide 356 156 250 176 "Razor" "Home画面、Layout、条件分岐、イベントハンドラの記述で使用。" $script:colors.Orange
    Add-Card $slide 642 156 250 176 "HTML / CSS" "画面構造、CSS isolation、ライト/ダークテーマ、レスポンシブ対応で使用。" $script:colors.Rose
    Add-Bullets $slide @(
        "JavaScript: テーマ切替、フォーカストラップ、スクロールロックに使用",
        ".NET 10 / Blazor Server: アプリ全体の実行基盤"
    ) 92 386 770 13 32
    Add-Footer $slide 7

    # 8. まとめ
    $slide = $presentation.Slides.Item(8)
    Add-AccentBar $slide
    Add-Title $slide "まとめ（感想・総評）" "大阪の情報を、見やすく・触りやすく・短時間で理解できるUIにした"
    Add-Card $slide 66 164 250 176 "達成したこと" "3カテゴリの記事、画像hero、モーダル、画像拡大、テーマ切替を実装。" $script:colors.Accent
    Add-Card $slide 356 164 250 176 "工夫したこと" "右上の空白をheroとして活用し、画像から記事へ直接移動できる導線を追加。" $script:colors.Orange
    Add-Card $slide 646 164 250 176 "総評" "情報分類、視覚表現、操作導線をまとめ、課題作品として一貫した画面に仕上げた。" $script:colors.Rose
    Add-TextBox $slide "感想: 見た目を整えるだけでなく、ユーザーが迷わず記事へ進める導線作りの重要性を学んだ。" 82 404 790 38 16 $true $script:colors.TextPrimary | Out-Null
    Add-Footer $slide 8

    if (Test-Path $outputPath) {
        Remove-Item -LiteralPath $outputPath -Force
    }

    $presentation.SaveAs($outputPath, $ppSaveAsOpenXMLPresentation)
}
finally {
    $presentation.Close()
    $ppt.Quit()
}

Write-Output $outputPath
