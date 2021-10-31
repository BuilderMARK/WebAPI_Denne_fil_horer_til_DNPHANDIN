using System.Threading.Tasks;

namespace RestServer.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}