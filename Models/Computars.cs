using System;
using System.IO;
using System.Windows.Forms;

namespace CopyPro.Models
{
    public class Computars
   {
        public string PuthForCopyFile { get; set; }
        private string DateCreating { get; set; }
        public string Puth { get; set; }
        public string CopyTo { get; set; }
        

        //Создание папки
        public string CreateDir()
        {
            //Дата создания
            string dateCreating = DateTime.Now.ToShortDateString();

            DirectoryInfo dirInf = new DirectoryInfo(Puth);
            if (!dirInf.Exists)
            {
                dirInf.Create();
            }
            dirInf.CreateSubdirectory(dateCreating);
            
            string new_line =  Puth + @"\" + dateCreating;

            //возвращат строку с полным путем до файла с датой
            return new_line;
        }

        //Копирование файлов
        public void CopyFiles(string puthFirst)
        {
            try
            {
                File.Copy(puthFirst, CreateDir() + "/" + Path.GetFileName(puthFirst));
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
