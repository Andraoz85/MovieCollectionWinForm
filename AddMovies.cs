namespace MovieCollectionWinForm
{
    public partial class AddMovies : Form
    {
        public AddMovies()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // add a new item to the database
                Movie movie = new Movie
                {
                    MovieTitle = txt_movieName.Text,
                    MovieYear = Int32.Parse(txt_releaseYear.Text),
                    MovieRating = float.Parse(txt_imdbRating.Text)
                };

                MoviesDAO moviesDAO = new MoviesDAO();
                int result = moviesDAO.addOneMovie(movie);
                MessageBox.Show(result + "new row(s) inserted");
            }
            catch (Exception ex)
            {
                // handle the exception
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void returnBtnClick_Click(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => this.Close();
            this.Hide();
            mainWindow.Show();
        }
    }
}
