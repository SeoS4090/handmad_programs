namespace handmade_program.Script.settingPanel
{
    partial class Popup_Setting
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
            OnTray = new CheckBox();
            popup_desc = new Label();
            SuspendLayout();
            // 
            // OnTray
            // 
            OnTray.AutoSize = true;
            OnTray.CheckAlign = ContentAlignment.MiddleRight;
            OnTray.Location = new Point(12, 12);
            OnTray.Name = "OnTray";
            OnTray.Size = new Size(142, 19);
            OnTray.TabIndex = 0;
            OnTray.Text = "종료시 트레이로 이동";
            OnTray.UseVisualStyleBackColor = true;
            OnTray.Checked = DataModelManager.instance.settingData.TrayOn;
            OnTray.CheckedChanged += OnTray_CheckedChanged;
            // 
            // popup_desc
            // 
            popup_desc.Anchor = AnchorStyles.Bottom;
            popup_desc.AutoSize = true;
            popup_desc.Location = new Point(0, 219);
            popup_desc.Name = "popup_desc";
            popup_desc.Size = new Size(166, 30);
            popup_desc.TabIndex = 1;
            popup_desc.Text = "팝업을 닫을 때 \r\n자동으로 세팅이 저장 됩니다.";
            popup_desc.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Popup_Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(171, 258);
            Controls.Add(popup_desc);
            Controls.Add(OnTray);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Popup_Setting";
            Text = "세팅";
            FormClosed += Popup_Setting_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox OnTray;
        private Label popup_desc;
    }
}