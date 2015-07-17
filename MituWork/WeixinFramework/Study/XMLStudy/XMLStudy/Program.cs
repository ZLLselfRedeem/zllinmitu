using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Packaging;
using System.Xml;

namespace XMLStudy
{
    public class WordUtil
    {
        //public static XWPFDocument GenerateWord(DataRow dtRow, string template)
        //{
        //    XWPFDocument doc = null;
        //    using (FileStream stream = File.OpenRead(template))
        //    {
        //        doc = new XWPFDocument(stream);
        //        // 非表格的，正常段落的处理
        //        var paragraphList = doc.Paragraphs;
        //        processParagraphs(paragraphList, dtRow);

        //        // 表格处理
        //        var tables = doc.Tables;
        //        foreach (var table in tables)
        //        {
        //            foreach (var row in table.Rows)
        //            {
        //                foreach (var cell in row.GetTableCells())
        //                {
        //                    var paragraphTable = cell.Paragraphs;
        //                    processParagraphs(paragraphTable, dtRow);
        //                }
        //            }
        //        }
        //    }

        //    return doc;
        //}

        public static XWPFDocument GenerateWord(DataTable dtSource, string template)
        {
            XWPFDocument doc = null;
            XWPFDocument newDoc = null;
            using (FileStream stream = File.OpenRead(template))
            {
                doc = new XWPFDocument(stream);
                newDoc = new XWPFDocument();
                var paragraphList = doc.Paragraphs;
                processParagraphs(paragraphList, dtSource, newDoc);

                //对于word文档中表格的处理，甚至是有表格，有文本的情况下的处理。分页比较难办
                //var tables = doc.Tables;
                //foreach (var table in tables)
                //{
                //    foreach (var row in table.Rows)
                //    {
                //        foreach (var cell in row.GetTableCells())
                //        {
                //            var paragraphTable = cell.Paragraphs;
                //            processParagraphs(paragraphList, dtSource, newDoc);
                //        }
                //    }
                //}
            }
            return newDoc;
        }

        private static void processParagraphs(IList<XWPFParagraph> paragraphList, DataTable dtSource, XWPFDocument newDoc)
        {
            foreach (DataRow dtRow in dtSource.Rows)
            {
                if (paragraphList != null && paragraphList.Count > 0)
                {
                    int indexOfParagraph = 0;
                    foreach (XWPFParagraph paragraph in paragraphList)
                    {
                        XWPFParagraph newParagraph = newDoc.CreateParagraph();
                        newParagraph.Alignment = paragraph.Alignment;
                        var runs = paragraph.Runs;
                        foreach (XWPFRun run in runs)
                        {
                            XWPFRun newRun = newParagraph.CreateRun();
                            //newParagraph.AddRun(run);
                            //newParagraph.Runs[0].GetText(0);
                            bool isSetText = false;
                            string rText = run.ToString();
                            //newRun = run;
                            newRun.SetText(rText, 0);
                            
                            if (!string.IsNullOrEmpty(rText))
                            {
                                var parse = ExpressionParser.ParseExpression(rText);
                                if (parse.ParamCount != 0)
                                {
                                    isSetText = true;
                                    string[] Source = new string[parse.ParamCount];
                                    int index = 0;
                                    foreach (string columnName in parse.ParamArray)
                                    {
                                        try
                                        {
                                            Source[index] = dtRow[columnName].ToString();
                                        }
                                        catch (Exception e)
                                        {
                                            isSetText = false;
                                        }
                                    }
                                    if (isSetText)
                                    {
                                        newRun.SetText(string.Format(parse.FormatString, Source), 0);
                                    }
                                }
                            }
                            newRun.FontSize = run.FontSize;
                            newRun.SetBold(run.IsBold);
                            newRun.SetColor(run.GetColor());
                            newRun.IsItalic = run.IsItalic;
                            newRun.SetStrike(run.IsStrike);
                            newRun.SetUnderline(run.Underline);
                            newRun.GetCTR().AddNewRPr().AddNewRFonts().ascii = run.FontFamily;
                            newRun.GetCTR().AddNewRPr().AddNewRFonts().eastAsia = run.FontFamily;
                        }
                        if (indexOfParagraph == 0)
                        {
                            newParagraph.IsPageBreak = true;
                        }
                        indexOfParagraph++;
                    }
                }
            }
        }

