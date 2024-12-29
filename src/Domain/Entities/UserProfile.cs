using System;

namespace BlogAppDomain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string AvatarUrl { get; set; }
    public string CoverImageUrl { get; set; }
    public string Location { get; set; }
    public string Website { get; set; }
    public string TwitterUsername { get; set; }
    public string GithubUsername { get; set; }
    public string LinkedInUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
} 