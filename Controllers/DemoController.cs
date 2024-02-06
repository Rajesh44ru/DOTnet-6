using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace TestWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController:ControllerBase
    {
        private readonly IMyLogger _myLogger;
        private readonly ILogger<DemoController> _logger;
        public DemoController(IMyLogger myLogger, ILogger<DemoController> logger)
        {
            //_myLogger = new LogToDB();
            _myLogger = myLogger;
            _logger = logger;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            //_myLogger.Log("Index Method Started");
            _logger.LogTrace("Log trace");
            _logger.LogDebug("Log Debug");
            _logger.LogInformation("Log INformation");
            _logger.LogWarning("Log warning");
            _logger.LogError("Log Error");
            _logger.LogCritical("Log critical");
            return Ok();
        }
    }
}
