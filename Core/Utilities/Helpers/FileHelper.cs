using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";
        public void CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExist(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Bu tipte bir dosya yüklenemez.");
            }
            return new SuccessResult();
        }

        public void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        public IResult Delete(string path)
        {
            DeleteOldFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
    }
}
