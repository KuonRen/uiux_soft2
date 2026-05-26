namespace uiux.Models;

public class TopicItem
{
    public string IndexLabel { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string IconType { get; set; } = ""; // "spots", "history", "food"
    public string GradientClass { get; set; } = "";
    public List<TopicArticle> Articles { get; set; } = new();
}

public class TopicArticle
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Body { get; set; } = "";
    public string ImagePath { get; set; } = "";
}
