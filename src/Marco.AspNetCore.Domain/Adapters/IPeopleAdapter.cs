using Marco.AspNetCore.Domain.Models;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Domain.Adapters
{
    public interface IPeopleAdapter
    {
        Task<People> GetByIdAsync(int id);
    }
}