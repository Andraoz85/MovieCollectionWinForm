using MySql.Data.MySqlClient;

namespace MovieCollectionWinForm
{
    public partial class MainWindow : Form
    {
        BindingSource movieBindingSource = new BindingSource();
        BindingSource actorBindingSource = new BindingSource();
        BindingSource genreBindingSource = new BindingSource();
        BindingSource directorBindingSource = new BindingSource();

        Movie movies = new Movie();


        public MainWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void loadMovies_Click(object sender, EventArgs e)
        {
            MoviesDAO moviesDAO = new MoviesDAO();

            //connect the list to the grid view control
            movieBindingSource.DataSource = moviesDAO.getAllMovies();

            dataGridView1.DataSource = movieBindingSource;
        }

        private void searchMovies_click(object sender, EventArgs e)
        {
            MoviesDAO moviesDAO = new MoviesDAO();

            //connect the list to the grid view control
            movieBindingSource.DataSource = moviesDAO.searchTitles(textBox1.Text);

            dataGridView1.DataSource = movieBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var addMovies = new AddMovies();
            addMovies.Closed += (s, args) => this.Close();
            this.Hide();
            addMovies.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;

            MoviesDAO moviesDAO = new MoviesDAO();
            //connect the list to the grid view control
            actorBindingSource.DataSource = moviesDAO.getActorForMovie((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView2.DataSource = actorBindingSource;

            genreBindingSource.DataSource = moviesDAO.getGenreForMovie((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView3.DataSource = genreBindingSource;

            directorBindingSource.DataSource = moviesDAO.getDirectorForMovie((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView4.DataSource = directorBindingSource;
        }

        private void btn_deleteMovie_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView1.CurrentRow.Index;
            int movieID = (int)dataGridView1.Rows[rowClicked].Cells[0].Value;
            MessageBox.Show("Movie ID: " + movieID + " will be deleted");

            try
            {
                MoviesDAO moviesDAO = new MoviesDAO();
                int result = moviesDAO.deleteMovie(movieID);
                MessageBox.Show("Result " + result);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btn_updateMovie_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int rowClicked = dataGridView1.CurrentRow.Index;
                int updateMovieID = (int)dataGridView1.Rows[rowClicked].Cells[0].Value;
                MessageBox.Show("Movie ID: " + updateMovieID + " will be updated");

                Movie newMovie = new Movie();
                newMovie.ID = updateMovieID;
                newMovie.MovieTitle = dataGridView1.Rows[rowClicked].Cells[1].Value.ToString();
                newMovie.MovieYear = int.Parse(dataGridView1.Rows[rowClicked].Cells[2].Value.ToString());
                newMovie.MovieRating = float.Parse(dataGridView1.Rows[rowClicked].Cells[3].Value.ToString());

                try
                {
                    MoviesDAO moviesDAO = new MoviesDAO();
                    int result = moviesDAO.updateMovie(newMovie, updateMovieID);
                    MessageBox.Show("Result " + result);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update");
            }
        }
    }
}