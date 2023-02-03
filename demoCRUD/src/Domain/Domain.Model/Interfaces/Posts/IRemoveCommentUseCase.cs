using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Posts;

public interface IRemoveCommentUseCase
{
    public Task<bool> RemoveCommentAsync(string postId, string commentId);
}