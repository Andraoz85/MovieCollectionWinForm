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

            //define the sql statement to fetch all movies
            MySqlCommand command = new MySqlCommand("SELECT * FROM movies", connection);
            try
            {
                connection.Open();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




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
                    Movie m = new Movie
                    {
                        ID = reader.GetInt32(0),
                        MovieTitle = reader.GetString(1),
                        MovieYear = reader.GetInt32(2),
                        MovieRating = reader.GetFloat(3)
                    };
                    returnThese.Add(m);
                }
            }
            connection.Close();


            return returnThese;
        }

        public int addOneMovie(Movie movie)
        {
            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //define the sql statement to fetch all movies
            MySqlCommand command = new MySqlCommand("INSERT INTO movies (title,year,imdb_rating) VALUES (@movietitle, @releaseyear, @imdbrating)", connection);

            command.Parameters.AddWithValue("@movietitle", movie.MovieTitle);
            command.Parameters.AddWithValue("@releaseyear", movie.MovieYear);
            command.Parameters.AddWithValue("@imdbrating", movie.MovieRating);

            int newRows = command.ExecuteNonQuery();
            connection.Close();


            return newRows;
        }


        public List<Actor> getActorForMovie(int id)
        {
            //start with an empty list
            List<Actor> returnThese = new List<Actor>();

            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM mha WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Actor actor = new Actor
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    returnThese.Add(actor);
                }
            }
            connection.Close();


            return returnThese;
        }

        public List<Genre> getGenreForMovie(int genreID)
        {
            //start with an empty list
            List<Genre> returnThese = new List<Genre>();

            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //define the sql statement to fetch all genres
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM movie_genres WHERE id = @genreID";
            command.Parameters.AddWithValue("@genreID", genreID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Genre g = new Genre
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    returnThese.Add(g);
                }
            }
            connection.Close();


            return returnThese;
        }

        public List<Director> getDirectorForMovie(int directorID)
        {
            //start with an empty list
            List<Director> returnThese = new List<Director>();

            //connect to the mysql server
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //define the sql statement to fetch all movies
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM movie_directors WHERE id = @directorID";
            command.Parameters.AddWithValue("@directorID", directorID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Director d = new Director
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    returnThese.Add(d);
                }
            }
            connection.Close();


            return returnThese;
        }
    }

}
