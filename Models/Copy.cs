using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPro.Models
{
    public class Copy
    {   
        private string Puth { get; set; }
        public Copy(string puth)
        {
            Puth = puth;
        }
        
        
        // Метод создания папки с текущей датой
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

            string new_line = Puth + @"\" + dateCreating;

            // Возвращает полный путь к папке
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
