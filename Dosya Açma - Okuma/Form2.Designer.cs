namespace Dosya_Açma___Okuma
{
    partial class NewandOpenMessage
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
            this.Message = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Notsave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Message.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Message.Location = new System.Drawing.Point(22, 28);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(270, 17);
            this.Message.TabIndex = 0;
            this.Message.Text = "Do you want to save changes to Untitled?";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(125, 99);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Notsave
            // 
            this.Notsave.Location = new System.Drawing.Point(217, 99);
            this.Notsave.Name = "Notsave";
            this.Notsave.Size = new System.Drawing.Size(75, 23);
            this.Notsave.TabIndex = 1;
            this.Notsave.Text = "Don\'t Save";
            this.Notsave.UseVisualStyleBackColor = true;
            this.Notsave.Click += new System.EventHandler(this.Notsave_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(310, 99);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // NewandOpenMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 136);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Notsave);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Message);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewandOpenMessage";
            this.Text = "NotePad Ahmet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Notsave;
        private System.Windows.Forms.Button Cancel;
    }
}