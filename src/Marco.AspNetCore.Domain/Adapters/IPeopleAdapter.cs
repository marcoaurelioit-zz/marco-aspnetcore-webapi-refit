using Marco.AspNetCore.Domain.Models;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Domain.Adapters
{
    public interface IPeopleAdapter
    {
        /// <summary>
        /// Get people by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<People> GetByIdAsync(int id);
    }
}