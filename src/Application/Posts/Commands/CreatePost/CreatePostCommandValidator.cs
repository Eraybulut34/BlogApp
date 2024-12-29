using FluentValidation;

namespace BlogAppApplication.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Title is required and must not exceed 200 characters.");

        RuleFor(v => v.Content)
            .NotEmpty()
            .WithMessage("Content is required.");

        RuleFor(v => v.Summary)
            .MaximumLength(500)
            .When(v => !string.IsNullOrEmpty(v.Summary))
            .WithMessage("Summary must not exceed 500 characters.");

        RuleFor(v => v.TagIds)
            .Must(x => x.Count <= 5)
            .WithMessage("Maximum 5 tags are allowed.");

        RuleFor(v => v.TopicIds)
            .Must(x => x.Count <= 3)
            .WithMessage("Maximum 3 topics are allowed.");

        RuleFor(v => v.MediaIds)
            .Must(x => x.Count <= 10)
            .WithMessage("Maximum 10 media items are allowed.");
    }
} 