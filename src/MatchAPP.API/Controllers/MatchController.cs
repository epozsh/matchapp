using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchAPP.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOriginCors")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepositoryClientService _matchRepositoryClient;

        public MatchController(IMatchRepositoryClientService matchRepositoryClient)
        {
            _matchRepositoryClient = matchRepositoryClient;
        }

        // GET: api/match
        [HttpGet]
        public async Task<ActionResult<IList<MatchApiModel>>> Get()
        {
            try
            {
                var matches = await _matchRepositoryClient.MatchRepositoryService.GetAllMatches();
                return Ok(matches);
            }
            catch (Exception ex)
                {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchApiModel>> Get(int id)
        {
            try
            {
                var match = await _matchRepositoryClient.MatchRepositoryService.GetMatchById(id);
                return Ok(match);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/match
        [HttpPost]
        public async Task<ActionResult<MatchApiModel>> Post([FromBody] MatchAddApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var match = await _matchRepositoryClient.MatchRepositoryService.AddMatch(model);
                return Ok(match);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/match/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MatchApiModel>> Put(int id, [FromBody] MatchApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var match = await _matchRepositoryClient.MatchRepositoryService.GetMatchById(id);
                if (match == null)
                {
                    return NotFound();
                }

                if(model.ID == 0)
                {
                    model.ID = id;
                }

                var updatedMatch = await _matchRepositoryClient.MatchRepositoryService.UpdateMatch(model);
                return Ok(updatedMatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/match/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var match = await _matchRepositoryClient.MatchRepositoryService.GetMatchById(id);
                if (match == null)
                {
                    return NotFound();
                }

                var deleted = await _matchRepositoryClient.MatchRepositoryService.DeleteMatch(id);
                if (deleted)
                {
                    return Ok();
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
