using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
namespace metro.AzureStorageHelper
{
    public class AzureStorageHelper
    {
        private CloudStorageAccount account;
        public void Connect() 
        {
            string connectionString = "";
            if (CloudStorageAccount.TryParse(connectionString, out account))
            {
                CloudBlobClient blobClient = account.CreateCloudBlobClient();
                string containerName = "";
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                string blobName = "";
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                string path = "";
                blockBlob.UploadFromFile(path);

            }
            else
            {
                // Otherwise, let the user know that they need to define the environment variable.
                Console.WriteLine(
                    "A connection string has not been defined in the system environment variables. " +
                    "Add an environment variable named 'AZURE_STORAGE_CONNECTION_STRING' with your storage " +
                    "connection string as a value.");
                Console.WriteLine("Press any key to exit the application.");
                Console.ReadLine();
            }
        }

    }
}
