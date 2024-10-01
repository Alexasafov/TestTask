using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TestTask.Infrastructure;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventContext;

        public HomeController(IEventRepository eventContext)
        {
            _eventContext = eventContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult SaveData([FromBody] List<EventData> data)
        {
            foreach (var item in data)
            {
                var eventData = new Event(JsonSerializer.Serialize(item));
                _eventContext.Add(eventData);
            }
            _eventContext.Save();
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
