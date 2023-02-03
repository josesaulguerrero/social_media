using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Posts;

public interface IDeletePostUseCase
{
    public Task<bool> DeletePostAsync(string id);
}