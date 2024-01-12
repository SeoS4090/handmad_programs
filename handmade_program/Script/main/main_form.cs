using CustomTool;
using handmade_program.Script.settingPanel;

namespace handmade_program
{
    public partial class main_form : Form
    {
        public Popup_Setting popup_setting = null;
        public TermBuild popup_termBuild = null;

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
            // 아이콘을 더블클릭하면 폼 화면을 보여줌
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        /// <summary>
        /// 트레이로 이동 또는 종료
        /// </summary>
        private void Main_form_Close(object sender, FormClosingEventArgs e)
        {
            if (DataModelManager.instance.settingData.Init == false)
            {
                DataModelManager.instance.settingData.Init = true;
                DataModelManager.instance.settingData.TrayOn =
                    MessageBox.Show("트레이로 이동 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;

                DataModelManager.instance.settingData.Save();
            }


            if (DataModelManager.instance.settingData.TrayOn)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// 강제 종료
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

        private void TermBuild_Click(object sender, EventArgs e)
        {
            if (popup_termBuild is null)
            {
                popup_termBuild = new TermBuild();
                this.AddOwnedForm(popup_termBuild);
                popup_termBuild.FormClosed += (sender, e) => { popup_termBuild = null; this.Show(); };
            }
            this.Hide();
            popup_termBuild.Show();
        }
    }
}