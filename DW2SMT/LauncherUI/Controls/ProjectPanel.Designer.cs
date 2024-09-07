namespace DW2SMT.LauncherUI.Controls
{
    partial class ProjectPanel
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            DateLabel = new Label();
            editBtn = new PictureBox();
            deleteBtn = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)editBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deleteBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(41, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 13);
            label1.TabIndex = 11;
            label1.Text = "Unknown";
            label1.DoubleClick += ProjectPanel_DoubleClick;
            // 
            // DateLabel
            // 
            DateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DateLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            DateLabel.Location = new Point(257, 15);
            DateLabel.Margin = new Padding(4, 0, 4, 0);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(134, 13);
            DateLabel.TabIndex = 14;
            DateLabel.Text = "Unknown";
            DateLabel.TextAlign = ContentAlignment.TopRight;
            DateLabel.DoubleClick += ProjectPanel_DoubleClick;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editBtn.BackColor = SystemColors.InactiveCaption;
            editBtn.BorderStyle = BorderStyle.FixedSingle;
            editBtn.Image = Properties.Resources.editicon;
            editBtn.Location = new Point(397, 5);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(32, 32);
            editBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            editBtn.TabIndex = 13;
            editBtn.TabStop = false;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteBtn.BackColor = SystemColors.InactiveCaption;
            deleteBtn.BorderStyle = BorderStyle.FixedSingle;
            deleteBtn.Image = Properties.Resources.X_button;
            deleteBtn.Location = new Point(435, 5);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(32, 32);
            deleteBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            deleteBtn.TabIndex = 12;
            deleteBtn.TabStop = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.DW2SMT;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += ProjectPanel_DoubleClick;
            // 
            // ProjectPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DateLabel);
            Controls.Add(editBtn);
            Controls.Add(deleteBtn);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Margin = new Padding(0);
            Name = "ProjectPanel";
            Size = new Size(470, 41);
            DoubleClick += ProjectPanel_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)editBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)deleteBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox deleteBtn;
        private System.Windows.Forms.PictureBox editBtn;
        private System.Windows.Forms.Label DateLabel;
    }
}
