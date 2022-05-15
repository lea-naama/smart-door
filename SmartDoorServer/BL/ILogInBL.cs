using Entities;
using SmartDoorServer.Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface ILogInBL
    {
        Task<LogInResponse> GetUser(string userName, string password);
    }
}