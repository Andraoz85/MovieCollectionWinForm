namespace MovieCollectionWinForm
{
    public partial class MainWindow : Form
    {
        BindingSource movieBindingSource = new BindingSource();
        BindingSource actorBindingSource = new BindingSource();
        BindingSource genreBindingSource = new BindingSource();
        BindingSource directorBindingSource = new BindingSource();


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


    }
}