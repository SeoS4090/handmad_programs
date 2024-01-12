using System.Windows.Forms;

namespace CustomTool
{
    partial class TermBuild
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
            btn_Load = new Button();
            progressBar1 = new ProgressBar();
            FilePath = new TextBox();
            TB_Log = new RichTextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            openFileDialog = new OpenFileDialog();
            btn_Save = new Button();
            _worker = new System.ComponentModel.BackgroundWorker();
            FolderDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // btn_Load
            // 
            btn_Load.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Load.Location = new Point(309, 15);
            btn_Load.Margin = new Padding(3, 4, 3, 4);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(75, 29);
            btn_Load.TabIndex = 1;
            btn_Load.Text = "Load Term xls";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += Btn_Load_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 121);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(372, 29);
            progressBar1.TabIndex = 1;
            // 
            // FilePath
            // 
            FilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilePath.Location = new Point(12, 15);
            FilePath.Margin = new Padding(3, 4, 3, 4);
            FilePath.Name = "FilePath";
            FilePath.Size = new Size(291, 23);
            FilePath.TabIndex = 0;
            // 
            // TB_Log
            // 
            TB_Log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TB_Log.Location = new Point(13, 158);
            TB_Log.Margin = new Padding(3, 4, 3, 4);
            TB_Log.MinimumSize = new Size(4, 224);
            TB_Log.Name = "TB_Log";
            TB_Log.ReadOnly = true;
            TB_Log.Size = new Size(371, 352);
            TB_Log.TabIndex = 3;
            TB_Log.Text = "";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(13, 54);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = DataModelManager.instance.termSetting.Term_Save_Path;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(309, 88);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 5;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += MakeTermButtonClicked;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.ImageAlign = ContentAlignment.MiddleRight;
            checkBox1.Location = new Point(228, 90);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(75, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Log Print";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            openFileDialog.DefaultExt = "xlsx";
            openFileDialog.Filter = "Excel files (*.xlsx,*.xls)|*.xlsx;*.xls|ALL|*.*";
            openFileDialog.InitialDirectory = "c:\\";
            // 
            // btn_Save
            // 
            btn_Save.Enabled = false;
            btn_Save.Location = new Point(309, 51);
            btn_Save.Margin = new Padding(3, 4, 3, 4);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 29);
            btn_Save.TabIndex = 6;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Onclick_btn_Save;
            // 
            // _worker
            // 
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            // 
            // TermBuild
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(396, 525);
            Controls.Add(btn_Save);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(TB_Log);
            Controls.Add(FilePath);
            Controls.Add(progressBar1);
            Controls.Add(btn_Load);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(16, 215);
            Name = "TermBuild";
            Text = "Term Build";
            FormClosing += TermBuild_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Load;
        private ProgressBar progressBar1;
        private TextBox FilePath;
        public RichTextBox TB_Log;
        private TextBox textBox1;
        private Button button1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private OpenFileDialog openFileDialog;
        private Button btn_Save;
        private System.ComponentModel.BackgroundWorker _worker;
        private FolderBrowserDialog FolderDialog;
    }
}