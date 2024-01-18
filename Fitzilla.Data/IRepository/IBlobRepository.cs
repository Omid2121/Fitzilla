using Fitzilla.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.DAL.IRepository
{
    public interface IBlobRepository
    {
        Task<BlobObject> GetBlobFile(string path);
        Task<string> UploadBlobFile(string filePath, string fileName);
        void DeleteBlobFile(string path);
        Task<List<string>> ListBlobs();
    }
}
