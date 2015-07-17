using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CSVUtility
{
    class CSVUtility
    {
        internal static DataSet OpenCSV(string fileName)
        {
            DataSet dSet = new DataSet();
            DataTable dTable = new DataTable();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            try
            {
                string strLine = null;
                string[] aryLine;
                int columnCount = 0;
                bool isFirst = true;
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(';');

                    for (int k = 0; k < aryLine.Length; k++)
                    {
                            aryLine[k] = aryLine[k].Trim(new char[] { '\"' });
                    }

                    if (isFirst == true)
                    {
                        isFirst = false;
                        columnCount = aryLine.Length;

                        foreach (string al in aryLine)
                        {
                            DataColumn dc = new DataColumn(al);
                            dTable.Columns.Add(dc);
                        }
                    }
                    else
                    {
                        DataRow dr = dTable.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dTable.Rows.Add(dr);
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                //string Mes = "文件导入失败，请检查数据格式！" + ex.ToString() + "\r\n";
            }
            finally 
            {
                sr.Close();
                fs.Close();
            }

            dSet.Tables.Add(dTable);
            return dSet;
        } 
    }
}
