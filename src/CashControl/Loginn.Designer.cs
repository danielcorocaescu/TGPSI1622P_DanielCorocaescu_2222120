namespace CashControl
{
    partial class Loginn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginn));
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            textBox5 = new TextBox();
            pictureBox6 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Purple;
            linkLabel1.Location = new Point(58, 261);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(205, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Don´t have an account? Register now!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(27, 192);
            button1.Name = "button1";
            button1.Size = new Size(268, 66);
            button1.TabIndex = 27;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(78, 152);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(174, 23);
            textBox5.TabIndex = 26;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.MediumPurple;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(27, 134);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(45, 41);
            pictureBox6.TabIndex = 25;
            pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.MediumPurple;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(27, 91);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 37);
            pictureBox3.TabIndex = 24;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(127, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 63);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 23);
            textBox1.TabIndex = 22;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // Loginn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(307, 446);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(linkLabel1);
            Name = "Loginn";
            Text = "CashControl";
            Load += Loginn_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkLabel1;
        private Button button1;
        private TextBox textBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private TextBox textBox1;
    }
}