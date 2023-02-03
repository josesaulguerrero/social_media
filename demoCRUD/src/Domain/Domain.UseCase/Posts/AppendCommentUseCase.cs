using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Interfaces.Posts;
using Domain.Model.Entities.Gateway;

namespace Domain.UseCase.Posts;

public class AppendCommentUseCase : IAppendCommentUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public AppendCommentUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<Comment> AppendCommentAsync(string postId, Comment comment)
    {
        return _postsRepository.AppendComment(postId, comment);
    }
}