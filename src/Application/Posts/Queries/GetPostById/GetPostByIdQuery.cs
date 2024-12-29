using System;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Queries.GetPostById;

public record GetPostByIdQuery(Guid Id) : IRequest<Result<PostDto>>; 