using CopyPro.Models;
using CopyPro.Properties;
using System;
using System.IO;
using System.Windows.Forms;
namespace CopyPro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            Computars computars = new Computars();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    computars.PuthForCopyFile = openFileDialog.FileName;
                    SelectFileTb.Text = computars.PuthForCopyFile;
                }
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader(@"C:\sorce\setting.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    Copy copy = new Copy(line);
                    copy.CopyFiles(SelectFileTb.Text);

                }
            }

            SelectFileTb.Clear();
        }

        private void ClouseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}
