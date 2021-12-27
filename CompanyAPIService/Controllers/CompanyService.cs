using CompanyAPIService.BusinessLogic;
using CompanyAPIService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyService : Controller
    {
        [HttpPost(Name = "VerifyCompanyData")]
        public async  Task<IActionResult> Validate(Company company)
        {
            string result = String.Empty;
            result = Helper.Instance.ValidateCompany(company);
            if(!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}
