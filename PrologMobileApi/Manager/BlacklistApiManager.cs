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
            var organizationList = await _organizationService.GetOrganizations();
            try
            {
                foreach (var organization in organizationList)
                {
                    var userList = await _organizationService.GetUsersInfo(organization.Id);
                    var userData = new List<UserDetail>();
                    foreach (var user in userList)
                    {
                        var userPhoneInfo = await _organizationService.GetUserPhoneData(organization.Id, user.Id);
                        userData.Add(
                            new UserDetail
                            {
                                Id = user.Id,
                                Email = user.Email,
                                UserPhoneData = userPhoneInfo.Where(x => x.Blacklist).ToList()
                            });

                    }
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
                var test = ex;
            }

            return resultList;
        }
    }
}
