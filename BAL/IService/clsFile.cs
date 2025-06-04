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
            string Extinction=Path.GetExtension(originalFileName); 
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
        public bool DeleteFile(string Path) 
        {
            try
            {
                File.Delete(Path);
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
        public bool SaveFileAndDeleteOld(IFormFile IFile, string OldFileName,string DirectoryPath)
        {
            SaveIFormFile(IFile, DirectoryPath);
            string filePath=Path.Combine(OldFileName, DirectoryPath);
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string ConcatToCurentDirectory(string[] Directorys)
        {
            string CurentDirectoy = Directory.GetCurrentDirectory();
            return Path.Combine(CurentDirectoy,Path.Combine(Directorys));
        }
        public static string GetFullPathOfPersonImagesDirectory()
        {
            clsFile file = new clsFile();
            string[] ExternalPath =
            {
                "wwwroot","Models-Details","Person","Images"
            };
            return clsFile.ConcatToCurentDirectory(ExternalPath);
        }
    }
}
