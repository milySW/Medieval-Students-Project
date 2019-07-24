using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;

namespace zadanie
{
    static class Program
    {
        const string StorageAccoutName = "medievalstudents";
        const string StorageAccountKey = "3MS6KnHmwWlWfc7ioX4TehyXrB0LpdLujGPKU/h3sXi4fdoF7vDq4TEz1FB9RLRbuqsoI4/aTogjhrT9xPh3zw==";
        const string FolderPath = "wwwroot/data";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(StorageAccoutName, StorageAccountKey), true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("my-container");
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            foreach (var filePath in Directory.GetFiles(FolderPath, "*.*", SearchOption.AllDirectories))
            {
                var blob = container.GetBlockBlobReference(filePath);
                blob.UploadFromFileAsync(filePath);
                //blob.DownloadToFileAsync(filePath, FileMode.Create);

                Console.WriteLine("Downloaded {0}", filePath);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGame());
        }
    }
}
