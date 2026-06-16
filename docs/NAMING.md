# 命名規則・識別子一覧

このファイルは、後から識別子名を変更しやすくするための管理用メモです。
新しい重要な識別子を追加・変更した場合は、このファイルも更新してください。

---

## メソッド名

- `CopyArticleLinkAsync`：`Components/Pages/Home.razor`, 188行目
    ┗ 記事リンクのコピー結果を取得し、成功・失敗の表示状態を更新するメソッド。

---

## 重要な変数名

- `CopyLinkHref`：`Components/Pages/ArticleModal.razor`, 103行目
    ┗ 記事リンクコピー用に、ブラウザー側へ渡すコピー対象URLを保持するコンポーネントパラメータ。

---

## 外部公開される識別子名

- `window.appClipboard.copyText`：`wwwroot/index.html`, 213行目
    ┗ Clipboard API と textarea フォールバックを使い、記事リンク文字列をクリップボードへコピーするブラウザー側関数。
- `window.appClipboard.prepareCopy`：`wwwroot/index.html`, 216行目
    ┗ Blazor のクリック処理より前に、ブラウザーのユーザー操作タイミングでコピーを開始するブラウザー側関数。
- `window.appClipboard.getPreparedResult`：`wwwroot/index.html`, 229行目
    ┗ 事前に開始したコピー処理の結果を Blazor 側から取得するブラウザー側関数。
- `data-copy-text`：`Components/Pages/ArticleModal.razor`, 81行目
    ┗ コピー対象URLをJSイベントリスナーへ渡すためのDOM属性。