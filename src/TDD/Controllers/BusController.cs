using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.EDB.Bus;
using Microsoft.Extensions.Options;
using Core.EDB.Configurations;

namespace TDD.Controllers
{
    [Route ("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IProduceMessage _produceMessage;
        private readonly IOptions<EDBConfigurations> _edbConfiguration;
        public BusController(IProduceMessage produceMessage, IOptions<EDBConfigurations> edbConfiguration)
        {
            _produceMessage = produceMessage;
            _edbConfiguration = edbConfiguration;
        }

        [HttpGet]
        [Route("/data")]
        public async Task<IActionResult> EmployeeData()
        {
            string data = "Hello";
            string topicName="FirstTopic";
            var result = await _produceMessage.CreateMessage(topicName, _edbConfiguration.Value , data);
            
            return result ? Content("created message") : Content("Failed");
        }
    }
}