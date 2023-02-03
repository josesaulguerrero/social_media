using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Domain.Model.Interfaces.Posts;

namespace Domain.UseCase.Posts;

public class FindPostByIdUseCase : IFindPostByIdUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public FindPostByIdUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<Post> FindByIdAsync(string id)
    {
        return this._postsRepository.FindPostById(id);
    }
}