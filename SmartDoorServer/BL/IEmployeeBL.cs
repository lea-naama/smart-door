using Entities.DTO;
using System.Threading.Tasks;

namespace BL
{
    public interface IEmployeeBL
    {
        Task<EmployeeDTO> GetEmployeeDetails(int id);
    }
}