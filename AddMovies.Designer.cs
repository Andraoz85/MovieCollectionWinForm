namespace MovieCollectionWinForm
{
    partial class AddMovies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_imdbRating = new System.Windows.Forms.TextBox();
            this.txt_releaseYear = new System.Windows.Forms.TextBox();
            this.txt_movieName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.returnBtnClick = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_imdbRating);
            this.groupBox1.Controls.Add(this.txt_releaseYear);
            this.groupBox1.Controls.Add(this.txt_movieName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Movie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "IMDB Rating";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_imdbRating
            // 
            this.txt_imdbRating.Location = new System.Drawing.Point(166, 141);
            this.txt_imdbRating.Name = "txt_imdbRating";
            this.txt_imdbRating.Size = new System.Drawing.Size(64, 27);
            this.txt_imdbRating.TabIndex = 6;
            // 
            // txt_releaseYear
            // 
            this.txt_releaseYear.Location = new System.Drawing.Point(166, 93);
            this.txt_releaseYear.Name = "txt_releaseYear";
            this.txt_releaseYear.Size = new System.Drawing.Size(64, 27);
            this.txt_releaseYear.TabIndex = 5;
            // 
            // txt_movieName
            // 
            this.txt_movieName.Location = new System.Drawing.Point(166, 45);
            this.txt_movieName.Name = "txt_movieName";
            this.txt_movieName.Size = new System.Drawing.Size(266, 27);
            this.txt_movieName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Release Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Ttitle";
            // 
            // returnBtnClick
            // 
            this.returnBtnClick.Location = new System.Drawing.Point(638, 390);
            this.returnBtnClick.Name = "returnBtnClick";
            this.returnBtnClick.Size = new System.Drawing.Size(150, 48);
            this.returnBtnClick.TabIndex = 1;
            this.returnBtnClick.Text = "<-- Return";
            this.returnBtnClick.UseVisualStyleBackColor = true;
            this.returnBtnClick.Click += new System.EventHandler(this.returnBtnClick_Click);
            // 
            // AddMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.returnBtnClick);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddMovies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMovies";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button button1;
        private TextBox txt_imdbRating;
        private TextBox txt_releaseYear;
        private TextBox txt_movieName;
        private Label label2;
        private Label label3;
        private Button returnBtnClick;
    }
}