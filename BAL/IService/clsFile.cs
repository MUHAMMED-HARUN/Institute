using BAL.interfaceCalsses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class clsFile
    {
        // create giud
        public Guid CreatedGuid()
        {
            return Guid.NewGuid();
        }
        // ConcatGuidWithFileExtinction
        public string ConvertFileNameToGuid(string originalFileName)
        {
            string Extinction = Path.GetExtension(originalFileName);
            return CreatedGuid().ToString() + Extinction;
        }
        // is directory exist
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        // create directory
        public bool CreateDirectory(string Path)
        {
            try
            {
                Directory.CreateDirectory(Path);
                return true;

            }
            catch
            {
                return false;
            }
        }
        // DeleteFile
        public bool DeleteFile(string path)
        {
            if(!Path.Exists(path))
                return false;

            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //SaveFile
        public string SaveIFormFile(IFormFile File, string DirectoryPath)
        {
            if (File == null)
                return null;
            if (!DirectoryExists(DirectoryPath))
                if (!CreateDirectory(DirectoryPath))
                    return null;

            string NewFileName = ConvertFileNameToGuid(File.FileName);

            string filePath = Path.Combine(DirectoryPath, NewFileName);


            using (FileStream FStream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    File.CopyTo(FStream);
                    return NewFileName;
                }
                catch
                {
                    return null;
                }

            }
        }

        public string SaveIFormFile(IFormFile File, string DirectoryPath, string FileName)
        {
            if (File == null)
                return null;
            if (!DirectoryExists(DirectoryPath))
                if (!CreateDirectory(DirectoryPath))
                    return null;



            string filePath = Path.Combine(DirectoryPath, FileName);


            using (FileStream FStream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    File.CopyTo(FStream);
                    return FileName;
                }
                catch
                {
                    return null;
                }

            }
        }
        public void SaveFileAndDeleteOld(IFormFile IFile,string NewFileName, string OldFileName, string DirectoryPath)
        {
            SaveIFormFile(IFile, DirectoryPath, NewFileName);
            string filePath = Path.Combine(OldFileName, DirectoryPath);
            DeleteFile(filePath);
        }
        public void SaveFileAndDeleteOld(IFormFile IFile, string OldFileName, string DirectoryPath)
        {
            SaveIFormFile(IFile, DirectoryPath);
            string filePath = Path.Combine(OldFileName, DirectoryPath);
            DeleteFile(filePath);
        }
        public static string ConcatToCurentDirectory(string[] Directorys)
        {
            string CurentDirectoy = Directory.GetCurrentDirectory();
            return Path.Combine(CurentDirectoy, Path.Combine(Directorys));
        }
        public static string GetFullPathOfPersonImagesDirectory(bool WithCurentDirectoryPath = true)
        {
            clsFile file = new clsFile();
            string[] ExternalPath =
            {
                "Models-Details","Person","Images"
            };
            string[] ExternalePath2 =
            {
               "wwwroot","Models-Details","Person","Images"
            };
            if (WithCurentDirectoryPath)
                return clsFile.ConcatToCurentDirectory(ExternalePath2);// +"wwwroot\\" + Path.Combine(ExternalPath);

            //return clsFile.ConcatToCurentDirectory(ExternalPath);
            else
                return "\\" + Path.Combine(ExternalPath);
        }
    }
}
