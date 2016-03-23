namespace Terminator
{
    partial class SweetAlertForm
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
            this.FileBox = new System.Windows.Forms.RichTextBox();
            this.btnAlert = new System.Windows.Forms.Button();
            this.btnSuccess = new System.Windows.Forms.Button();
            this.btnFail = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.PreviewBoard = new System.Windows.Forms.RichTextBox();
            this.AlertBox = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FileBox
            // 
            this.FileBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileBox.ForeColor = System.Drawing.SystemColors.Window;
            this.FileBox.Location = new System.Drawing.Point(12, 12);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(746, 853);
            this.FileBox.TabIndex = 0;
            this.FileBox.Text = "";
            // 
            // btnAlert
            // 
            this.btnAlert.Anchor = ((System.Windows.Forms.AnchorStyles)
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right);
            this.btnAlert.Location = new System.Drawing.Point(763, 552);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(75, 23);
            this.btnAlert.TabIndex = 1;
            this.btnAlert.Text = "Alert";
            this.btnAlert.UseVisualStyleBackColor = true;
            // 
            // btnSuccess
            // 
            this.btnSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right);
            this.btnSuccess.Location = new System.Drawing.Point(845, 551);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(75, 23);
            this.btnSuccess.TabIndex = 2;
            this.btnSuccess.Text = "Success";
            this.btnSuccess.UseVisualStyleBackColor = true;
            // 
            // btnFail
            // 
            this.btnFail.Anchor = ((System.Windows.Forms.AnchorStyles)
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right);
            this.btnFail.Location = new System.Drawing.Point(927, 550);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(75, 23);
            this.btnFail.TabIndex = 3;
            this.btnFail.Text = "Fail";
            this.btnFail.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right);
            this.btnConfirm.Location = new System.Drawing.Point(1008, 550);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // PreviewBoard
            // 
            this.PreviewBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Top ) |
                System.Windows.Forms.AnchorStyles.Right));
            this.PreviewBoard.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PreviewBoard.CausesValidation = false;
            this.PreviewBoard.ForeColor = System.Drawing.SystemColors.Info;
            this.PreviewBoard.Location = new System.Drawing.Point(765, 579);
            this.PreviewBoard.Name = "PreviewBoard";
            this.PreviewBoard.Size = new System.Drawing.Size(318, 286);
            this.PreviewBoard.TabIndex = 5;
            this.PreviewBoard.Text = "";
            // 
            // AlertBox
            // 
            this.AlertBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right)));
            this.AlertBox.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AlertBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlertBox.Location = new System.Drawing.Point(763, 13);
            this.AlertBox.Name = "AlertBox";
            this.AlertBox.Size = new System.Drawing.Size(320, 531);
            this.AlertBox.TabIndex = 6;
            // 
            // SweetAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 877);
            this.Controls.Add(this.AlertBox);
            this.Controls.Add(this.PreviewBoard);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnFail);
            this.Controls.Add(this.btnSuccess);
            this.Controls.Add(this.btnAlert);
            this.Controls.Add(this.FileBox);
            this.Name = "SweetAlertForm";
            this.Text = "SwetAlertForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.AlertBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileBox;
        private System.Windows.Forms.Button btnAlert;
        private System.Windows.Forms.Button btnSuccess;
        private System.Windows.Forms.Button btnFail;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.RichTextBox PreviewBoard;
        private System.Windows.Forms.DataGridView AlertBox;
    }
}