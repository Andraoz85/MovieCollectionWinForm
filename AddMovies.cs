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
                MoviesDAO moviesDAO = new MoviesDAO();

                // add a new item to the database
                Movie movie = new Movie
                {
                    MovieTitle = txt_movieName.Text,
                    MovieYear = Int32.Parse(txt_releaseYear.Text),
                    MovieRating = float.Parse(txt_imdbRating.Text)
                };
                Actor actor = new Actor
                {
                    Name = txt_actorName.Text
                };
                Director director = new Director
                {
                    Name = txt_directorName.Text
                };
                List<string> genres = new List<string>();
                if (checkBoxAction.Checked) genres.Add(checkBoxAction.Text);
                if (checkBoxAdventure.Checked) genres.Add(checkBoxAdventure.Text);
                if (checkBoxAnimation.Checked) genres.Add(checkBoxAnimation.Text);
                if (checkBoxBiography.Checked) genres.Add(checkBoxBiography.Text);
                if (checkBoxComedy.Checked) genres.Add(checkBoxComedy.Text);
                if (checkBoxCrime.Checked) genres.Add(checkBoxCrime.Text);
                if (checkBoxDrama.Checked) genres.Add(checkBoxDrama.Text);
                if (checkBoxFantasy.Checked) genres.Add(checkBoxFantasy.Text);
                if (checkBoxHorror.Checked) genres.Add(checkBoxHorror.Text);
                if (checkBoxMusical.Checked) genres.Add(checkBoxMusical.Text);
                if (checkBoxRomance.Checked) genres.Add(checkBoxRomance.Text);
                if (checkBoxSciFi.Checked) genres.Add(checkBoxSciFi.Text);
                if (checkBoxThriller.Checked) genres.Add(checkBoxThriller.Text);
                if (checkBoxWar.Checked) genres.Add(checkBoxWar.Text);

                foreach (string genre in genres)
                {
                    int result = moviesDAO.addOneMovie(movie, director, actor, genres);
                    MessageBox.Show(result + " new row(s) inserted");
                }
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
