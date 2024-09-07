namespace DW2SMT
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            mainListView = new ListView();
            offsetColumn = new ColumnHeader();
            vanillaColumn = new ColumnHeader();
            customColumn = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            returnToLauncherToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            ovewriteCustomWithVanillaToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            vanillaBox = new TextBox();
            customBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            tabControl = new TabControl();
            editorTab = new TabPage();
            projectSettingsTab = new TabPage();
            label2 = new Label();
            encodingBox = new ComboBox();
            label5 = new Label();
            projNameBox = new TextBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            editorTab.SuspendLayout();
            projectSettingsTab.SuspendLayout();
            SuspendLayout();
            // 
            // mainListView
            // 
            mainListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainListView.Columns.AddRange(new ColumnHeader[] { offsetColumn, vanillaColumn, customColumn });
            mainListView.FullRowSelect = true;
            mainListView.GridLines = true;
            mainListView.Location = new Point(0, 0);
            mainListView.MultiSelect = false;
            mainListView.Name = "mainListView";
            mainListView.Size = new Size(792, 358);
            mainListView.TabIndex = 0;
            mainListView.UseCompatibleStateImageBehavior = false;
            mainListView.View = View.Details;
            mainListView.SelectedIndexChanged += mainListView_SelectedIndexChanged;
            // 
            // offsetColumn
            // 
            offsetColumn.Text = "Offset";
            offsetColumn.Width = 100;
            // 
            // vanillaColumn
            // 
            vanillaColumn.Text = "Vanilla";
            vanillaColumn.Width = 335;
            // 
            // customColumn
            // 
            customColumn.Text = "Custom";
            customColumn.Width = 335;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, searchToolStripMenuItem, toolsToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, returnToLauncherToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(175, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(175, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(175, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(175, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(172, 6);
            // 
            // returnToLauncherToolStripMenuItem
            // 
            returnToLauncherToolStripMenuItem.Name = "returnToLauncherToolStripMenuItem";
            returnToLauncherToolStripMenuItem.Size = new Size(175, 22);
            returnToLauncherToolStripMenuItem.Text = "Return to Launcher";
            returnToLauncherToolStripMenuItem.Click += returnToLauncherToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(175, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(54, 20);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ovewriteCustomWithVanillaToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // ovewriteCustomWithVanillaToolStripMenuItem
            // 
            ovewriteCustomWithVanillaToolStripMenuItem.Name = "ovewriteCustomWithVanillaToolStripMenuItem";
            ovewriteCustomWithVanillaToolStripMenuItem.Size = new Size(229, 22);
            ovewriteCustomWithVanillaToolStripMenuItem.Text = "Ovewrite Custom with Vanilla";
            ovewriteCustomWithVanillaToolStripMenuItem.Click += ovewriteCustomWithVanillaToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // vanillaBox
            // 
            vanillaBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vanillaBox.BackColor = SystemColors.Window;
            vanillaBox.Location = new Point(0, 364);
            vanillaBox.Multiline = true;
            vanillaBox.Name = "vanillaBox";
            vanillaBox.ReadOnly = true;
            vanillaBox.ScrollBars = ScrollBars.Both;
            vanillaBox.Size = new Size(792, 99);
            vanillaBox.TabIndex = 2;
            // 
            // customBox
            // 
            customBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customBox.Location = new Point(0, 469);
            customBox.Multiline = true;
            customBox.Name = "customBox";
            customBox.ScrollBars = ScrollBars.Both;
            customBox.Size = new Size(792, 99);
            customBox.TabIndex = 3;
            customBox.Leave += customBox_Leave;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "dcip";
            openFileDialog1.Filter = "Project files|*.dw2lang";
            openFileDialog1.Title = "Open project";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Project files|*.dw2lang";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(editorTab);
            tabControl.Controls.Add(projectSettingsTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 24);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 596);
            tabControl.TabIndex = 4;
            // 
            // editorTab
            // 
            editorTab.Controls.Add(customBox);
            editorTab.Controls.Add(mainListView);
            editorTab.Controls.Add(vanillaBox);
            editorTab.Location = new Point(4, 24);
            editorTab.Name = "editorTab";
            editorTab.Padding = new Padding(3);
            editorTab.Size = new Size(792, 568);
            editorTab.TabIndex = 0;
            editorTab.Text = "Editor";
            editorTab.UseVisualStyleBackColor = true;
            // 
            // projectSettingsTab
            // 
            projectSettingsTab.Controls.Add(label2);
            projectSettingsTab.Controls.Add(encodingBox);
            projectSettingsTab.Controls.Add(label5);
            projectSettingsTab.Controls.Add(projNameBox);
            projectSettingsTab.Controls.Add(label1);
            projectSettingsTab.Location = new Point(4, 24);
            projectSettingsTab.Name = "projectSettingsTab";
            projectSettingsTab.Padding = new Padding(3);
            projectSettingsTab.Size = new Size(792, 568);
            projectSettingsTab.TabIndex = 1;
            projectSettingsTab.Text = "Language settings";
            projectSettingsTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(28, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 13);
            label2.TabIndex = 17;
            label2.Text = "Encoding";
            // 
            // encodingBox
            // 
            encodingBox.DropDownStyle = ComboBoxStyle.DropDownList;
            encodingBox.FormattingEnabled = true;
            encodingBox.Location = new Point(104, 81);
            encodingBox.Name = "encodingBox";
            encodingBox.Size = new Size(417, 23);
            encodingBox.TabIndex = 16;
            encodingBox.SelectedIndexChanged += encodingBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F);
            label5.Location = new Point(12, 58);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 13);
            label5.TabIndex = 15;
            label5.Text = "Language name";
            // 
            // projNameBox
            // 
            projNameBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            projNameBox.Location = new Point(104, 55);
            projNameBox.Margin = new Padding(4, 3, 4, 3);
            projNameBox.Name = "projNameBox";
            projNameBox.Size = new Size(417, 20);
            projNameBox.TabIndex = 14;
            projNameBox.Leave += projNameBox_Leave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(9, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(236, 31);
            label1.TabIndex = 4;
            label1.Text = "Language settings";
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 620);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Editor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DW2SMT - Untitled";
            FormClosing += Editor_FormClosing;
            FormClosed += Editor_FormClosed;
            KeyDown += Editor_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            editorTab.ResumeLayout(false);
            editorTab.PerformLayout();
            projectSettingsTab.ResumeLayout(false);
            projectSettingsTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColumnHeader offsetColumn;
        private ColumnHeader vanillaColumn;
        private ColumnHeader customColumn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox vanillaBox;
        private TextBox customBox;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem returnToLauncherToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TabControl tabControl;
        private TabPage editorTab;
        private TabPage projectSettingsTab;
        private Label label1;
        private Label label5;
        private TextBox projNameBox;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem ovewriteCustomWithVanillaToolStripMenuItem;
        internal ListView mainListView;
        private ToolStripMenuItem searchToolStripMenuItem;
        private Label label2;
        private ComboBox encodingBox;
    }
}