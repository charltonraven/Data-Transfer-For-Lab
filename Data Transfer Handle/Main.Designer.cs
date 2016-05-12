namespace Data_Transfer_Handle
{
    partial class Main
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbNotComplete = new System.Windows.Forms.TabPage();
            this.dgNotCompleted = new System.Windows.Forms.DataGridView();
            this.tbComplete = new System.Windows.Forms.TabPage();
            this.dgCompleted = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tbNotComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNotCompleted)).BeginInit();
            this.tbComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbNotComplete);
            this.tabControl.Controls.Add(this.tbComplete);
            this.tabControl.Location = new System.Drawing.Point(8, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(839, 253);
            this.tabControl.TabIndex = 0;
            // 
            // tbNotComplete
            // 
            this.tbNotComplete.Controls.Add(this.dgNotCompleted);
            this.tbNotComplete.Location = new System.Drawing.Point(4, 22);
            this.tbNotComplete.Name = "tbNotComplete";
            this.tbNotComplete.Padding = new System.Windows.Forms.Padding(3);
            this.tbNotComplete.Size = new System.Drawing.Size(831, 227);
            this.tbNotComplete.TabIndex = 0;
            this.tbNotComplete.Text = "Not Completed";
            this.tbNotComplete.UseVisualStyleBackColor = true;
            // 
            // dgNotCompleted
            // 
            this.dgNotCompleted.AllowUserToAddRows = false;
            this.dgNotCompleted.AllowUserToDeleteRows = false;
            this.dgNotCompleted.BackgroundColor = System.Drawing.Color.White;
            this.dgNotCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNotCompleted.Location = new System.Drawing.Point(0, 0);
            this.dgNotCompleted.Name = "dgNotCompleted";
            this.dgNotCompleted.ReadOnly = true;
            this.dgNotCompleted.Size = new System.Drawing.Size(831, 227);
            this.dgNotCompleted.TabIndex = 0;
            this.dgNotCompleted.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNotCompleted_CellClick);
            this.dgNotCompleted.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNotCompleted_CellContentClick);
            this.dgNotCompleted.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNotCompleted_RowValidated);
            // 
            // tbComplete
            // 
            this.tbComplete.Controls.Add(this.dgCompleted);
            this.tbComplete.Location = new System.Drawing.Point(4, 22);
            this.tbComplete.Name = "tbComplete";
            this.tbComplete.Padding = new System.Windows.Forms.Padding(3);
            this.tbComplete.Size = new System.Drawing.Size(831, 227);
            this.tbComplete.TabIndex = 1;
            this.tbComplete.Text = "Completed";
            this.tbComplete.UseVisualStyleBackColor = true;
            // 
            // dgCompleted
            // 
            this.dgCompleted.AllowUserToAddRows = false;
            this.dgCompleted.AllowUserToDeleteRows = false;
            this.dgCompleted.BackgroundColor = System.Drawing.Color.White;
            this.dgCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompleted.Location = new System.Drawing.Point(2, 4);
            this.dgCompleted.Name = "dgCompleted";
            this.dgCompleted.ReadOnly = true;
            this.dgCompleted.Size = new System.Drawing.Size(829, 223);
            this.dgCompleted.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 259);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 283);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.Text = "Data Transfers";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tbNotComplete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNotCompleted)).EndInit();
            this.tbComplete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompleted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbNotComplete;
        private System.Windows.Forms.TabPage tbComplete;
        private System.Windows.Forms.DataGridView dgNotCompleted;
        private System.Windows.Forms.DataGridView dgCompleted;
        private System.Windows.Forms.Button btnRefresh;
    }
}

