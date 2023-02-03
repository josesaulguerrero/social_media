using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Interfaces.Posts;

public interface IFindPostByIdUseCase
{
    public Task<Post> FindByIdAsync(string id);
}