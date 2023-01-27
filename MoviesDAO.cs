using MySql.Data.MySqlClient;
using System.Data;

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

            try
            {
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

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
            return returnThese;
        }

        public int addOneMovie(Movie movie, Director director, Actor actor, List<string> genres)
        {
            int newRows = 0;
            try
            {
                AddMovies addMovies = new AddMovies();

                //connect to the mysql server
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                //define the sql statement to fetch all movies
                MySqlCommand command = new MySqlCommand("insert_movie_info", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@movie_title", movie.MovieTitle);
                command.Parameters.AddWithValue("@movie_year", movie.MovieYear);
                command.Parameters.AddWithValue("@imdb_rating", movie.MovieRating);
                command.Parameters.AddWithValue("actor_name", actor.Name);
                command.Parameters.AddWithValue("director_name", director.Name);
                foreach (string genre in genres)
                {
                    command.Parameters.AddWithValue("genre_name", genre);
                }

                newRows = command.ExecuteNonQuery();
                MessageBox.Show("Success! One new movie added!");
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
            return newRows;
        }


        public List<Actor> getActorForMovie(int id)
        {
            //start with an empty list
            List<Actor> returnThese = new List<Actor>();

            try
            {
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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return returnThese;
        }

        public List<Genre> getGenreForMovie(int genreID)
        {
            List<Genre> returnThese = new List<Genre>();

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return returnThese;
        }

        public List<Director> getDirectorForMovie(int directorID)
        {
            List<Director> returnThese = new List<Director>();

            try
            {
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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return returnThese;
        }

        internal int deleteMovie(int movieID)
        {
            int result = 0;
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM movies WHERE id = @movieID", connection);
                command.Parameters.AddWithValue("@movieID", movieID);

                result = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return result;
        }

        internal int updateMovie(Movie newMovie, int updateMovieID)
        {
            int updatedRows = 0;

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE movies SET title = @title, year = @year, imdb_rating = @imdb_rating WHERE id = @updateMovieID;", connection);

                command.Parameters.AddWithValue("@updateMovieID", updateMovieID);
                command.Parameters.AddWithValue("@title", newMovie.MovieTitle);
                command.Parameters.AddWithValue("@year", newMovie.MovieYear);
                command.Parameters.AddWithValue("@imdb_rating", newMovie.MovieRating);

                updatedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return updatedRows;
        }

    }

}
