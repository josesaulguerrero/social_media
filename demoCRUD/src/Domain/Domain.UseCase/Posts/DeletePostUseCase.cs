using System.Threading.Tasks;

using Domain.Model.Entities.Gateway;
using Domain.Model.Interfaces.Posts;

namespace Domain.UseCase.Posts;

public class DeletePostUseCase : IDeletePostUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public DeletePostUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<bool> DeletePostAsync(string id)
    {
        return _postsRepository.Delete(id);
    }
}