        //private static void processParagraphs(IList<XWPFParagraph> paragraphList, DataRow row)
        //{
        //    if (paragraphList != null && paragraphList.Count > 0)
        //    {
        //        foreach (XWPFParagraph paragraph in paragraphList)
        //        {
        //            var runs = paragraph.Runs;
        //            foreach (XWPFRun run in runs)
        //            {
        //                bool isSetText = false;
        //                string rText = run.ToString();
        //                if (!string.IsNullOrEmpty(rText))
        //                {
        //                    var parse = ExpressionParser.ParseExpression(rText);
        //                    if (parse.ParamCount != 0)
        //                    {
        //                        isSetText = true;
        //                        string[] Source = new string[parse.ParamCount];
        //                        int index = 0;
        //                        foreach (string el in parse.ParamArray)
        //                        {
        //                            try
        //                            {
        //                                Source[index] = row[el].ToString();
        //                            }
        //                            catch (Exception e)
        //                            {
        //                                isSetText = false;
        //                            }
        //                            index++;
        //                        }
        //                        rText = string.Format(parse.FormatString, Source);
        //                    }
        //                }
        //                if (isSetText)
        //                {
        //                    run.SetText(rText, 0);
        //                }
        //            }
        //        }
        //    }
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestWordNPOI();
            
            Console.Write("\rPress any key to continue...");
            Console.Read();
        }

        private static void TestWordNPOI()
        {
            DateTime dt = DateTime.Now;
            string timeNow = dt.ToLongDateString().ToString();

            DataTable namesTable = new DataTable();

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "datetime";
            namesTable.Columns.Add(dtColumn);

            DataColumn strColumn = new DataColumn();
            strColumn.DataType = System.Type.GetType("System.String");
            strColumn.ColumnName = "school";
            namesTable.Columns.Add(strColumn);

            DataColumn intColumn = new DataColumn();
            intColumn.DataType = System.Type.GetType("System.Int32");
            intColumn.ColumnName = "years";
            namesTable.Columns.Add(intColumn);

            DataColumn nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "name";
            namesTable.Columns.Add(nameColumn);

            DataColumn majorColumn = new DataColumn();
            majorColumn.DataType = System.Type.GetType("System.String");
            majorColumn.ColumnName = "major";
            namesTable.Columns.Add(majorColumn);

            DataRow row1 = namesTable.NewRow();

            row1["datetime"] = timeNow;
            row1["school"] = "浙江叉叉大学";
            row1["years"] = 7;
            row1["major"] = "普通大学生专业";
            row1["name"] = "赵玲玲";
            namesTable.Rows.Add(row1);

            DataRow row2 = namesTable.NewRow();
            row2["datetime"] = timeNow;
            row2["school"] = "浙江gongye大学";
            row2["years"] = 4;
            row2["major"] = "何种专业";
            row2["name"] = "张悦轩";
            namesTable.Rows.Add(row2);

            string templateWord = @"D:\templateNPOITest.docx";

            //XWPFDocument newDoc = WordUtil.GenerateWord(row1, templateWord);

            //FileStream fs = File.Create(@"D:\ResultWord.docx");
            //newDoc.Write(fs);
            //fs.Close();

            XWPFDocument newDocs = WordUtil.GenerateWord(namesTable, templateWord);
            FileStream fss = File.Create(@"D:\ResultWords.docx");
            newDocs.Write(fss);
            fss.Close();
        }

        #region XML中直接进行替换

