using PrologMobileApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrologMobileApi.Manager
{
    public interface IBlacklistApiManager
    {
        Task<List<OrganizationSummary>> GetOrganizationInfo();
    }
}