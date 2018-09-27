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
    public partial class NewandOpenMessage : Form
    {
        string filename;
        string path;
        string text;
        public enum Revalue { Save, Cancel, NotSave, Open };


        public NewandOpenMessage(string filename, string text)
        {
            InitializeComponent();
            this.filename = filename;
            this.text = text;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sft = new SaveFileDialog();

            if (filename is null)
            {
                sft.Filter = "Text Files | *.txt";
                sft.ShowDialog();
                if (sft.FileName != null)
                {
                    path = sft.FileName;
                    File.WriteAllText(path, text);
                }
            }
            
        }
        private void Notsave_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
