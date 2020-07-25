using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrologMobileApi.Manager;
using PrologMobileApi.Mapper;
using PrologMobileApi.Models;

namespace PrologMobileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgSummaryApiController : ControllerBase
    {
        public readonly IBlacklistApiManager _blacklistApiManager;
        public OrgSummaryApiController(IBlacklistApiManager blacklistApiManager)
        {
            _blacklistApiManager = blacklistApiManager;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<OrgSummaryDomainModel>>> GetAsync()
        {
            var organizationSummary = await _blacklistApiManager.GetOrganizationInfo();

            var domainModel = organizationSummary != null ? OrganizationSummaryMapper.BuildMapper(organizationSummary) : null;
            return domainModel;
        }

       
    }
}
