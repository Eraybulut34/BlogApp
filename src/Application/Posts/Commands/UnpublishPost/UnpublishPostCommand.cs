using System;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Commands.UnpublishPost;

public record UnpublishPostCommand(Guid Id) : IRequest<Result>; 