using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI.XWPF.UserModel;

namespace NpoiStudy
{
    public class NPOIWord
    {
        public static void WordExport(string templateWord)
        {
            XWPFDocument doc = null;
            using (FileStream stream = File.OpenRead(templateWord))
            {
                doc = new XWPFDocument(stream);
                var paragraphList = doc.Paragraphs;
                foreach(XWPFParagraph paragraph in paragraphList)
                {
                    string text = paragraph.Text;
                    var runs = paragraph.Runs;
                    string styleid = paragraph.Style;
                    foreach (XWPFRun run in runs)
                    {
                        text = run.GetText(0);
                    }
                }
            }
            
            //FileStream fs = File.Create(@"D:\testWord.docx");
            //doc.Write(fs);
            //fs.Close();
        }
    }
}
