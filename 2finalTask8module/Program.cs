using System;
using System.IO;

namespace _2finalTask8module
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"\Users";
            Console.WriteLine($"Размер папки {path} - {ShowFolderSize(path)} байт");
        }

        static long ShowFolderSize(string path)
        {
            long folderSize = 0;
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                if (dirinfo.Exists)
                {
                    FileInfo[] files = dirinfo.GetFiles();
                    foreach (var item in files)
                    {
                        folderSize += item.Length;
                    }
                    DirectoryInfo[] subfolders = dirinfo.GetDirectories();
                    foreach (var item in subfolders)
                    {
                        folderSize += ShowFolderSize(item.FullName);
                    }
                }
                else
                {
                    Console.WriteLine("Указан неверный путь к директории");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return folderSize;
        }
    }
}
