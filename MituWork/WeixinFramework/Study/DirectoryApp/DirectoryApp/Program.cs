using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(info) *****\n");
            DriveInfoView();
            Console.ReadLine();
        }

        private static void ShowWindoswDirectoryIfo()
        {
            
            // Dump directory information
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            // 
            // if you attempt to interact with a nonexistent directory, 
            // a system.IO.DirectoryNotFoundException is thrown.
            // so before proceesing, we can test dir.Exists.
            //
            if (dir.Exists)
            {
                Console.WriteLine("***** Directory Info *****");
                Console.WriteLine("FullName: {0}", dir.FullName);
                Console.WriteLine("Name: {0}", dir.Name);
                Console.WriteLine("Root: {0}", dir.Root);
                Console.WriteLine("Attributes: {0}", dir.Attributes);
                Console.WriteLine("CreateTime: {0}", dir.CreationTime);
                Console.WriteLine("Parent: {0}", dir.Parent);
            }
        }

        private static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Get all file with a *.jpg extension.
            FileInfo[] imageFies = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            // how many were found
            Console.WriteLine("Found {0} *.jpg files\n", imageFies.Length);
            
            // Now print out info for each file
            foreach (var imgF in imageFies)
            {
                Console.WriteLine("*******************************");
                Console.WriteLine("File name: {0}",imgF.Name);
                Console.WriteLine("File size: {0}", imgF.Length);
                Console.WriteLine("Creation: {0}", imgF.CreationTime);
                Console.WriteLine("Attributes: {0}", imgF.Attributes);
            }
        }

        private static void ModifyAppDierctory()
        {
            //DirectoryInfo dir = new DirectoryInfo(@"D:\C#");
            //dir.CreateSubdirectory("MyZyd");
            //dir.CreateSubdirectory(@"MyZyd/Img");
            //dir.CreateSubdirectory(@"MyZju/zjgCampus");
            DirectoryInfo dir = new DirectoryInfo(".");
            dir.CreateSubdirectory("MyFolder");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");
            Console.WriteLine("New Folder is: {0}", myDataFolder);

            Console.WriteLine("Directory name: {0}", myDataFolder.Name);
            Console.WriteLine("Creation: {0}", myDataFolder.CreationTime);
            Console.WriteLine("Attributes: {0}", myDataFolder.Attributes);
        }

        private static void FunWithDirectoryType()
        {
            // List all drives on current computer
            string[] drives = Directory.GetLogicalDrives();
            foreach (string s in drives)
            {
                Console.WriteLine("--> {0}", s);
            }

            // Delete what was created.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                // 如果目录不为空，在删除该目录时，必须同时删除素所有子目录。
                // Directory.Delete(@"D:\C#\MyZyd"); 会导致运行时异常
                Directory.Delete(@"D:\C#\MyZyd", true);
                // 第二个参数指定删除时，是否删除子目录。
                Directory.Delete(@"D:\C#\MyZju", true);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DriveInfoView()
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");
            // Get info regarding all drives
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}, Type: {1}", d.Name, d.DriveType);
                // Check to see whether the drive is mounted
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }
        }
    }
}
