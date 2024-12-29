using System;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Commands.PublishPost;

public record PublishPostCommand(Guid Id) : IRequest<Result>; 