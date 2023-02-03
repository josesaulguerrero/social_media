using System.Threading.Tasks;

using Domain.Model.Interfaces.Posts;
using Domain.UseCase.Gateways;

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