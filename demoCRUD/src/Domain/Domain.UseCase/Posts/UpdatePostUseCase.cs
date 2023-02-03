using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Domain.Model.Interfaces.Posts;

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