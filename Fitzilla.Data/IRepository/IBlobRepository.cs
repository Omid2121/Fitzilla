using Fitzilla.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.IRepository
{
    public interface IBlobRepository
    {
        //Task<string> UploadBlobFile(string filePath, string fileName);
        Task<BlobObject> GetBlobFile(string path);
        Task<string> UploadBlobFile(IFormFile file);
        Task<List<string>> UploadBlobFiles(List<IFormFile> files);
        void DeleteBlobFile(string path);
        // delete range 
        Task DeleteBlobFiles(List<string> paths);
        Task<List<string>> ListBlobs();
    }
}
