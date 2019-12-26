using System;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using metro.Entities;

namespace metro.AzureStorageHelper
{
    public class AzureStorageHelper
    {
        private static readonly CloudStorageAccount storageAccount;
        private static readonly CloudTableClient tableClient;
        private static readonly CloudTable table;
        private static readonly string connectionString = @"DefaultEndpointsProtocol=https;AccountName=metro;AccountKey=K3EyjX9/29fJwX9s/Y579NH5YBQNCm/hURC6TcskYrltdmODVfE64WuRrt/BlE084fl3NQ3AuxKcuT6xUDJ01g==;EndpointSuffix=core.windows.net";

        static AzureStorageHelper()
        {
            storageAccount = CloudStorageAccount.Parse(connectionString);
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("transfer");
            table.CreateIfNotExistsAsync();
        }

        public static async Task<Transfer> InsertOrMergeEntityAsync(Transfer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                Transfer insertedCustomer = result.Result as Transfer;

                return insertedCustomer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<Transfer> RetrieveEntityUsingPointQueryAsync(string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Transfer>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Transfer customer = result.Result as Transfer;

                return customer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
