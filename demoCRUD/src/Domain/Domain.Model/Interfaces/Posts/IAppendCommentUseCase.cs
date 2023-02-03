using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Interfaces.Posts;

public interface IAppendCommentUseCase
{
    public Task<Comment> AppendCommentAsync(string postId, Comment comment);
}