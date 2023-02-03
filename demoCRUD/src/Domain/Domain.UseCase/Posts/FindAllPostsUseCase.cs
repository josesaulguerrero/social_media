using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Interfaces.Posts;
using Domain.UseCase.Gateways;

namespace Domain.UseCase.Posts;

public class FindAllPostsUseCase : IFindAllPostsUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public FindAllPostsUseCase(IPostsRepositoryGateway postsRepository)
    {
        _postsRepository = postsRepository;
    }

    public Task<IEnumerable<Post>> FindAllAsync()
    {
        return this._postsRepository.FindAll();
    }
}