﻿using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Interfaces.Posts;
using Domain.UseCase.Gateways;

namespace Domain.UseCase.Posts;

public class CreatePostUseCase : ICreatePostUseCase
{
    private readonly IPostsRepositoryGateway _postsRepository;

    public CreatePostUseCase(IPostsRepositoryGateway postsRepositoryGateway)
    {
        _postsRepository = postsRepositoryGateway;
    }

    public Task<Post> CreatePostAsync(Post post)
    {
        return this._postsRepository.SavePostAsync(post);
    }
}