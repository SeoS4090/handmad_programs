using Newtonsoft.Json;
using handmade_program.Script.settingPanel;

public class SettingData
{
    public bool Init = false;
    public bool TrayOn = true;

    public void Save()
    {
        dataSettings.Default.settingData = JsonConvert.SerializeObject(this);
        dataSettings.Default.Save();
    }
}

public class TermSetting
{
    public string sheet_name_LanguageList = "Languages";

    public string Term_Save_Path = Application.UserAppDataPath;
    public string Term_Load_Path = Application.UserAppDataPath;

    public void Save()
    {
        dataSettings.Default.TermSetting = JsonConvert.SerializeObject(this);
        dataSettings.Default.Save();
    }
}

public class TermDTO
{
    public string name = "";
    public Dictionary<string, string> rows = new Dictionary<string, string>();
}


public class DataModelManager : SingleTone<DataModelManager>
{
    public SettingData settingData;
    public TermSetting termSetting = new TermSetting();

    public DataModelManager()
    {
        settingData = JsonConvert.DeserializeObject<SettingData>(dataSettings.Default.settingData);
        termSetting = JsonConvert.DeserializeObject<TermSetting>(dataSettings.Default.TermSetting);
    }
}