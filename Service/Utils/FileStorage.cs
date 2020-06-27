using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FixesBusiness.Utils
{
    class FileStorage
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString;

        async public static Task<bool> UploadBlob(Stream image, string container, string fileName)
        {
            try 
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                var containerClient = blobServiceClient.GetBlobContainerClient(container);

                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                await blobClient.UploadAsync(image, true);

                image.Close();

                return true;
            }
            catch(Exception e)
            {
                image.Close();
                return false;
            }
        }

    }
}
