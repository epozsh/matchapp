using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsController : ControllerBase
    {
        private readonly IMatchRepositoryClientService _oddRepositoryClient;

        public OddsController(IMatchRepositoryClientService oddRepositoryClient)
        {
            _oddRepositoryClient = oddRepositoryClient;
        }

        // GET: api/odds
        [HttpGet]
        public async Task<ActionResult<IList<MatchOddApiModel>>> Get()
        {
            try
            {
                var odds = await _oddRepositoryClient.MatchOddRepositoryServiceService.GetAllMatchOdds();
                return Ok(odds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/odds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchOddApiModel>> Get(int id)
        {
            try
            {
                var odd = await _oddRepositoryClient.MatchOddRepositoryServiceService.GetMatchOddById(id);
                return Ok(odd);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/odds
        [HttpPost]
        public async Task<ActionResult<MatchOddApiModel>> Post([FromBody] MatchOddAddApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var odd = await _oddRepositoryClient.MatchOddRepositoryServiceService.AddMatchOdd(model);
                return Ok(odd);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/odds/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MatchOddApiModel>> Put(int id, [FromBody] MatchOddApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var odd = await _oddRepositoryClient.MatchOddRepositoryServiceService.GetMatchOddById(id);
                if (odd == null)
                {
                    return NotFound();
                }

                if (model.ID == 0)
                {
                    model.ID = id;
                }

                var updatedMatch = await _oddRepositoryClient.MatchOddRepositoryServiceService.UpdateMatchOdd(model);
                return Ok(updatedMatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/odds/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var odd = await _oddRepositoryClient.MatchOddRepositoryServiceService.GetMatchOddById(id);
                if (odd == null)
                {
                    return NotFound();
                }

                var deleted = await _oddRepositoryClient.MatchOddRepositoryServiceService.DeleteMatchOdd(id);
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