        private static MemoryStream LoadFileIntoStream(string fileName)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);

                memoryStream.Flush();
                fileStream.Close();
            }
            return memoryStream;
        }

        public static MemoryStream GenerateWord()
        {
            string templateDoc = @"D:\template.docx";
            // string reportFileName = @"D:\result.docx";
            var reportStream = LoadFileIntoStream(templateDoc);

            Package pkg = Package.Open(reportStream);
            Uri uri = new Uri("/word/document.xml", UriKind.Relative);
            PackagePart part = pkg.GetPart(uri);

            XmlDocument xmlMainXMLDoc = new XmlDocument();
            xmlMainXMLDoc.Load(part.GetStream(FileMode.Open, FileAccess.Read));

            xmlMainXMLDoc.InnerXml = xmlMainXMLDoc.InnerXml.Replace("field_customer", "My Customer Name");
            xmlMainXMLDoc.InnerXml = xmlMainXMLDoc.InnerXml.Replace("field_title", "Report of Documents");
            xmlMainXMLDoc.InnerXml = xmlMainXMLDoc.InnerXml.Replace("field_content", "Content of Document");

            // 运行时异常
            StreamWriter partWrt = new StreamWriter(part.GetStream(FileMode.Open, FileAccess.Write));
            xmlMainXMLDoc.Save(partWrt);
            partWrt.Flush();
            partWrt.Close();
            reportStream.Flush();
            pkg.Close();

            return reportStream;
        }

        #endregion

        #region 读写XMl测试

        private static void WriteXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>
            xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            //创建跟节点
            XmlNode rootNode = xmlDoc.CreateElement("students");
            //创建student子节点
            XmlNode studentNode = xmlDoc.CreateElement("student");
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("name");
            nameAttribute.Value = "张同学";
            studentNode.Attributes.Append(nameAttribute);

            // 创建courses子节点
            XmlNode coursesNode = xmlDoc.CreateElement("courses");
            XmlNode courseNode1 = xmlDoc.CreateElement("course");
            XmlAttribute courseNameAttr = xmlDoc.CreateAttribute("name");
            courseNameAttr.Value = "语文";
            courseNode1.Attributes.Append(courseNameAttr);
            XmlNode teacherCommentNode = xmlDoc.CreateElement("teacherComment");
            XmlCDataSection cdata = xmlDoc.CreateCDataSection("<font color=\"red\">这是语文老师的批注</font>");
            teacherCommentNode.AppendChild(cdata);
            courseNode1.AppendChild(teacherCommentNode);
            coursesNode.AppendChild(courseNode1);

            studentNode.AppendChild(coursesNode);

            rootNode.AppendChild(studentNode);

            xmlDoc.AppendChild(rootNode);

            xmlDoc.Save(@"D:\xmlTest.xml");

            Console.WriteLine("以保存xml文档");
        }

        private static void ReadXml()
        {
            string xmlFilePath = @"D:\StudyTest.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            // 使用xpath表达式选择文档中所有的student子节点
            XmlNodeList studentNodeList = doc.SelectNodes("/students/student");
            if (studentNodeList != null)
            {
                foreach (XmlNode studentNode in studentNodeList)
                {
                    // 通过Attribute获得属性名字为name的属性
                    string name = studentNode.Attributes["Name"].Value;
                    Console.WriteLine("Studenet:" + name);

                    // 通过SelectSingleNode方法获得当前节点下的courses子节点
                    XmlNode coursesNode = studentNode.SelectSingleNode("courses");

                    // 通过ChildNodes属性获得courseNode的所有一级子节点
                    XmlNodeList courseNodeList = coursesNode.ChildNodes;
                    if (courseNodeList != null)
                    {
                        foreach (XmlNode courseNode in courseNodeList)
                        {
                            Console.Write("\t");
                            Console.Write(coursesNode.Attributes["name"].Value);
                            Console.Write("老师评语");
                            XmlNode teacherCommentNode = courseNode.FirstChild;
                            XmlCDataSection cdata = (XmlCDataSection)teacherCommentNode.FirstChild;
                            Console.WriteLine(cdata.InnerText.Trim());
                        }
                    }
                }
            }
        }

        #endregion

    }
}
