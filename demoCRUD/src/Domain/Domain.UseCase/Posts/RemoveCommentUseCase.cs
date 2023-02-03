using System.Threading.Tasks;

using Domain.Model.Entities.Gateway;
using Domain.Model.Interfaces.Posts;

namespace Domain.UseCase.Posts;

public class RemoveCommentUseCase : IRemoveCommentUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public RemoveCommentUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<bool> RemoveCommentAsync(string postId, string commentId)
    {
        return _postsRepository.RemoveComment(postId, commentId);
    }
}