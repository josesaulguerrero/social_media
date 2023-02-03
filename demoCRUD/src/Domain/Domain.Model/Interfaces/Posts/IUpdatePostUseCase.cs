using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Interfaces.Posts;

public interface IUpdatePostUseCase
{
    public Task<Post> UpdatePostAsync(string id, Post changes);
}