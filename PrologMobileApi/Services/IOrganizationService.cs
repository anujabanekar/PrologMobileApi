using PrologMobileApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrologMobileApi.Services
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizations();
        Task<List<User>> GetUsersInfo(string id);

        Task<List<UserPhone>> GetUserPhoneData(string orgId, string userId);

    }
}