using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Interfaces;

namespace RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentiController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;

        public AgentiController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpGet]
        public IActionResult GetAgenti()
        {
            return Ok(_agentRepository.GetAll());
        }

        [HttpGet]
        [Route("/api/najmladji")]
        public IActionResult GetAgentiByAge()
        {
            return Ok(_agentRepository.GetAllByAge());
        }

        [HttpGet]
        [Route("/api/ekstremi")]
        public IActionResult GetEkstremi()
        {
            return Ok(_agentRepository.GetEkstremi());
        }


        [HttpGet("{id}")]
        public IActionResult GetAgent(int id)
        {
            var agent = _agentRepository.GetById(id);

            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }

    }
}
