namespace WindowsFormsApplication3
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJavaCode = new System.Windows.Forms.RichTextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListView();
            this.Identifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsSteward = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsParasitic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtJavaCode
            // 
            this.txtJavaCode.Location = new System.Drawing.Point(12, 12);
            this.txtJavaCode.Name = "txtJavaCode";
            this.txtJavaCode.Size = new System.Drawing.Size(851, 612);
            this.txtJavaCode.TabIndex = 0;
            this.txtJavaCode.Text = "int input; read(input);";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(1192, 12);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(206, 47);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // listResult
            // 
            this.listResult.AutoArrange = false;
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Identifier,
            this.IsData,
            this.IsSteward,
            this.IsModified,
            this.IsParasitic});
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listResult.Location = new System.Drawing.Point(910, 65);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(488, 510);
            this.listResult.TabIndex = 3;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // Identifier
            // 
            this.Identifier.Tag = "";
            this.Identifier.Text = "Identifier";
            this.Identifier.Width = 124;
            // 
            // IsData
            // 
            this.IsData.Text = "Is Data";
            this.IsData.Width = 105;
            // 
            // IsSteward
            // 
            this.IsSteward.Text = "Is Steward";
            this.IsSteward.Width = 88;
            // 
            // IsModified
            // 
            this.IsModified.Text = "Is Modified";
            this.IsModified.Width = 78;
            // 
            // IsParasitic
            // 
            this.IsParasitic.Text = "Is Parasitic";
            this.IsParasitic.Width = 88;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(910, 596);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(487, 20);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "Значение метрики:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(910, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(195, 46);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 636);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtJavaCode);
            this.Name = "frmMain";
            this.Text = "Java Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtJavaCode;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.ListView listResult;
        public System.Windows.Forms.ColumnHeader Identifier;
        private System.Windows.Forms.ColumnHeader IsData;
        private System.Windows.Forms.ColumnHeader IsSteward;
        private System.Windows.Forms.ColumnHeader IsModified;
        private System.Windows.Forms.ColumnHeader IsParasitic;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

