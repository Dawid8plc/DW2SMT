namespace DW2SMT
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            hostPanel = new Panel();
            SuspendLayout();
            // 
            // hostPanel
            // 
            hostPanel.Dock = DockStyle.Fill;
            hostPanel.Location = new Point(0, 0);
            hostPanel.Name = "hostPanel";
            hostPanel.Size = new Size(613, 352);
            hostPanel.TabIndex = 0;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 352);
            Controls.Add(hostPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DW2SMT - Launcher";
            FormClosed += Launcher_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Panel hostPanel;
    }
}