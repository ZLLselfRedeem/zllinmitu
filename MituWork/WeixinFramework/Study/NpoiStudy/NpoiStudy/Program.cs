using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace NpoiStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //string templateWord = @"D:\templateNPOI.docx";
            //WordExport(templateWord);
            NPOIWord();
        }



        public static void WordExport(string templateWord)
        {
            XWPFDocument doc = null;
            using (FileStream stream = File.OpenRead(templateWord))
            {
                doc = new XWPFDocument(stream);
                var paragraphList = doc.Paragraphs;
                foreach (XWPFParagraph paragraph in paragraphList)
                {
                    string pText = paragraph.Text;
                    var runs = paragraph.Runs;
                    string styleid = paragraph.Style;
                    string rText = null;
                    string rTextStr = null;
                    foreach (XWPFRun run in runs)
                    {
                        rText = run.GetText(0);
                        rTextStr = run.ToString();
                    }
                }
            }
        }

        static void NPOIWord()
        {
            // Word的单元是段落，所以我们在空文件中创建一个新的段落
            XWPFDocument doc = new XWPFDocument();
            XWPFParagraph ph = doc.CreateParagraph();
            ph.Alignment = ParagraphAlignment.CENTER;
            ph.BorderBottom = Borders.DOUBLE;
            ph.BorderTop = Borders.DOUBLE;
            ph.BorderRight = Borders.DOUBLE;
            ph.BorderLeft = Borders.DOUBLE;

            XWPFRun run = ph.CreateRun();
            run.SetBold(true);
            run.SetText("你这是在自寻死路");
            // 可以设置paragraph中文本的样式，包括字体，大小，粗细已经删除线等。
            // 此处都是基于XWPFRun来进行设置的，但是注意paragraph中的段落对齐方式是在
            // XWPFParagraph中设置的。
            run.FontFamily = "仿宋";
            run.FontSize = 20;
            run.IsItalic = true;
            run.SetStrike(true);

            // 在Word中创建表格
            XWPFTable table = doc.CreateTable(3, 3);
            table.GetRow(1).GetCell(1).SetText("Example of table");
            // 可以把单元格的内容设置为paragraph实例
            XWPFParagraph pCha = doc.CreateParagraph();
            
            // 注意文本的样式都是基于XWPFRun来进行设置的，除了段落的对齐方式，是paragraph为基准进行设置的
            XWPFRun r1 = pCha.CreateRun();
            r1.SetBold(true);
            r1.FontSize = 15;
            r1.SetText("The quick brown fox1");
            r1.FontFamily = "Courier";
            r1.SetUnderline(UnderlinePatterns.DotDotDash);
            r1.SetTextPosition(100);
            table.GetRow(0).GetCell(0).SetParagraph(pCha);

            table.GetRow(2).GetCell(2).SetText("Only Text");

            FileStream fs = File.Create(@"D:\blank.docx");
            pCha.AddRun(r1);
            doc.Write(fs);
            fs.Close();
        }

        private static void ExcelTest()
        {
            //Console.WriteLine("{0}", 2 << 8);
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "id";
            column.ReadOnly = true;
            //Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            ////column = new DataColumn();
            ////column.DataType = System.Type.GetType("System.DateTime");
            ////column.ColumnName = "DateTime";
            ////column.ReadOnly = true;
            ////table.Columns.Add(column);

            //// Create second column.
            ////column = new DataColumn();
            ////column.DataType = System.Type.GetType("System.Double");
            ////column.ColumnName = "ParentItem";
            ////column.AutoIncrement = false;
            ////column.Caption = "ParentItem";
            ////column.ReadOnly = false;
            ////column.Unique = false;
            //// Add the column to the table.
            ////table.Columns.Add(column);

            //// Make the ID column the primary key column.
            ////DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            ////PrimaryKeyColumns[0] = table.Columns["id"];
            ////table.PrimaryKey = PrimaryKeyColumns;

            //// Instantiate the DataSet variable.
            ////dataSet = new DataSet();
            //// Add the new DataTable to the DataSet.
            ////dataSet.Tables.Add(table);

            //// Create three new DataRow objects and add 
            //// them to the DataTable

            //for (int i = 0; i <= 2; i++)
            //{
            //    row = table.NewRow();
            //    try
            //    {
            //        row["id"] = "2014/12/25";
            //    }
            //    catch (Exception e)
            //    {
            //        throw new Exception("由Excel导入DataTable时，在给DataTable赋值时出现异常", e);
            //        Console.WriteLine("Hello world");
            //    }

            //    int test = 1 + 1;
            //        //row["ParentItem"] = 15324;
            //        //row["DateTime"] = new DateTime(2015, 12, 12, 18, 10, 14);
            //        table.Rows.Add(row);
            //    }
            //     DataTable dt = NPOIWrite.ExcelToDataTable("D:\\test.xls");

            //string strFileName = @"D:\Const\test.xlsx";
            //string fileExt = Path.GetExtension(strFileName);
           // NPOIWrite.ExportEasy("d:\\excel.xls");

            //string testHZLength = "这是签名方式";
            //string testZMLength = "asdfcd";
            //Console.WriteLine("The testLength: {0}", testZMLength.Length);
            //string filePath = @"D:\C#\WeGroup.xls";
            //DataTable dtable = NPOIWrite.ImportExcel(filePath);
            //string strValue = "2015-12-12";
            //DateTime dtime = strValue.Value<DateTime>();
            //Console.WriteLine("my birthday is {0}", dtime);
        }
        }
    }

