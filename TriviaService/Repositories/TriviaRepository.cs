using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
			builder.Port = 3306 ;
			builder.Database = "sys";
			builder.UserID = "root";
			builder.Password = "Playthegame11!!";


			using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
			//MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
			{
				List<Trivia> list = new List<Trivia>();
				connection.Open();
				using (MySqlCommand command = new MySqlCommand(Resource.SelectAllTrivia, connection))
				{
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Trivia row = new Trivia();
							row.QuestionID = reader["QuestionID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["QuestionID"]);
							row.Question = reader["Question"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Question"]);
							row.CorrectAnswer = reader["CorrectAnswer"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CorrectAnswer"]);
							row.Option1 = reader["Option1"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Option1"]);
							row.Option2 = reader["Option2"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Option2"]);
							row.Option3 = reader["Option3"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Option3"]);
							row.Option4 = reader["Option4"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Option4"]);
							list.Add(row);
						}
						return list;
						}

					}
				}
			}
		}
	}
