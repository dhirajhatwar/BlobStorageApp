using AzureBlobStorageApp.helper;
using System;
using System.Threading.Tasks;

namespace AzureBlobStorageApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=dhirajstorageaccount2020;AccountKey=OqZLVZ4OqrmVt8gsFF9OoX+cix8cLpW9Ih3opK3ESGA2GV8O6dTvhiNWiYwj2t7edZ5pppDoY3bbyYFYnJ3lqg==;EndpointSuffix=core.windows.net";
            storeageHelper helper = new storeageHelper(storageConnectionString);
           var Iscraeted = await helper.CreateBlobContainer("myfiles");
            var uri = await helper.UploadBlob(@"C:\Users\student\Desktop\Images\IMG-20200929-WA0003.jpg", "myfiles");
            Console.WriteLine(uri);
            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
