using Entities;
using SmartDoorServer.Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface ILogInDL
    {
        Task<LogInResponse> GetUser(string userName, string password);
    }
}