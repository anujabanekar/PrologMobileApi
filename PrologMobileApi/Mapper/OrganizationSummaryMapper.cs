using PrologMobileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Mapper
{
    public class OrganizationSummaryMapper
    {
        public static List<OrganizationSummaryDomainModel> BuildMapper(List<OrganizationSummary> organizationSummaries)
        {
            var domainModel = new List<OrganizationSummaryDomainModel>();
            foreach(var summary in organizationSummaries)
            {
                domainModel.Add(new OrganizationSummaryDomainModel
                {
                    Id = summary.Id,
                    Name = summary.Name,
                    BlackListTotal = summary.Users.Count(),
                    TotalCount = summary.Users.Select(x => x.UserPhoneData.Count).FirstOrDefault(),
                    Users = GetSummaryDetails(summary.Users)                    
                });
            }
            return domainModel;
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
                    PhoneCount = user.UserPhoneData.Count()
                });
            }
            return userSummary;
        }
    }
}
