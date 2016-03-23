﻿using System.Windows.Forms;
namespace Terminator
{
    partial class Terminator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminator));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupFiles = new System.Windows.Forms.GroupBox();
            this.btnExpand = new System.Windows.Forms.Button();
            this.lbExtension = new System.Windows.Forms.ListBox();
            this.txtNameExclude = new System.Windows.Forms.TextBox();
            this.cbSubfolders = new System.Windows.Forms.CheckBox();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.lblNameExclude = new System.Windows.Forms.Label();
            this.txtExtention = new System.Windows.Forms.TextBox();
            this.txtContains = new System.Windows.Forms.TextBox();
            this.lblContains = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.console = new System.Windows.Forms.RichTextBox();
            this.groupReplace = new System.Windows.Forms.GroupBox();
            this.progressPrecent = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.progressInfo = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNotContain = new System.Windows.Forms.TextBox();
            this.lblNotContain = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineContains = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.findCorruptedFiles = new System.Windows.Forms.Button();
            this.btnAddLit = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnLitMessage = new System.Windows.Forms.Button();
            this.CustomCSS = new System.Windows.Forms.TabPage();
            this.btnReplaceCSS = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchForQuatationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getMessageFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileFromGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupFiles.SuspendLayout();
            this.groupReplace.SuspendLayout();
            this.search.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.CustomCSS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(363, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(38, 36);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(61, 13);
            this.lblFolder.TabIndex = 2;
            this.lblFolder.Text = "Folder Path";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPath.Location = new System.Drawing.Point(126, 34);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(232, 20);
            this.txtPath.TabIndex = 4;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // groupFiles
            // 
            this.groupFiles.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupFiles.Controls.Add(this.btnExpand);
            this.groupFiles.Controls.Add(this.lbExtension);
            this.groupFiles.Controls.Add(this.txtNameExclude);
            this.groupFiles.Controls.Add(this.cbSubfolders);
            this.groupFiles.Controls.Add(this.btnClipboard);
            this.groupFiles.Controls.Add(this.btnListFiles);
            this.groupFiles.Controls.Add(this.lblNameExclude);
            this.groupFiles.Controls.Add(this.btnBrowse);
            this.groupFiles.Controls.Add(this.txtExtention);
            this.groupFiles.Controls.Add(this.txtContains);
            this.groupFiles.Controls.Add(this.lblContains);
            this.groupFiles.Controls.Add(this.lblExtension);
            this.groupFiles.Location = new System.Drawing.Point(12, 11);
            this.groupFiles.Name = "groupFiles";
            this.groupFiles.Size = new System.Drawing.Size(482, 179);
            this.groupFiles.TabIndex = 5;
            this.groupFiles.TabStop = false;
            this.groupFiles.Text = "Filter Files";
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(447, 20);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(25, 23);
            this.btnExpand.TabIndex = 15;
            this.btnExpand.Text = "->";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.expand_Click);
            // 
            // lbExtension
            // 
            this.lbExtension.FormattingEnabled = true;
            this.lbExtension.Location = new System.Drawing.Point(364, 54);
            this.lbExtension.Name = "lbExtension";
            this.lbExtension.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbExtension.Size = new System.Drawing.Size(101, 108);
            this.lbExtension.TabIndex = 14;
            this.lbExtension.SelectedIndexChanged += new System.EventHandler(this.lbExtension_SelectedIndexChanged);
            // 
            // txtNameExclude
            // 
            this.txtNameExclude.Location = new System.Drawing.Point(115, 109);
            this.txtNameExclude.Name = "txtNameExclude";
            this.txtNameExclude.Size = new System.Drawing.Size(231, 20);
            this.txtNameExclude.TabIndex = 13;
            // 
            // cbSubfolders
            // 
            this.cbSubfolders.AutoSize = true;
            this.cbSubfolders.Checked = true;
            this.cbSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubfolders.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbSubfolders.Location = new System.Drawing.Point(18, 142);
            this.cbSubfolders.Name = "cbSubfolders";
            this.cbSubfolders.Size = new System.Drawing.Size(114, 17);
            this.cbSubfolders.TabIndex = 9;
            this.cbSubfolders.Text = "&Include Subfolders";
            this.cbSubfolders.UseVisualStyleBackColor = true;
            // 
            // btnClipboard
            // 
            this.btnClipboard.Location = new System.Drawing.Point(219, 138);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(128, 23);
            this.btnClipboard.TabIndex = 8;
            this.btnClipboard.Text = "&Copy Files to Clipboard";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // btnListFiles
            // 
            this.btnListFiles.Location = new System.Drawing.Point(138, 138);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 7;
            this.btnListFiles.Text = "&Filter Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // lblNameExclude
            // 
            this.lblNameExclude.AutoSize = true;
            this.lblNameExclude.Location = new System.Drawing.Point(14, 112);
            this.lblNameExclude.Name = "lblNameExclude";
            this.lblNameExclude.Size = new System.Drawing.Size(90, 13);
            this.lblNameExclude.TabIndex = 12;
            this.lblNameExclude.Text = "Filename Exclude";
            // 
            // txtExtention
            // 
            this.txtExtention.Location = new System.Drawing.Point(114, 51);
            this.txtExtention.Name = "txtExtention";
            this.txtExtention.Size = new System.Drawing.Size(232, 20);
            this.txtExtention.TabIndex = 5;
            // 
            // txtContains
            // 
            this.txtContains.Location = new System.Drawing.Point(114, 81);
            this.txtContains.Name = "txtContains";
            this.txtContains.Size = new System.Drawing.Size(232, 20);
            this.txtContains.TabIndex = 11;
            // 
            // lblContains
            // 
            this.lblContains.AutoSize = true;
            this.lblContains.Location = new System.Drawing.Point(15, 84);
            this.lblContains.Name = "lblContains";
            this.lblContains.Size = new System.Drawing.Size(93, 13);
            this.lblContains.TabIndex = 10;
            this.lblContains.Text = "Filename Contains";
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(22, 54);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(72, 13);
            this.lblExtension.TabIndex = 3;
            this.lblExtension.Text = "File Extension";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 186);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(449, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.console.ForeColor = System.Drawing.Color.Lime;
            this.console.Location = new System.Drawing.Point(12, 442);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(482, 111);
            this.console.TabIndex = 7;
            this.console.Text = "";
            this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
            // 
            // groupReplace
            // 
            this.groupReplace.Controls.Add(this.progressBar1);
            this.groupReplace.Controls.Add(this.progressPrecent);
            this.groupReplace.Controls.Add(this.btnUndo);
            this.groupReplace.Controls.Add(this.progressInfo);
            this.groupReplace.Controls.Add(this.btnApply);
            this.groupReplace.Controls.Add(this.btnOpen);
            this.groupReplace.Controls.Add(this.btnCheck);
            this.groupReplace.Controls.Add(this.btnReplace);
            this.groupReplace.Controls.Add(this.search);
            this.groupReplace.Location = new System.Drawing.Point(12, 196);
            this.groupReplace.Name = "groupReplace";
            this.groupReplace.Size = new System.Drawing.Size(482, 240);
            this.groupReplace.TabIndex = 8;
            this.groupReplace.TabStop = false;
            this.groupReplace.Text = "Search and Replace";
            // 
            // progressPrecent
            // 
            this.progressPrecent.AutoSize = true;
            this.progressPrecent.Location = new System.Drawing.Point(437, 212);
            this.progressPrecent.Name = "progressPrecent";
            this.progressPrecent.Size = new System.Drawing.Size(21, 13);
            this.progressPrecent.TabIndex = 10;
            this.progressPrecent.Text = "0%";
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(388, 146);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // progressInfo
            // 
            this.progressInfo.AutoSize = true;
            this.progressInfo.Location = new System.Drawing.Point(22, 212);
            this.progressInfo.Name = "progressInfo";
            this.progressInfo.Size = new System.Drawing.Size(24, 13);
            this.progressInfo.TabIndex = 9;
            this.progressInfo.Text = "Idle";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(297, 146);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(205, 146);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(114, 146);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(23, 146);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 1;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // search
            // 
            this.search.Controls.Add(this.tabPage1);
            this.search.Controls.Add(this.tabPage2);
            this.search.Controls.Add(this.tabPage3);
            this.search.Controls.Add(this.CustomCSS);
            this.search.Location = new System.Drawing.Point(6, 19);
            this.search.Name = "search";
            this.search.SelectedIndex = 0;
            this.search.Size = new System.Drawing.Size(470, 121);
            this.search.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.txtNotContain);
            this.tabPage1.Controls.Add(this.lblNotContain);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtReplaceWith);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtLineContains);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(462, 95);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single Line";
            // 
            // txtNotContain
            // 
            this.txtNotContain.Location = new System.Drawing.Point(328, 21);
            this.txtNotContain.Name = "txtNotContain";
            this.txtNotContain.Size = new System.Drawing.Size(100, 20);
            this.txtNotContain.TabIndex = 6;
            // 
            // lblNotContain
            // 
            this.lblNotContain.AutoSize = true;
            this.lblNotContain.Location = new System.Drawing.Point(248, 24);
            this.lblNotContain.Name = "lblNotContain";
            this.lblNotContain.Size = new System.Drawing.Size(63, 13);
            this.lblNotContain.TabIndex = 5;
            this.lblNotContain.Text = "Not Contain";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(376, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtReplaceWith.Location = new System.Drawing.Point(128, 52);
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(234, 20);
            this.txtReplaceWith.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Replace With";
            // 
            // txtLineContains
            // 
            this.txtLineContains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtLineContains.Location = new System.Drawing.Point(128, 21);
            this.txtLineContains.Name = "txtLineContains";
            this.txtLineContains.Size = new System.Drawing.Size(101, 20);
            this.txtLineContains.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Contains";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(462, 95);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multiple Lines";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(344, 52);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Replace With";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "End Line Contains";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(344, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Begin Line Contains";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.findCorruptedFiles);
            this.tabPage3.Controls.Add(this.btnAddLit);
            this.tabPage3.Controls.Add(this.btnMessage);
            this.tabPage3.Controls.Add(this.btnLitMessage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(462, 95);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Retrieve Message";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // findCorruptedFiles
            // 
            this.findCorruptedFiles.Location = new System.Drawing.Point(26, 59);
            this.findCorruptedFiles.Name = "findCorruptedFiles";
            this.findCorruptedFiles.Size = new System.Drawing.Size(129, 23);
            this.findCorruptedFiles.TabIndex = 13;
            this.findCorruptedFiles.Text = "Find Corrupted File List";
            this.findCorruptedFiles.UseVisualStyleBackColor = true;
            this.findCorruptedFiles.Click += new System.EventHandler(this.findCorruptedFiles_Click);
            // 
            // btnAddLit
            // 
            this.btnAddLit.Location = new System.Drawing.Point(287, 16);
            this.btnAddLit.Name = "btnAddLit";
            this.btnAddLit.Size = new System.Drawing.Size(151, 23);
            this.btnAddLit.TabIndex = 12;
            this.btnAddLit.Text = "Add LitMessage";
            this.btnAddLit.UseVisualStyleBackColor = true;
            this.btnAddLit.Click += new System.EventHandler(this.btnAddLit_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(26, 16);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(72, 23);
            this.btnMessage.TabIndex = 5;
            this.btnMessage.Text = "Message";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btnLitMessage
            // 
            this.btnLitMessage.Location = new System.Drawing.Point(128, 16);
            this.btnLitMessage.Name = "btnLitMessage";
            this.btnLitMessage.Size = new System.Drawing.Size(130, 23);
            this.btnLitMessage.TabIndex = 11;
            this.btnLitMessage.Text = "Not Contain LitMessage";
            this.btnLitMessage.UseVisualStyleBackColor = true;
            this.btnLitMessage.Click += new System.EventHandler(this.btnLitMessage_Click);
            // 
            // CustomCSS
            // 
            this.CustomCSS.Controls.Add(this.btnReplaceCSS);
            this.CustomCSS.Location = new System.Drawing.Point(4, 22);
            this.CustomCSS.Name = "CustomCSS";
            this.CustomCSS.Padding = new System.Windows.Forms.Padding(3);
            this.CustomCSS.Size = new System.Drawing.Size(462, 95);
            this.CustomCSS.TabIndex = 3;
            this.CustomCSS.Text = "CustomCSS";
            this.CustomCSS.UseVisualStyleBackColor = true;
            // 
            // btnReplaceCSS
            // 
            this.btnReplaceCSS.Location = new System.Drawing.Point(114, 21);
            this.btnReplaceCSS.Name = "btnReplaceCSS";
            this.btnReplaceCSS.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceCSS.TabIndex = 0;
            this.btnReplaceCSS.Text = "replaceCSS";
            this.btnReplaceCSS.UseVisualStyleBackColor = true;
            this.btnReplaceCSS.Click += new System.EventHandler(this.btnReplaceCSS_Click);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(509, 11);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersVisible = false;
            this.Grid.Size = new System.Drawing.Size(299, 542);
            this.Grid.TabIndex = 10;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            this.Grid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_CellMouseUp);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(814, 11);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(319, 542);
            this.dataGrid.TabIndex = 11;
            this.dataGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseUp);
            this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            this.dataGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMessageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            // 
            // deleteMessageToolStripMenuItem
            // 
            this.deleteMessageToolStripMenuItem.Name = "deleteMessageToolStripMenuItem";
            this.deleteMessageToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteMessageToolStripMenuItem.Text = "Delete Row";
            this.deleteMessageToolStripMenuItem.Click += new System.EventHandler(this.deleteMessageToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchForQuatationToolStripMenuItem,
            this.getMessageFromDatabaseToolStripMenuItem,
            this.removeFileFromGridToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(224, 70);
            // 
            // searchForQuatationToolStripMenuItem
            // 
            this.searchForQuatationToolStripMenuItem.Name = "searchForQuatationToolStripMenuItem";
            this.searchForQuatationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.searchForQuatationToolStripMenuItem.Text = "Search for Quatation";
            this.searchForQuatationToolStripMenuItem.Click += new System.EventHandler(this.searchForQuotationToolStripMenuItem_Click);
            // 
            // getMessageFromDatabaseToolStripMenuItem
            // 
            this.getMessageFromDatabaseToolStripMenuItem.Name = "getMessageFromDatabaseToolStripMenuItem";
            this.getMessageFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.getMessageFromDatabaseToolStripMenuItem.Text = "Get Message From Database";
            this.getMessageFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.getMessageFromDatabaseToolStripMenuItem_Click);
            // 
            // removeFileFromGridToolStripMenuItem
            // 
            this.removeFileFromGridToolStripMenuItem.Name = "removeFileFromGridToolStripMenuItem";
            this.removeFileFromGridToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeFileFromGridToolStripMenuItem.Text = "Remove File From Grid";
            this.removeFileFromGridToolStripMenuItem.Click += new System.EventHandler(this.removeFileFromGridToolStripMenuItem_Click);
            // 
            // Terminator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(813, 565);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.groupReplace);
            this.Controls.Add(this.console);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.groupFiles);
            this.Controls.Add(this.Grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Terminator";
            this.Text = "Terminator 1.0";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Terminator_FormClosing);
            this.Load += new System.EventHandler(this.Terminator_Load);
            this.groupFiles.ResumeLayout(false);
            this.groupFiles.PerformLayout();
            this.groupReplace.ResumeLayout(false);
            this.groupReplace.PerformLayout();
            this.search.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.CustomCSS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void Grid_DoubleClick(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }


        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupFiles;
        private System.Windows.Forms.TextBox txtExtention;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.GroupBox groupReplace;
        private System.Windows.Forms.TabControl search;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtLineContains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label progressInfo;
        private System.Windows.Forms.Label progressPrecent;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.CheckBox cbSubfolders;
        private System.Windows.Forms.TextBox txtNameExclude;
        private System.Windows.Forms.Label lblNameExclude;
        private System.Windows.Forms.TextBox txtContains;
        private System.Windows.Forms.Label lblContains;
        private Button btnSearch;
        private ListBox lbExtension;
        public DataGridView Grid;
        private Button btnExpand;
        private DataGridView dataGrid;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteMessageToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem searchForQuatationToolStripMenuItem;
        private ToolStripMenuItem getMessageFromDatabaseToolStripMenuItem;
        private ToolStripMenuItem removeFileFromGridToolStripMenuItem;
        private Button btnMessage;
        private Button btnLitMessage;
        private TabPage tabPage3;
        private Button btnAddLit;
        private TextBox txtNotContain;
        private Label lblNotContain;
        private TabPage CustomCSS;
        private Button btnReplaceCSS;
        private Button findCorruptedFiles;
    }
}

