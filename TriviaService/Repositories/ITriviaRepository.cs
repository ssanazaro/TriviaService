using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaService.Repositories
{
	public interface ITriviaRepository
	{
		public IEnumerable<Trivia> SelectAllTrivia();
	}
}
