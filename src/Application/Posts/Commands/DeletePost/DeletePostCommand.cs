using System;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Commands.DeletePost;

public record DeletePostCommand(Guid Id) : IRequest<Result>; 