using WHCH.Api.Extensions;
using WHCH.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WHCH.Api.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHCH.Api.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ILogger _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 测试日志
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Logger()
        {

            //Sbwl64302391
            //string password = CryptoClass.RSAEncryption("Sbwl64302391");



            return Ok();
        }
    }
}
