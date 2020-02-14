using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaService.Properties;

namespace TriviaService.Repositories
{
	public class TriviaRepository : ITriviaRepository
	{
		public IEnumerable<Trivia> SelectAllTrivia()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			builder.Server = "localhost";
			builder.Port = 3306;
			builder.Database = "sys";
			builder.UserID = "root";
			builder.Password = "Playthegame11!!";

			using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))

			{
				using (MySqlCommand command = new MySqlCommand(Resource.SelectAllTrivia, connection))
				{
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
						}

					}
				}
			}
			return null;
		}
	}
}
