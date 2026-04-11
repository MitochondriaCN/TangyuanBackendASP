using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Posts;

public class Post
{
    private Post()
    {
    }

    private Post(long id, long authorId, long categoryId, DateTime publishedAt, PostBody body, string[] imageGuids)
    {
        if (id <= 0)
            throw new DomainException("帖子ID非法");
        if (authorId <= 0)
            throw new DomainException("用户ID非法");
        if (categoryId <= 0)
            throw new DomainException("分类ID非法");

        Id = id;
        AuthorId = authorId;
        CategoryId = categoryId;
        PublishedAt = publishedAt;
        Body = body;
        ImageGuids = NormalizeImageGuids(imageGuids);
        IsVisible = true;
    }

    public long Id { get; private set; }

    public long AuthorId { get; private set; }

    public DateTime PublishedAt { get; private set; }

    public long CategoryId { get; private set; }

    public bool IsVisible { get; private set; }

    public PostBody Body { get; private set; } = null!;

    public string[] ImageGuids { get; private set; } = null!;

    public static Post Create(
        long id,
        long authorId,
        long categoryId,
        DateTime publishedAt,
        PostBody body,
        params string[] imageGuids)
    {
        return new Post(id, authorId, categoryId, publishedAt, body, imageGuids);
    }

    public void EnsureAuthoredBy(long userId)
    {
        if (AuthorId != userId)
            throw new DomainException("您不是帖子的作者");
    }

    public void Hide()
    {
        IsVisible = false;
    }

    private static string[] NormalizeImageGuids(IEnumerable<string> imageGuids)
    {
        var normalized = imageGuids
            .Where(guid => !string.IsNullOrWhiteSpace(guid))
            .Select(guid => guid.Trim())
            .ToArray();

        if (normalized.Length > 3)
            throw new DomainException("一条帖子最多只能有三张图片");

        foreach (var guid in normalized)
        {
            if (!Guid.TryParse(guid, out _))
                throw new DomainException("图片GUID格式错误");
        }

        return normalized;
    }
}