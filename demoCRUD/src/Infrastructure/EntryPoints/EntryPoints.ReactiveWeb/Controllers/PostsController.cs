using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Interfaces.Posts;

using EntryPoints.ReactiveWeb.Base;

using Microsoft.AspNetCore.Mvc;

namespace EntryPoints.ReactiveWeb.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/posts")]
[Produces("application/json")]
public class PostsController : AppControllerBase<PostsController>
{
    private readonly ICreatePostUseCase _createPostUseCase;
    private readonly IFindAllPostsUseCase _findAllPostsUseCase;
    private readonly IFindPostByIdUseCase _findPostByIdUseCase;
    private readonly IUpdatePostUseCase _updatePostUseCase;
    private readonly IDeletePostUseCase _deletePostUseCase;
    private readonly IAppendCommentUseCase _appendCommentUseCase;
    private readonly IRemoveCommentUseCase _removeCommentUseCase;

    public PostsController(ICreatePostUseCase createPostUseCase, IFindAllPostsUseCase findAllPostsUseCase, IFindPostByIdUseCase findPostByIdUseCase, IUpdatePostUseCase updatePostUseCase, IDeletePostUseCase deletePostUseCase, IAppendCommentUseCase appendCommentUseCase, IRemoveCommentUseCase removeCommentUseCase)
    {
        _createPostUseCase = createPostUseCase;
        _findAllPostsUseCase = findAllPostsUseCase;
        _findPostByIdUseCase = findPostByIdUseCase;
        _updatePostUseCase = updatePostUseCase;
        _deletePostUseCase = deletePostUseCase;
        _appendCommentUseCase = appendCommentUseCase;
        _removeCommentUseCase = removeCommentUseCase;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _findAllPostsUseCase.FindAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Post> GetAllPostsAsync([FromRoute(Name = "id")] string postId)
    {
        return await _findPostByIdUseCase.FindByIdAsync(postId);
    }

    [HttpPost("create")]
    public async Task<Post> CreatePostAsync([FromBody] Post post)
    {
        return await _createPostUseCase.CreatePostAsync(post);
    }

    [HttpPut("{id}/update")]
    public async Task<Post> UpdatePostAsync([FromRoute(Name = "id")] string postId, [FromBody] Post post)
    {
        return await _updatePostUseCase.UpdatePostAsync(postId, post);
    }

    [HttpDelete("{id}/delete")]
    public async Task<bool> DeletePostAsync([FromRoute(Name = "id")] string postId)
    {
        return await _deletePostUseCase.DeletePostAsync(postId);
    }

    [HttpPost("{id}/comments/append")]
    public async Task<Comment> AppendCommentAsync([FromRoute(Name = "id")] string postId, [FromBody] Comment comment)
    {
        return await _appendCommentUseCase.AppendCommentAsync(postId, comment);
    }

    [HttpPost("{postId}/comments/{commentId}/remove")]
    public async Task<bool> RemoveCommentAsync([FromRoute(Name = "postId")] string postId, [FromRoute(Name = "commentId")] string commentId)
    {
        return await _removeCommentUseCase.RemoveCommentAsync(postId, commentId);
    }
}