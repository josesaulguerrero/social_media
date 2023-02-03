using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Model.Entities;

namespace Domain.Model.Interfaces.Posts;

public interface IFindAllPostsUseCase
{
    public Task<IEnumerable<Post>> FindAllAsync();
}