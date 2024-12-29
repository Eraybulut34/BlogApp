using System;

namespace BlogAppDomain.Entities;

public class Newsletter
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool IsVerified { get; set; }
    public string VerificationToken { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
} 