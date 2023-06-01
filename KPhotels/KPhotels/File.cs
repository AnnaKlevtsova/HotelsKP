
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Windows;

namespace KPhotels
{
    internal class File
    {
        string filename;
        //получаем путь файла
        public File(string filename)
        {
            this.filename = filename;
            DataFile datafile = new DataFile();
        }

        //создание файла
        public void CreateFile()
        {
            //путь шаблона
            string patternFile = "C:\\Users\\user\\Desktop\\ПКС-303 Клевцова Курсовая работа\\Шаблон_для_создания_файла.docx";
            string FileResult = filename;
            try
            {
                System.IO.File.Copy(patternFile, FileResult, true);
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                Type type = typeof(DataFile);
                var value = type.GetProperties();
                foreach (var p in value)
                {
                    if (p.GetValue(this) != null)
                    {
                        keyValues.Add(p.Name, p.GetValue(this).ToString());
                    }
                }


                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(FileResult, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    foreach (KeyValuePair<string, string> item in keyValues)
                    {
                        docText = docText.Replace(item.Key, item.Value);
                    }

                    using (StreamWriter sw = new StreamWriter(
                    wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }

                }

                Process.Start(FileResult);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
