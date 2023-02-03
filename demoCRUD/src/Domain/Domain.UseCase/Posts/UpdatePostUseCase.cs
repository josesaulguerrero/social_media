using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Interfaces.Posts;
using Domain.UseCase.Gateways;

namespace Domain.UseCase.Posts;

public class UpdatePostUseCase : IUpdatePostUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public UpdatePostUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<Post> UpdatePostAsync(string id, Post changes)
    {
        return this._postsRepository.Update(id, changes);
    }
}