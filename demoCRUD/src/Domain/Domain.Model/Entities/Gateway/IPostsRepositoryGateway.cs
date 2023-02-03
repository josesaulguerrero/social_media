using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Entities.Gateway;

public interface IPostsRepositoryGateway
{
    public Task<Comment> AppendComment(string postId, Comment comment);

    public Task<bool> Delete(string id);

    public Task<IEnumerable<Post>> FindAll();

    public Task<Post> FindPostById(string postId);

    public Task<bool> RemoveComment(string postId, string commentId);

    public Task<Post> SavePostAsync(Post post);

    public Task<Post> Update(string id, Post changes);
}