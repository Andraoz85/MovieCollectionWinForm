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
    }
}