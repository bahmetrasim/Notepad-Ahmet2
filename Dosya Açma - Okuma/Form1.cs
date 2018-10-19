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
using Dosya_Açma___Okuma.Properties;


namespace Dosya_Açma___Okuma
{
    public partial class Form1 : Form
    {

        string filename = "";
        string path;
        string cancel = "";
        string filetextprev = "";
        string pano = "";
        int cursorPosition = 0;
        // situation 1 = save / kaydetmek istediğinize emin misiniz sorusunu getirme
        // 1. Ödev - Kapnmada cancel konusu - OK
        // 2. Ödev Open da gelen yazı hiç değişmediyse sorma - OK
        /* 3. Ödev yeni dosya açtı - yazdı çıktı kaydetme sorma ama yeniden açıldığında text kalsın - OK
          a. using appname.Properties ekle
            b. solution explorer app Sağ click Properties - Settings - Ekle
            c. Setting.Default ["Adı"] = .....text
            d. Setting.Default.Save()
            e. Açarken Formun açıldığı yere textbox = Settings.Default["Adı"].ToString();
             */
        // 4. Ödev Copy + Paste + cut 

        //Copy eğer select yok ise hata dönme'yi if'siz try ile yapılabilir mi?

        // 1- Notepad ismini değiştir -SAve veya Open veya Saveas yapınca
        // 2- Notepad isminin yanına yıldız koy eğer Open yada save edilen dosyadan farklı bir şey eklendiyse
        // 3- Form'dan methodları ayır Başka bir class'ta



        public Form1()
        {
            InitializeComponent();
            wordWrapToolStripMenuItem.Checked = true;
            Notepad_yaz.Text = Settings.Default["LastText"].ToString();
            Notepad_yaz.SelectionStart = 0;
        }

        public void savedialog()
        {
            SaveFileDialog savingfile = new SaveFileDialog();
            savingfile.Filter = "Text Files | *.txt";
            var result = savingfile.ShowDialog();
            if (result == DialogResult.OK)
            {
                filename = savingfile.FileName;
                path = savingfile.FileName;
                File.WriteAllText(path, Notepad_yaz.Text);
                filetextprev = Notepad_yaz.Text;
                Settings.Default["LastText"] = "";
                Settings.Default.Save();
            }

        }

        public void openfromfile()
        {
            OpenFileDialog ChoosingtxtFile = new OpenFileDialog();
            ChoosingtxtFile.Filter = "Text Files | *.txt";
            var result = ChoosingtxtFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ChoosingtxtFile.FileName);
                filetextprev = File.ReadAllText(ChoosingtxtFile.FileName);
                Notepad_yaz.Text = filetextprev;
                filename = ChoosingtxtFile.FileName;
            }
        }

        public void asktosave()
        {
            string mesaj = "Do you want to save changes to " + filename + " ?";
            var result = MessageBox.Show(mesaj, "Notepad Ahmet", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Cancel)
            {
                cancel = "true";
            }

            if (result == DialogResult.Yes)
            {
                Savingissues(filename, 1);
                cancel = "save";
            }

            if (cancel == "new")
            {
                Notepad_yaz.Text = "";
                filename = "";
            }

            if (cancel == "open")
            {
                openfromfile();
            }

        }

        public void Savingissues(string file, int situation = 0)
        {
            // situation 1 = save / kaydetmek istediğinize emin misiniz sorusunu getirme
            if (file != "" && situation == 1)
            {
                File.WriteAllText(file, Notepad_yaz.Text);
                filetextprev = Notepad_yaz.Text;
                Settings.Default["LastText"] = "";
                Settings.Default.Save();
            }
            else
            {
                if (situation == 1)
                {
                    savedialog();
                }
                else
                {
                    asktosave();
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
            cancel = "new";
            if (Notepad_yaz.Text == "") { }
            else if (Notepad_yaz.Text == filetextprev)
            {
                Notepad_yaz.Text = "";
                filename = "";
            }
            else
            {
                Savingissues(filename);
                //MessageBox.Show("Do you want to save changes to ....", "Notepad Ahmet", MessageBoxButtons.YesNoCancel);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancel = "open";
            if (Notepad_yaz.Text == "" || Notepad_yaz.Text == filetextprev)
            {
                openfromfile();
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
            Application.Exit();

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(Notepad_yaz.Text))
            {
                if (Notepad_yaz.Text != filetextprev)
                {
                    cancel = "cancel";
                    Savingissues(filename);
                    if (cancel == "true")
                        e.Cancel = true;

                    else if (cancel != "save")
                    {
                        Settings.Default["LastText"] = Notepad_yaz.Text;
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Notepad_yaz.SelectedText != "")
            {
                Clipboard.SetText(Notepad_yaz.SelectedText);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pano = Clipboard.GetText();
            cursorPosition = Notepad_yaz.SelectionStart;
            Notepad_yaz.Text = Notepad_yaz.Text.Insert(cursorPosition, pano);
            cursorPosition = cursorPosition + pano.Length;
            Notepad_yaz.DeselectAll();

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Notepad_yaz.SelectedText != "")
            {
                Clipboard.SetText(Notepad_yaz.SelectedText);
                pano = Clipboard.GetText();
                cursorPosition = Notepad_yaz.SelectionStart;
                Notepad_yaz.Text = Notepad_yaz.Text.Remove(cursorPosition, pano.Length);
                cursorPosition = cursorPosition - pano.Length;
            }
        }
    }
}
