namespace MovieCollectionWinForm
{
    public partial class Form1 : Form
    {
        BindingSource movieBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void loadMovies_Click(object sender, EventArgs e)
        {
            MoviesDAO moviesDAO = new MoviesDAO();
            movieBindingSource.DataSource = moviesDAO.getAllMovies();

            dataGridView1.DataSource = movieBindingSource;
        }
    }
}