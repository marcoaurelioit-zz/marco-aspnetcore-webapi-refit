using Refit;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Adapter.SwApi.Clients
{
    public interface IPeopleClient
    {
        [Get("/api/people/{id}")]
        Task<PeopleGetResult> GetByIdAsync(int id);
    }
}