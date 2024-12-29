using System;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Commands.FeaturePost;

public record FeaturePostCommand(Guid Id) : IRequest<Result>; 