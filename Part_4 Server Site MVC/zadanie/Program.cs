using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;



namespace zadanie
{
    public class Program
    {
        // Stałe odpowiedzialne za połączenie z Azurą.
        const string StorageAccoutName = "medievalstudents";
        const string StorageAccountKey = "3MS6KnHmwWlWfc7ioX4TehyXrB0LpdLujGPKU/h3sXi4fdoF7vDq4TEz1FB9RLRbuqsoI4/aTogjhrT9xPh3zw==";
        const string FolderPath = "wwwroot/data";

        public static void Main(string[] args)
        {
            // Wczytujemy kontener z Azury
            var storageAccount = new CloudStorageAccount(new StorageCredentials(StorageAccoutName, StorageAccountKey), true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("my-container");
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            // Pobieramy wszystkie pliki z kontenera na serwer.
            foreach(var filePath in Directory.GetFiles(FolderPath, "*.*", SearchOption.AllDirectories) )
            {
                var blob = container.GetBlockBlobReference(filePath);
                //blob.UploadFromFileAsync(filePath);
                blob.DownloadToFileAsync(filePath, FileMode.Create);


                Console.WriteLine("Uploaded {0}", filePath);
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
