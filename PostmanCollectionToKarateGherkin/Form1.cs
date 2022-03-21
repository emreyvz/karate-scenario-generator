using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostmanCollectionToKarateGherkin
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private string collectionPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitType.SelectedIndex = 0;
            this.AllowDrop = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            collectionPath = files[0];
            loaded.Visible = true;
            showHideLabel.Enabled = true;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Collection File |*.json";  
            file.RestoreDirectory = true;
            file.CheckFileExists = true;
            file.Title = "Choose collection file";
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                collectionPath = file.SafeFileName;
                loaded.Visible = true;
                showHideLabel.Enabled = true;
            }
        }

        private void showHideLabel_Tick(object sender, EventArgs e)
        {
            loaded.Visible = false;
            showHideLabel.Enabled = false;
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            JObject collection = JObject.Parse(File.ReadAllText(collectionPath));
            MessageBox.Show(collection["info"]["name"].ToString());

        }
    }
}
