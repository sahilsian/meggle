using System.ComponentModel.DataAnnotations;

namespace CommunityService.Models;

public class Post
{
    [MaxLength(36)]
    public string id = Guid.NewGuid().ToString();
    [MaxLength(300)]
    public string Title { get; set; }
    [MaxLength(5000)]
    public string Content { get; set; }
    [MaxLength(36)]
    public string AskerId { get; set; }
    [MaxLength(300)]
    public string AskerName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public int ViewCount { get; set; }
    public List<string> TagSlugs { get; set; } = [];
    public bool HasAcceptedAnswer { get; set; }
    public int votes { get; set; }

}
    