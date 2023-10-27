namespace handmade_program.Script.settingPanel
{
    public partial class Popup_Setting : Form
    {
        public Popup_Setting()
        {
            InitializeComponent();
        }

        private void OnTray_CheckedChanged(object sender, EventArgs e) 
        {
            DataModelManager.instance.settingData.TrayOn = OnTray.Checked;
        }


        private void Popup_Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataModelManager.instance.settingData.Save();
        }
    }
}
