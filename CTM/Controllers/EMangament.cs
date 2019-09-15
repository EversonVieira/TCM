using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
namespace CTM
{
    
    class EMangament
    {
        public void ExportFile(DataGridView dg)
        {
            try
            {
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
                worksheet.Cells.Font.Color = Color.White;
                for (int j = 1; j < dg.Columns.Count + 1; j++)
                {
                    worksheet.Cells[1, j] = dg.Columns[j - 1].HeaderText;
                    worksheet.Cells[1, j].Borders.ColorIndex = 0;
                    worksheet.Cells[1, j].Interior.Color = Color.FromArgb(65, 65, 65);
                }
                for (int i = 0; i < dg.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dg.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[i + 2, j + 1].Borders.ColorIndex = 1;
                        worksheet.Cells[i + 2, j + 1].Interior.Color = Color.FromArgb(105, 105, 105);
                    }
                }
                for (int j = 1; j < dg.Columns.Count + 1; j++)
                {
                    worksheet.Columns[j].AutoFit();
                }
                excelApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void ImportFile(DataGridView dg)
        {

        }
    }
}
