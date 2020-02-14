using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TriviaService.Managers;

namespace TriviaService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TriviaController : ControllerBase
	{
		private ITriviaManager TriviaManager { get; set; }

		public TriviaController(ITriviaManager triviaManager)
		{
			TriviaManager = triviaManager;
		}

		[HttpGet("")]
		//[Route("GetTrivia")]
		[ProducesResponseType(typeof(IEnumerable<Trivia>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetTriviaQuestion()
		{
			try
			{
				IEnumerable<Trivia> trivia = TriviaManager.GetAllTrivia();

				if (trivia == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(trivia);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
