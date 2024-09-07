using System.Net;

namespace DW2SMT.LauncherUI
{
    partial class StartPage
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
            label2 = new Label();
            createProjBtn = new Button();
            label1 = new Label();
            projectPanel = new FlowLayoutPanel();
            aboutBtn = new Button();
            openProjBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(89, 53);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(187, 20);
            label2.TabIndex = 5;
            label2.Text = "Worms 2 String Mod Tool";
            // 
            // createProjBtn
            // 
            createProjBtn.Location = new Point(501, 81);
            createProjBtn.Margin = new Padding(4, 3, 4, 3);
            createProjBtn.Name = "createProjBtn";
            createProjBtn.Size = new Size(99, 28);
            createProjBtn.TabIndex = 4;
            createProjBtn.Text = "Create project";
            createProjBtn.UseVisualStyleBackColor = true;
            createProjBtn.Click += createProjBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(86, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(167, 39);
            label1.TabIndex = 3;
            label1.Text = "DW2SMT";
            // 
            // projectPanel
            // 
            projectPanel.AutoScroll = true;
            projectPanel.BackColor = Color.FromArgb(127, 140, 141);
            projectPanel.BorderStyle = BorderStyle.Fixed3D;
            projectPanel.FlowDirection = FlowDirection.TopDown;
            projectPanel.Location = new Point(16, 81);
            projectPanel.Margin = new Padding(0);
            projectPanel.Name = "projectPanel";
            projectPanel.Size = new Size(475, 256);
            projectPanel.TabIndex = 10;
            projectPanel.WrapContents = false;
            // 
            // aboutBtn
            // 
            aboutBtn.Location = new Point(501, 309);
            aboutBtn.Margin = new Padding(4, 3, 4, 3);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(99, 28);
            aboutBtn.TabIndex = 11;
            aboutBtn.Text = "About";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // openProjBtn
            // 
            openProjBtn.Location = new Point(501, 115);
            openProjBtn.Margin = new Padding(4, 3, 4, 3);
            openProjBtn.Name = "openProjBtn";
            openProjBtn.Size = new Size(99, 28);
            openProjBtn.TabIndex = 12;
            openProjBtn.Text = "Open project";
            openProjBtn.UseVisualStyleBackColor = true;
            openProjBtn.Click += openProjBtn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "dcip";
            openFileDialog1.Filter = "Project files|*.dw2lang";
            openFileDialog1.Title = "Open project";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.DW2SMT_Large;
            pictureBox1.Location = new Point(16, 11);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // StartPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(openProjBtn);
            Controls.Add(aboutBtn);
            Controls.Add(projectPanel);
            Controls.Add(label2);
            Controls.Add(createProjBtn);
            Controls.Add(label1);
            Name = "StartPage";
            Size = new Size(613, 352);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createProjBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel projectPanel;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button openProjBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
