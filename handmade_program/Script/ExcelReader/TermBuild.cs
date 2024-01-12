using handmade_program.Script.ExcelReader;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CustomTool
{
    public partial class TermBuild : Form
    {
        public string allLog = "";
        Dictionary<string, ISheet> sheetDic;

        public TermBuild()
        {
            InitializeComponent();
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath.Text) == false) { FilePath.Text = DataModelManager.instance.termSetting.Term_Load_Path; }
            openFileDialog.InitialDirectory = FilePath.Text;
            switch (openFileDialog.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        DataModelManager.instance.termSetting.Term_Load_Path = openFileDialog.FileName;
                        FilePath.Text = openFileDialog.FileName;
                        if (_worker.IsBusy != true)
                            _worker.RunWorkerAsync();

                        break;
                    }
                default:
                    {
                        FilePath.Text = "";
                        Log($"파일 열기 취소");
                        break;
                    }
            }
        }

        void Log(object log, string _Color = "#000000")
        {
            TB_Log.SelectionColor = (Color)new ColorConverter().ConvertFromString(_Color);
            TB_Log.AppendText($"{log}\n");
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    var checkBox = sender as System.Windows.Forms.CheckBox;
        //    if (checkBox.CheckState == CheckState.Checked)
        //    {
        //        TB_Log.Show();
        //        TB_Log.Text = allLog;
        //    }
        //    else
        //        TB_Log.Hide();

        //    this.OnAutoSizeChanged(e);
        //}

        private void MakeTermButtonClicked(object sender, EventArgs e)
        {
            DataModelManager.instance.termSetting.Term_Load_Path = FilePath.Text;
            DataModelManager.instance.termSetting.Term_Save_Path = textBox1.Text;
            DataModelManager.instance.termSetting.Save();

            if (_worker.IsBusy != true)
            {
                _worker.RunWorkerAsync();
            }

            Log("Term Complete");

            btn_Save.Enabled = true;
        }
        private void Onclick_btn_Save(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text) == false) { textBox1.Text = DataModelManager.instance.termSetting.Term_Save_Path; }
            FolderDialog.InitialDirectory = textBox1.Text;

            switch (FolderDialog.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        DataModelManager.instance.termSetting.Term_Save_Path = FolderDialog.SelectedPath;
                        DataModelManager.instance.termSetting.Save();
                        textBox1.Text = FolderDialog.SelectedPath;
                        break;
                    }
                default:
                        break;
            }

            //using (CommonOpenFileDialog save = new CommonOpenFileDialog())
            //{
            //    save.IsFolderPicker = true;

            //    switch (save.ShowDialog())
            //    {
            //        case CommonFileDialogResult.Ok:
            //            {
            //                textBox1.Text = save.FileName;
            //                Log($"{save.FileName} 폴더 선택");

            //                break;
            //            }
            //        default:
            //            {
            //                textBox1.Text = "";
            //                Log($"폴더 열기 취소");
            //                break;
            //            }

            //    }

            //}
        }

        private void _worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var ExcelPath = DataModelManager.instance.termSetting.Term_Load_Path;

            var attributeRowIndex = 6;
            var startRowDataIndex = 7;
            var startColumnIndex = 1;

            sheetDic = ExcelReader.instance.ExcelToSheetDic($"{ExcelPath}");

            var langList = sheetDic[DataModelManager.instance.termSetting.sheet_name_LanguageList].GetRow(0).Select(x => x.StringCellValue).ToList();
            var TermSheets = sheetDic.Where(x => x.Key != DataModelManager.instance.termSetting.sheet_name_LanguageList).ToList();
            Dictionary<string, Dictionary<string, string>> termDTO = new Dictionary<string, Dictionary<string, string>>();

            langList.ForEach(x =>
            {
                termDTO.Add(x, new Dictionary<string, string>());
            });
            List<IRow> rows = new List<IRow>();

            TermSheets.ForEach(x =>
            {
                var rowIndex = startRowDataIndex;
                long LastRowNum = x.Value.LastRowNum;

                while (rowIndex < MAX_ROW)
                {
                    var row = x.Value.GetRow(rowIndex++);

                    if (row is null)
                    {
                        _worker.ReportProgress(0, $"[에러] {x.Key} Line {rowIndex} : Not Found");
                        break;
                    }

                    if (row.GetCell(0).ToString() == "!end")
                        break;

                    rows.Add(row);
                }

                _worker.ReportProgress(0, $"{x.Key} Line : {termDTO.First().Value.Count()}/{rowIndex}");
            });

            var TermDics = rows.GroupBy(x => x.GetCell(0).ToString())
                               .Where(x => x.Select(z => z).Count() > 1)
                               .ToDictionary(x => x.Key, y => y.Select(z => z).ToList());

            if (TermDics.Count() <= 0)
                _worker.ReportProgress(100, "키 중복 없음");
            else
                _worker.ReportProgress(0, $"중복 검사 {TermDics.Count()}");

            int index = 0;
            foreach (var item in TermDics)
            {
                string DistinctLog = $"키 중복 {item.Key}";
                item.Value.ForEach(x =>
                {
                    if (DistinctLog.EndsWith(x.Sheet.SheetName) == false)
                        DistinctLog += $" {x.Sheet.SheetName}";
                });

                _worker.ReportProgress((int)(((index++ + 1.0f) / TermDics.Count()) * 100.0f), new List<object>() { DistinctLog, "#FF0000" });
            }
        }


        private void _worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            var param = e.UserState as List<object>;
            if (param != null)
                Log(param[0], param[1].ToString());
            else
                Log(e.UserState.ToString());
        }
        private void _worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Log($"[ERROR]\n{e.Error.Message}");
            }
            else
                Log("Term Read Complete");
        }

        private void TermBuild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker != null && _worker.IsBusy)
                _worker.CancelAsync();
        }

        public int MAX_ROW;



    }
}
