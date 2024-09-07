namespace DW2SMT
{
    partial class MapCreator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapCreator));
            scanBtn = new Button();
            loadMapBtn = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label1 = new Label();
            exportBtn = new Button();
            SuspendLayout();
            // 
            // scanBtn
            // 
            scanBtn.Location = new Point(12, 12);
            scanBtn.Name = "scanBtn";
            scanBtn.Size = new Size(75, 23);
            scanBtn.TabIndex = 0;
            scanBtn.Text = "Scan";
            scanBtn.UseVisualStyleBackColor = true;
            scanBtn.Click += button1_Click;
            // 
            // loadMapBtn
            // 
            loadMapBtn.Location = new Point(93, 12);
            loadMapBtn.Name = "loadMapBtn";
            loadMapBtn.Size = new Size(75, 23);
            loadMapBtn.TabIndex = 1;
            loadMapBtn.Text = "Load Map";
            loadMapBtn.UseVisualStyleBackColor = true;
            loadMapBtn.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(188, 349);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(206, 41);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(188, 349);
            listBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 16);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // exportBtn
            // 
            exportBtn.Location = new Point(12, 396);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(75, 23);
            exportBtn.TabIndex = 5;
            exportBtn.Text = "Export";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exportBtn);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(loadMapBtn);
            Controls.Add(scanBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "DW2SMT - Map Creator";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button scanBtn;
        private Button loadMapBtn;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label1;
        private Button exportBtn;
    }
}
