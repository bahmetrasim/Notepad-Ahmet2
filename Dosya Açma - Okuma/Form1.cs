using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dosya_Açma___Okuma
{
    public partial class Form1 : Form
    {

        string filename = "";
        string path;
        // situation 1 = save / kaydetmek istediğinize emin misiniz sorusunu getirme

        public Form1()
        {
            InitializeComponent();
        }
        public void savedialog()
        {
            SaveFileDialog savingfile = new SaveFileDialog();
            savingfile.Filter = "Text Files | *.txt";
            var result = savingfile.ShowDialog();
            if (result == DialogResult.Yes)
            {
                filename = savingfile.FileName;
                path = savingfile.FileName;
                File.WriteAllText(path, Notepad_yaz.Text);
            }
            
        }

        public void Savingissues(string file, int situation = 0)
        {
            if (file != "" && situation == 1)
            {
                File.WriteAllText(file, Notepad_yaz.Text);
            }
            else
            {
                if (situation == 1)
                {
                    savedialog();
                }
                else
                {
                    var result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad Ahmet", MessageBoxButtons.YesNoCancel);

                    //Form warning = new NewandOpenMessage(filename, Notepad_yaz.Text);

                    if (result == DialogResult.Yes)
                    {
                        savedialog();
                        Notepad_yaz.Text = "";
                        filename = "";
                    }
                    else if (result == DialogResult.No)
                    {
                        Notepad_yaz.Text = "";
                        filename = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ChoosingtxtFile = new OpenFileDialog();
            ChoosingtxtFile.Filter = "Text Files | *.txt";
            var result = ChoosingtxtFile.ShowDialog();
            if (result == DialogResult.OK)
            {

            }

            //
            /* Text Editör - Notepad Yap
          TExt Sayfası var ortada
          open - Edit - Save - Saveas*/
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Notepad_yaz.Text == "") { }

            else
            {
                Savingissues(filename);
                //MessageBox.Show("Do you want to save changes to ....", "Notepad Ahmet", MessageBoxButtons.YesNoCancel);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Notepad_yaz.Text == "")
            {
                OpenFileDialog ChoosingtxtFile = new OpenFileDialog();
                ChoosingtxtFile.Filter = "Text Files | *.txt";
                var result = ChoosingtxtFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ChoosingtxtFile.FileName);
                    string filetext = File.ReadAllText(ChoosingtxtFile.FileName);
                    Notepad_yaz.Text = filetext;
                    filename = ChoosingtxtFile.FileName;
                }
            }
            else
            {
                Savingissues(filename);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Savingissues(filename, 1);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filename = "";
            Savingissues(filename, 1);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Notepad_yaz.Text == "")
            {
                Application.Exit();
            }
            else
            {
                Savingissues(filename);
                Application.Exit();
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                wordWrapToolStripMenuItem.Checked = true;
                Notepad_yaz.WordWrap = true;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                Notepad_yaz.WordWrap = false;
            }
        }
    }
}
