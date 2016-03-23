using System.Windows.Forms;
namespace Terminator
{
    public partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.FilePeek = new System.Windows.Forms.RichTextBox();
            this.grdResult = new System.Windows.Forms.DataGridView();
            this.messageGrid = new System.Windows.Forms.DataGridView();
            this.detailSearchGrid = new System.Windows.Forms.DataGridView();
            this.resultGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertAndReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMsgIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailSearchMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageGridOld = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailSearchGrid)).BeginInit();
            this.resultGridMenu.SuspendLayout();
            this.databaseMenu.SuspendLayout();
            this.detailSearchMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageGridOld)).BeginInit();
            this.SuspendLayout();
            // 
            // FilePeek
            // 
            this.FilePeek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePeek.BackColor = System.Drawing.SystemColors.InfoText;
            this.FilePeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePeek.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilePeek.Location = new System.Drawing.Point(12, 12);
            this.FilePeek.Name = "FilePeek";
            this.FilePeek.ReadOnly = true;
            this.FilePeek.Size = new System.Drawing.Size(736, 817);
            this.FilePeek.TabIndex = 0;
            this.FilePeek.Text = "";
            this.FilePeek.WordWrap = false;
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToResizeRows = false;
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdResult.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdResult.Location = new System.Drawing.Point(754, 12);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowHeadersVisible = false;
            this.grdResult.Size = new System.Drawing.Size(280, 634);
            this.grdResult.TabIndex = 7;
            this.grdResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdResult_CellFormatting);
            this.grdResult.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdResult_CellMouseClick);
            this.grdResult.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdResult_CellMouseUp);
            // 
            // messageGrid
            // 
            this.messageGrid.AllowUserToResizeRows = false;
            this.messageGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.messageGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.messageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.messageGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.messageGrid.Location = new System.Drawing.Point(1040, 12);
            this.messageGrid.Name = "messageGrid";
            this.messageGrid.RowHeadersVisible = false;
            this.messageGrid.Size = new System.Drawing.Size(284, 330);
            this.messageGrid.TabIndex = 12;
            this.messageGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.messageGrid_CellMouseClick);
            this.messageGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.messageGrid_CellMouseUp);
            this.messageGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.messageGrid_CellValueChanged);
            this.messageGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.messageGrid_MouseDoubleClick);
            // 
            // detailSearchGrid
            // 
            this.detailSearchGrid.AllowUserToResizeRows = false;
            this.detailSearchGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.detailSearchGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.detailSearchGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.detailSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailSearchGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.detailSearchGrid.Location = new System.Drawing.Point(754, 652);
            this.detailSearchGrid.Name = "detailSearchGrid";
            this.detailSearchGrid.RowHeadersVisible = false;
            this.detailSearchGrid.Size = new System.Drawing.Size(570, 177);
            this.detailSearchGrid.TabIndex = 13;
            this.detailSearchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailSearchGrid_CellContentClick);
            this.detailSearchGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.detailSearchGrid_CellMouseUp);
            this.detailSearchGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailSearchGrid_CellValueChanged);
            // 
            // resultGridMenu
            // 
            this.resultGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToDatabaseToolStripMenuItem,
            this.insertAndReplaceToolStripMenuItem});
            this.resultGridMenu.Name = "resultGridMenu";
            this.resultGridMenu.Size = new System.Drawing.Size(171, 48);
            // 
            // insertToDatabaseToolStripMenuItem
            // 
            this.insertToDatabaseToolStripMenuItem.Name = "insertToDatabaseToolStripMenuItem";
            this.insertToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.insertToDatabaseToolStripMenuItem.Text = "Insert to Database";
            this.insertToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.insertToDatabaseToolStripMenuItem_Click);
            // 
            // insertAndReplaceToolStripMenuItem
            // 
            this.insertAndReplaceToolStripMenuItem.Name = "insertAndReplaceToolStripMenuItem";
            this.insertAndReplaceToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.insertAndReplaceToolStripMenuItem.Text = "Insert and Replace";
            this.insertAndReplaceToolStripMenuItem.Click += new System.EventHandler(this.insertAndReplaceToolStripMenuItem_Click);
            // 
            // databaseMenu
            // 
            this.databaseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRecordToolStripMenuItem,
            this.searchMsgIDToolStripMenuItem});
            this.databaseMenu.Name = "databaseMenu";
            this.databaseMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // deleteRecordToolStripMenuItem
            // 
            this.deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            this.deleteRecordToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteRecordToolStripMenuItem.Text = "Delete Record";
            this.deleteRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteRecordToolStripMenuItem_Click);
            // 
            // searchMsgIDToolStripMenuItem
            // 
            this.searchMsgIDToolStripMenuItem.Name = "searchMsgIDToolStripMenuItem";
            this.searchMsgIDToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.searchMsgIDToolStripMenuItem.Text = "Search MsgID";
            this.searchMsgIDToolStripMenuItem.Click += new System.EventHandler(this.searchMsgIDToolStripMenuItem_Click);
            // 
            // detailSearchMenu
            // 
            this.detailSearchMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem});
            this.detailSearchMenu.Name = "detailSearchMenu";
            this.detailSearchMenu.Size = new System.Drawing.Size(116, 26);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // messageGridOld
            // 
            this.messageGridOld.AllowUserToResizeRows = false;
            this.messageGridOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageGridOld.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.messageGridOld.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.messageGridOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messageGridOld.Location = new System.Drawing.Point(1040, 348);
            this.messageGridOld.Name = "messageGridOld";
            this.messageGridOld.RowHeadersVisible = false;
            this.messageGridOld.Size = new System.Drawing.Size(284, 298);
            this.messageGridOld.TabIndex = 14;
            this.messageGridOld.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.messageGridOld_CellMouseClick);
            this.messageGridOld.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.messageGridOld_CellMouseDoubleClick);
            this.messageGridOld.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.messageGridOld_CellMouseUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 841);
            this.Controls.Add(this.messageGridOld);
            this.Controls.Add(this.detailSearchGrid);
            this.Controls.Add(this.messageGrid);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.FilePeek);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Quotation Peek";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailSearchGrid)).EndInit();
            this.resultGridMenu.ResumeLayout(false);
            this.databaseMenu.ResumeLayout(false);
            this.detailSearchMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageGridOld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox FilePeek;
        private System.Windows.Forms.DataGridView grdResult;
        private System.Windows.Forms.DataGridView messageGrid;
        private System.Windows.Forms.DataGridView detailSearchGrid;
        private ContextMenuStrip resultGridMenu;
        private ToolStripMenuItem insertToDatabaseToolStripMenuItem;
        private ToolStripMenuItem insertAndReplaceToolStripMenuItem;
        private ContextMenuStrip databaseMenu;
        private ToolStripMenuItem deleteRecordToolStripMenuItem;
        private ToolStripMenuItem searchMsgIDToolStripMenuItem;
        private ContextMenuStrip detailSearchMenu;
        private ToolStripMenuItem replaceToolStripMenuItem;
        private DataGridView messageGridOld;
    }
}