using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaService.Repositories;

namespace TriviaService.Managers
{
	public class TriviaManager : ITriviaManager
	{
		private ITriviaRepository TriviaRepository { get; set; }

		public TriviaManager(ITriviaRepository triviaRepository)
		{
			TriviaRepository = triviaRepository;
		}
			public IEnumerable<Trivia> GetAllTrivia()
			{
			IEnumerable<Trivia> trivia = TriviaRepository.SelectAllTrivia();
			return trivia;
			}
	}
}
