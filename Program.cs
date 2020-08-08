using Microsoft.Extensions.Configuration;
using System.IO;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace PhotoSharingApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration["StorageAccountConnectionString"];

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync("photoblobs");

            await containerClient.ExistsAsync();
        }
    }
}
