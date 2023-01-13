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
            // add a new item to the database
            Movie movie = new Movie
            {
                MovieTitle = txt_movieName.Text,
                MovieYear = Int32.Parse(txt_releaseYear.Text),
                MovieRating = float.Parse(txt_releaseYear.Text)
            };

            MoviesDAO moviesDAO = new MoviesDAO();
            int result = moviesDAO.addOneMovie(movie);
            MessageBox.Show(result + "new row(s) inserted");
        }
    }
}
