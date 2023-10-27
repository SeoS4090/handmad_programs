using handmade_program.Script.settingPanel;

namespace handmade_program
{
    public partial class main_form : Form
    {
        public Popup_Setting popup_setting = null;

        public main_form()
        {
            InitializeComponent();
        }

        private void Onclick_ToolBar_Menu(object sender, EventArgs e)
        {
            MessageBox.Show("about handmade Program");
        }

        private void notification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // �������� ����Ŭ���ϸ� �� ȭ���� ������
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        /// <summary>
        /// Ʈ���̷� �̵� �Ǵ� ����
        /// </summary>
        private void Main_form_Close(object sender, FormClosingEventArgs e)
        {
            if (DataModelManager.instance.settingData.Init == false)
            {
                DataModelManager.instance.settingData.Init = true;
                DataModelManager.instance.settingData.TrayOn =
                    MessageBox.Show("Ʈ���̷� �̵� �Ͻðڽ��ϱ�?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;

                DataModelManager.instance.settingData.Save();
            }


            if (DataModelManager.instance.settingData.TrayOn)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// ���� ����
        /// </summary>
        private void Exit_Click(object sender, EventArgs e)
        {
            DataModelManager.instance.settingData.TrayOn = false;
            this.Close();
        }

        private void Toolbar_Option_Click(object sender, EventArgs e)
        {
            if (popup_setting is null)
            {
                popup_setting = new Popup_Setting();
                this.AddOwnedForm(popup_setting);
                popup_setting.FormClosed += (sender, e) => { popup_setting = null; };
            }

            popup_setting.Show();
        }
    }
}