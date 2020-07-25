using PrologMobileApi.Models;
using System.Collections.Generic;
using System.Linq;
namespace PrologMobileApi.Mapper
{
    public class OrganizationSummaryMapper
    {
        public static List<OrgSummaryDomainModel> BuildMapper(List<OrganizationSummary> organizationSummaries)
        {
            var domainModel = new List<OrgSummaryDomainModel>();
            foreach(var summary in organizationSummaries)
            {
                domainModel.Add(new OrgSummaryDomainModel
                {
                    Id = summary.Id,
                    Name = summary.Name,
                    BlackListTotal = summary.Users.Count(),
                    TotalCount = summary.Users != null ? GetTotalCount(summary.Users) : 0,
                    Users = summary.Users != null ? GetSummaryDetails(summary.Users) : null
                }); 
            }
            return domainModel;
        }

        private static int GetTotalCount(List<UserDetail> users)
        {
            var count = 0;
            foreach (var user in users)
            {
                count += user.UserPhoneData.Count();
            }
            return count;
        }

        private static List<UserSummary> GetSummaryDetails(List<UserDetail> users)
        {
            var userSummary = new List<UserSummary>();
            foreach(var user in users)
            {
                userSummary.Add(new UserSummary
                {
                    Id = user.Id,
                    Email = user.Email,
                    PhoneCount = user.UserPhoneData != null ? user.UserPhoneData.Count() : 0
                });
            }
            return userSummary;
        }
    }
}
