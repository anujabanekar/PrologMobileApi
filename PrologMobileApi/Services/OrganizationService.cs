using PrologMobileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrologMobileApi.Services
{
    public class OrganizationService : IOrganizationService
    {
        public HttpClient _httpClient = new HttpClient();
        public async Task<List<Organization>> GetOrganizations()
        {
            var result = await _httpClient.GetAsync("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations");
            
            if(result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<List<Organization>>();
            }
            else
            {
                throw new Exception("No info found!");
            }
            
        }        

        public async Task<List<UserInfo>> GetUsersInfo(string id)
        {
            var result = await _httpClient.GetAsync($"https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/{id}/users");
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<List<UserInfo>>();
            }
            else
            {
                throw new Exception($"No info found for organization id {id}!");
            }
        }

        public async Task<List<UserPhoneInfo>> GetUserPhoneData(string orgId, string userId)
        {
            var result = await _httpClient.GetAsync($"https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/2/users/2/phones");
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<List<UserPhoneInfo>>();
            }
            else
            {
                throw new Exception($"No info found for organization id {orgId} and userId {userId}!");
            }
        }
    }
}
