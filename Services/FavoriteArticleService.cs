using uiux_soft2.Models;

namespace uiux_soft2.Services;

public sealed class FavoriteArticleService
{
    private readonly Dictionary<string, FavoriteArticleItem> articleLookup = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> favoriteIds = new(StringComparer.OrdinalIgnoreCase);

    public event Action? Changed;
    public event Action? ModalVisibilityChanged;

    public bool IsFavoriteModalOpen { get; private set; }
    private bool canOpenSecretRoute;

    public IReadOnlyList<FavoriteArticleItem> Favorites =>
        favoriteIds
            .Select(id => articleLookup.GetValueOrDefault(id))
            .Where(item => item is not null)
            .Select(item => item!)
            .OrderBy(item => item.TopicTitle)
            .ThenBy(item => item.Title)
            .ToList();

    public void RegisterTopics(IEnumerable<TopicItem> topics) {
        foreach (var topic in topics) {
            foreach (var article in topic.Articles) {
                articleLookup[article.Id] = new FavoriteArticleItem {
                    Id = article.Id,
                    Title = article.Title,
                    TopicTitle = topic.Title
                };
            }
        }

        Changed?.Invoke();
    }

    public bool IsFavorite(string articleId) {
        return favoriteIds.Contains(articleId);
    }

    public IReadOnlyList<string> GetFavoriteIds() {
        return favoriteIds.OrderBy(id => id).ToList();
    }

    public void RestoreFavorites(IEnumerable<string> articleIds) {
        favoriteIds.Clear();

        foreach (var articleId in articleIds) {
            if (!string.IsNullOrWhiteSpace(articleId)) {
                favoriteIds.Add(articleId);
            }
        }

        Changed?.Invoke();
    }

    public bool RemoveFavorite(string articleId) {
        if (!favoriteIds.Remove(articleId)) {
            return false;
        }

        Changed?.Invoke();
        return true;
    }

    public void SetFavoriteModalOpen(bool isOpen) {
        if (IsFavoriteModalOpen == isOpen) {
            return;
        }

        IsFavoriteModalOpen = isOpen;
        ModalVisibilityChanged?.Invoke();
    }

    public void GrantSecretRouteAccess() {
        canOpenSecretRoute = true;
    }

    public bool ConsumeSecretRouteAccess() {
        if (!canOpenSecretRoute) {
            return false;
        }

        canOpenSecretRoute = false;
        return true;
    }

    public void ToggleFavorite(TopicItem topic, TopicArticle article) {
        articleLookup[article.Id] = new FavoriteArticleItem {
            Id = article.Id,
            Title = article.Title,
            TopicTitle = topic.Title
        };

        if (!favoriteIds.Add(article.Id)) {
            favoriteIds.Remove(article.Id);
        }

        Changed?.Invoke();
    }
}
