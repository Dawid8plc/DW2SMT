namespace DW2SMT
{
    partial class SearchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWindow));
            inputBox = new TextBox();
            vanillaRadio = new RadioButton();
            customRadio = new RadioButton();
            findFirstBtn = new Button();
            findLastBtn = new Button();
            findNextBtn = new Button();
            findPreviousBtn = new Button();
            SuspendLayout();
            // 
            // inputBox
            // 
            inputBox.Location = new Point(12, 12);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(389, 23);
            inputBox.TabIndex = 0;
            // 
            // vanillaRadio
            // 
            vanillaRadio.AutoSize = true;
            vanillaRadio.Checked = true;
            vanillaRadio.Location = new Point(12, 43);
            vanillaRadio.Name = "vanillaRadio";
            vanillaRadio.Size = new Size(72, 19);
            vanillaRadio.TabIndex = 1;
            vanillaRadio.TabStop = true;
            vanillaRadio.Text = "In Vanilla";
            vanillaRadio.UseVisualStyleBackColor = true;
            // 
            // customRadio
            // 
            customRadio.AutoSize = true;
            customRadio.Location = new Point(321, 43);
            customRadio.Name = "customRadio";
            customRadio.Size = new Size(80, 19);
            customRadio.TabIndex = 2;
            customRadio.TabStop = true;
            customRadio.Text = "In Custom";
            customRadio.UseVisualStyleBackColor = true;
            // 
            // findFirstBtn
            // 
            findFirstBtn.Location = new Point(12, 66);
            findFirstBtn.Name = "findFirstBtn";
            findFirstBtn.Size = new Size(92, 23);
            findFirstBtn.TabIndex = 3;
            findFirstBtn.Text = "Find First";
            findFirstBtn.UseVisualStyleBackColor = true;
            findFirstBtn.Click += findFirstBtn_Click;
            // 
            // findLastBtn
            // 
            findLastBtn.Location = new Point(110, 66);
            findLastBtn.Name = "findLastBtn";
            findLastBtn.Size = new Size(92, 23);
            findLastBtn.TabIndex = 4;
            findLastBtn.Text = "Find Last";
            findLastBtn.UseVisualStyleBackColor = true;
            findLastBtn.Click += findLastBtn_Click;
            // 
            // findNextBtn
            // 
            findNextBtn.Location = new Point(309, 66);
            findNextBtn.Name = "findNextBtn";
            findNextBtn.Size = new Size(92, 23);
            findNextBtn.TabIndex = 5;
            findNextBtn.Text = "Find Next";
            findNextBtn.UseVisualStyleBackColor = true;
            findNextBtn.Click += findNextBtn_Click;
            // 
            // findPreviousBtn
            // 
            findPreviousBtn.Location = new Point(211, 66);
            findPreviousBtn.Name = "findPreviousBtn";
            findPreviousBtn.Size = new Size(92, 23);
            findPreviousBtn.TabIndex = 6;
            findPreviousBtn.Text = "Find Previous";
            findPreviousBtn.UseVisualStyleBackColor = true;
            findPreviousBtn.Click += findPreviousBtn_Click;
            // 
            // SearchWindow
            // 
            AcceptButton = findNextBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 94);
            Controls.Add(findPreviousBtn);
            Controls.Add(findNextBtn);
            Controls.Add(findLastBtn);
            Controls.Add(findFirstBtn);
            Controls.Add(customRadio);
            Controls.Add(vanillaRadio);
            Controls.Add(inputBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search";
            FormClosing += SearchWindow_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputBox;
        private RadioButton vanillaRadio;
        private RadioButton customRadio;
        private Button findFirstBtn;
        private Button findLastBtn;
        private Button findNextBtn;
        private Button findPreviousBtn;
    }
}