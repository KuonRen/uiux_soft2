# 大阪紹介 UI/UX Assignment

大阪を「観光地」「歴史」「食べ物」の3つの視点から紹介するBlazor WebAssemblyアプリです。

## Features

- 3カテゴリ、各10件の記事を掲載
- topic画像をランダムに表示するhero
- hero画像クリックで対応記事を表示
- 記事モーダルと画像拡大プレビュー
- ライトモード / ダークモード切り替え
- GitHub Pages向けの自動デプロイ

## Tech Stack

- .NET 10
- Blazor WebAssembly
- C# / Razor
- HTML / CSS
- GitHub Actions / GitHub Pages

## Local Run

```powershell
dotnet run
```

表示されたローカルURLをブラウザで開きます。

## Publish

```powershell
dotnet publish uiux_soft2.csproj -c Release
```

GitHub Pagesへの公開は、`master` ブランチへのpush後にGitHub Actionsで実行されます。
