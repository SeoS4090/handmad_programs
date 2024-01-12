using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace handmade_program.Script.ExcelReader
{
    internal class ExcelReader : SingleTone<ExcelReader>
    {
        #region 엑셀

        public IWorkbook GetWorkbook(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                //표준 xls 버젼
                if (filename.EndsWith("xls"))
                    return new HSSFWorkbook(stream);
                //확장 xlsx 버젼
                else if (filename.EndsWith("xlsx"))
                    return new XSSFWorkbook(stream);
                else
                    throw new NotSupportedException();
            }
        }

        public Dictionary<string, ISheet> ExcelToSheetDic(string filePath)
        {
            IWorkbook book = GetWorkbook(filePath);
            if (book is null)
            {
                MessageBox.Show($"Can Not Read {filePath}", "ERROR");
                return null;
            }

            Dictionary<string, ISheet> sheetDic = new Dictionary<string, ISheet>();
            for (int i = 0; i < book.NumberOfSheets; i++)
            {
                var sheet = book.GetSheetAt(i);
                sheetDic.Add(sheet.SheetName, sheet);
            }

            return sheetDic;
        }

        #endregion
    }
}
