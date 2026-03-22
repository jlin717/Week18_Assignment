using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApiLab.API.Models;

namespace WebApiLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PeopleController : ControllerBase
    {
        private List<Person> People { get; } = new List<Person>();

        public PeopleController()
        {
            string jsonFile = System.IO.File.ReadAllText("./Resources/Dummy_Data.json");
            var peopleData = JsonSerializer.Deserialize<List<Person>>(
                jsonFile,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            if (peopleData != null)
            {
                People = peopleData;
            }
        }

        //Get: api/people
        [HttpGet]
        public ActionResult<List<Person>> GetPeople()
        {
            return Ok(People);
        }

        //Get: api/people/{id}
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}