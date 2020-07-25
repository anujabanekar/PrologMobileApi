using PrologMobileApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrologMobileApi.Services
{
    public interface IOrganizationService
    {
        /*
         * Returns all the organizations with authorized funds in the system
         */
        Task<List<Organization>> GetOrganizations();

        /*
         * Returns all the registered users for the provided organization
         */
        Task<List<User>> GetUsersInfo(string id);

        /*
         * Returns all the phones associated with a user and their Blacklist status
         */
        Task<List<UserPhone>> GetUserPhoneData(string orgId, string userId);

    }
}