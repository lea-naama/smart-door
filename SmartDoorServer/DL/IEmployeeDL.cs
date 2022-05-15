using Entities.DTO;
using SmartDoorServer.Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IEmployeeDL
    {
        Task<EmployeeDTO> GetEmployeeDetails(int id);
    }
}