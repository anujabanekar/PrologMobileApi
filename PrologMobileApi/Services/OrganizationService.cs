using Newtonsoft.Json;
using PrologMobileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace PrologMobileApi.Services
{
    public class OrganizationService : IOrganizationService
    {
        public HttpClient _httpClient = new HttpClient();
        public async Task<List<Organization>> GetOrganizations()
        {
            var response = await _httpClient.GetAsync("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations");

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Organization>>(jsonString);
                }
                else
                {
                    throw new Exception("No info found!");
                }
            }
            catch(Exception ex)
            {
                var test = ex;
                return null;
            }
            
            
        }        

        public async Task<List<User>> GetUsersInfo(string id)
        {
            var url = string.Format("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/{0}/users", id);
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var jsonString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(jsonString);
            }
            else
            {
                throw new Exception($"No info found for organization id {id}!");
            }
        }

        public async Task<List<UserPhone>> GetUserPhoneData(string orgId, string userId)
        {
            var url = string.Format("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/{0}/users/{1}/phones", orgId, userId);
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var jsonString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserPhone>>(jsonString);
            }
            else
            {
                throw new Exception($"No info found for organization id {orgId} and userId {userId}!");
            }
        }
    }
}
