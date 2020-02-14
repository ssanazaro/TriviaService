using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaService.Managers
{
	public interface ITriviaManager
	{
		public IEnumerable<Trivia> GetAllTrivia();
	}
}
