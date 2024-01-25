using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace Fitzilla.DAL.Repository
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _client;
        private readonly List<string> ImageExtensions = [".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".TIFF", ".SVG", ".WEBP"];

        public BlobRepository(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            _client = _blobServiceClient.GetBlobContainerClient("blobcontainerfitzilla");
        }

        public async void DeleteBlobFile(string path)
        {
            var fileName = new Uri(path).Segments.LastOrDefault();
            var blobClient = _client.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }
        public async Task<BlobObject> GetBlobFile(string path)
        {
            var fileName = new Uri(path).Segments.LastOrDefault();

            try
            {
                var blobClient = _client.GetBlobClient(fileName);
                if (await blobClient.ExistsAsync())
                {
                    BlobDownloadResult content = await blobClient.DownloadContentAsync();
                    var downloadedData = content.Content.ToStream();
                    if (ImageExtensions.Contains(Path.GetExtension(fileName.ToUpperInvariant())))
                    {
                        var extension = Path.GetExtension(fileName);
                        return new BlobObject
                        {
                            Content = downloadedData,
                            ContentType = "image/" + extension.Remove(0, 1),
                        };
                    }
                    else
                    {
                        return new BlobObject
                        {
                            Content = downloadedData,
                            ContentType = content.Details.ContentType,
                        };
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BlobObject>> GetBlobFiles(List<string> paths)
        {
            var blobObjects = new List<BlobObject>();

            foreach (var path in paths)
            {
                var fileName = new Uri(path).Segments.LastOrDefault();

                try
                {
                    var blobClient = _client.GetBlobClient(fileName);
                    if (await blobClient.ExistsAsync())
                    {
                        BlobDownloadResult content = await blobClient.DownloadContentAsync();
                        var downloadedData = content.Content.ToStream();
                        if (ImageExtensions.Contains(Path.GetExtension(fileName.ToUpperInvariant())))
                        {
                            var extension = Path.GetExtension(fileName);
                            blobObjects.Add(new BlobObject
                            {
                                Content = downloadedData,
                                ContentType = "image/" + extension.Remove(0, 1),
                            });
                        }
                        else
                        {
                            blobObjects.Add(new BlobObject
                            {
                                Content = downloadedData,
                                ContentType = content.Details.ContentType,
                            });
                        }
                    }
                    else
                    {
                        blobObjects.Add(null);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return blobObjects;
        }

        public async Task<List<string>> ListBlobs()
        {
            var blobs = new List<string>();

            await foreach (var blobItem in _client.GetBlobsAsync())
            {
                blobs.Add(blobItem.Name);
            }

            return blobs;
        }

        public async Task<string> UploadBlobFile(IFormFile file)
        {
            var blobClient = _client.GetBlobClient(file.FileName);
            await blobClient.UploadAsync(file.OpenReadStream());

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<List<string>> UploadBlobFiles(List<IFormFile> files)
        {
            var blobUris = new List<string>();

            foreach (var file in files)
            {
                var blobClient = _client.GetBlobClient(file.FileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                blobUris.Add(blobClient.Uri.AbsoluteUri);
            }

            return blobUris;
        }

        public async Task DeleteBlobFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                var fileName = new Uri(path).Segments.LastOrDefault();
                var blobClient = _client.GetBlobClient(fileName);
                await blobClient.DeleteIfExistsAsync();
            }
        }
    }
}
