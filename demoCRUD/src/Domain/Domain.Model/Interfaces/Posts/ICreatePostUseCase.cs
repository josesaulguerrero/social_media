using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Interfaces.Posts;

public interface ICreatePostUseCase
{
    public Task<Post> CreatePostAsync(Post post);
}