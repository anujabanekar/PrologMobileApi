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
    public class BlackListApiController : ControllerBase
    {
        public readonly IBlacklistApiManager _blacklistApiManager;
        public BlackListApiController(IBlacklistApiManager blacklistApiManager)
        {
            _blacklistApiManager = blacklistApiManager;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<OrganizationSummaryDomainModel>>> GetAsync()
        {
            var organizationSummary = await _blacklistApiManager.GetOrganizationInfo();

            var domainModel = OrganizationSummaryMapper.BuildMapper(organizationSummary);
            return domainModel;
        }

       
    }
}
