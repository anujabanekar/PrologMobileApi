using PrologMobileApi.Models;
using PrologMobileApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Manager
{
    public class BlacklistApiManager : IBlacklistApiManager
    {
        public readonly IOrganizationService _organizationService;
        public BlacklistApiManager(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task<List<OrganizationSummary>> GetOrganizationInfo()
        {
            var resultList = new List<OrganizationSummary>();            
            try
            {
                var organizationList = await _organizationService.GetOrganizations();
                foreach (var organization in organizationList)
                {                   
                    var userData = await GetUserDetails(organization.Id);
                    
                    resultList.Add(
                        new OrganizationSummary
                        {
                            Id = organization.Id,
                            Name = organization.Name,
                            Users = userData
                        });
                }

            }
            catch (Exception ex)
            {
                //add to logger
                return null;
            }

            return resultList;
        }

        private async Task<List<UserDetail>> GetUserDetails(string id)
        {
            var userData = new List<UserDetail>();
            var userList = await _organizationService.GetUsersInfo(id);
            
            foreach (var user in userList)
            {
                var userPhoneInfo = await _organizationService.GetUserPhoneData(id, user.Id);
                userData.Add(
                    new UserDetail
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserPhoneData = userPhoneInfo.Where(x => x.Blacklist).ToList()
                    });

            }
            return userData;
        }
    }
}
