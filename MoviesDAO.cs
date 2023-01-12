using MySql.Data.MySqlClient;

namespace MovieCollectionWinForm
{
    internal class MoviesDAO
    {
        string connectionString =
            "datasource=localhost;port=3306;username=root;password=TMKVMAG7;database=mymoviedb;";

        public List<Movie> getAllMovies()
        {
            //start with an empty list
            List<Movie> returnThese = new List<Movie>();

            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //define the sql statement to fetch all movies
            MySqlCommand command = new MySqlCommand("SELECT * FROM movies", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Movie a = new Movie
                    {
                        ID = reader.GetInt32(0),
                        MovieTitle = reader.GetString(1),
                        MovieYear = reader.GetInt32(2),
                        MovieRating = reader.GetFloat(3)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();


            return returnThese;
        }


        public List<Movie> searchTitles(string searchTerm)
        {
            //start with an empty list
            List<Movie> returnThese = new List<Movie>();

            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string searchWildPhrase = "%" + searchTerm + "%";

            //define the sql statement to fetch all movies
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM movies WHERE title LIKE @search";
            command.Parameters.AddWithValue("@search", searchWildPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Movie a = new Movie
                    {
                        ID = reader.GetInt32(0),
                        MovieTitle = reader.GetString(1),
                        MovieYear = reader.GetInt32(2),
                        MovieRating = reader.GetFloat(3)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();


            return returnThese;
        }

    }

}
