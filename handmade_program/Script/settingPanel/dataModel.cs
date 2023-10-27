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


public class DataModelManager : SingleTone<DataModelManager>
{
    public SettingData settingData;

    public DataModelManager()
    {
        settingData = JsonConvert.DeserializeObject<SettingData>(dataSettings.Default.settingData);
    }
}