using System;
using System.Threading.Tasks;
using BlogAppApplication.Common.Models;
using BlogAppApplication.Posts.Commands.CreatePost;
using BlogAppApplication.Posts.Commands.DeletePost;
using BlogAppApplication.Posts.Commands.FeaturePost;
using BlogAppApplication.Posts.Commands.PublishPost;
using BlogAppApplication.Posts.Commands.UnfeaturePost;
using BlogAppApplication.Posts.Commands.UnpublishPost;
using BlogAppApplication.Posts.Commands.UpdatePost;
using BlogAppApplication.Posts.Queries.GetPostById;
using BlogAppApplication.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PostBriefDto>>> GetPosts([FromQuery] GetPostsQuery query)
    {
        var result = await Mediator.Send(query);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetPostByIdQuery(id));

        if (!result.Succeeded)
            return NotFound(result.Errors);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreatePostCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(result.Data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdatePostCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await Mediator.Send(command);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await Mediator.Send(new DeletePostCommand(id));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/publish")]
    public async Task<ActionResult> Publish(Guid id)
    {
        var result = await Mediator.Send(new PublishPostCommand(id));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/unpublish")]
    public async Task<ActionResult> Unpublish(Guid id)
    {
        var result = await Mediator.Send(new UnpublishPostCommand(id));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/feature")]
    public async Task<ActionResult> Feature(Guid id)
    {
        var result = await Mediator.Send(new FeaturePostCommand(id));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}/unfeature")]
    public async Task<ActionResult> Unfeature(Guid id)
    {
        var result = await Mediator.Send(new UnfeaturePostCommand(id));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }
} 