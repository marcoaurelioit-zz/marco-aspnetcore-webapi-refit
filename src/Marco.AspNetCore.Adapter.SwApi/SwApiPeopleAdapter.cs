using AutoMapper;
using Marco.AspNetCore.Adapter.SwApi.Clients;
using Marco.AspNetCore.Domain.Adapters;
using Marco.AspNetCore.Domain.Models;
using Refit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Adapter.SwApi
{
    internal class SwApiPeopleAdapter : IPeopleAdapter
    {
        private readonly IPeopleClient _peopleClient;

        public SwApiPeopleAdapter(IPeopleClient peopleClient)
        {
            _peopleClient = peopleClient ?? throw new ArgumentNullException(nameof(peopleClient));
        }

        public async Task<People> GetByIdAsync(int id)
        {
            try
            {
                var peopleGetResult = await _peopleClient.GetByIdAsync(id);
                return Mapper.Map<PeopleGetResult, People>(peopleGetResult);
            }
            catch (ApiException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    return null;

                throw;
            }
        }
    }
}