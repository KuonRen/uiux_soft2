# 大阪紹介 UI/UX Assignment

大阪を「観光地」「歴史」「食べ物」の3つの視点から紹介する Blazor WebAssembly アプリです。

## 概要

- 3カテゴリ、各10件の記事を掲載
- トップ画面にランダムなトピック画像を表示
- トピックカードから記事モーダルを表示
- 記事ごとの直接URLに対応
- 存在しない記事URLはNot Foundページへ遷移
- 記事画像の拡大プレビュー
- ライトモード / ダークモード切り替え
- GitHub Pages向けの自動デプロイ

## 技術構成

- .NET 10
- Blazor WebAssembly
- wasm-tools
- C# / Razor
- HTML / CSS
- JSON data
- GitHub Actions / GitHub Pages

## データ構成

記事データは `wwwroot/data/osaka-topics.json` で管理しています。

各記事は `id` を持ち、URLにはこの `id` が使われます。

例:

```text
/article/dotonbori
/article/osaka-air-raid
/article/takoyaki
```

画像ファイル名を変更してもURLが変わらないように、記事IDは画像名から自動生成せず、JSON上で明示しています。

## ローカル実行

```powershell
dotnet run
```

表示されたローカルURLをブラウザで開きます。

## ビルド

```powershell
dotnet build
```

## Publish

初回のみ、Release publishの最適化に使う `wasm-tools` をインストールします。

```powershell
dotnet workload install wasm-tools
```

```powershell
dotnet publish uiux_soft2.csproj -c Release
```

## GitHub Pages

`master` ブランチへpushすると、GitHub ActionsでBlazor WebAssemblyをpublishし、GitHub Pagesへデプロイします。

workflowでは `wasm-tools` をインストールしてからpublishし、`index.html` の `<base href="/">` を `/uiux_soft2/` に置き換え、SPA fallback用に `404.html` を生成します。

## 主なファイル

- `Components/Pages/Home.razor`: トップ画面、記事モーダル、記事URL処理
- `Components/Pages/NotFound.razor`: 存在しない記事・ページの遷移先
- `Services/OsakaDataService.cs`: JSONデータ読み込み
- `wwwroot/data/osaka-topics.json`: カテゴリと記事本文
- `wwwroot/app.css`: グローバルテーマ
- `Components/Pages/Home.razor.css`: トップ画面とモーダルのスタイル
