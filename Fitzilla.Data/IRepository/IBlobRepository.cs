using Fitzilla.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace Fitzilla.DAL.IRepository;

public interface IBlobRepository
{
    Task<BlobObject> GetBlobFile(string path);
    Task<List<BlobObject>> GetBlobFiles(List<string> paths);
    Task<BlobObject?> DownloadAsync(string path);
    Task<BlobResponse> UploadBlobAsync(IFormFile file);
    Task<string> UploadBlobFile(IFormFile file);
    Task<List<string>> UploadBlobFiles(List<IFormFile> files);
    void DeleteBlobFile(string path);
    Task DeleteBlobFiles(List<string> paths);
    Task<List<string>> ListBlobs();
}
