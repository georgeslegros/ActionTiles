using System.IO;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;

namespace ActionTiles.Utils
{
    public static class FileHelper
    {
        public static void SaveToFile(string path, object content)
        {
            var serial = JsonConvert.SerializeObject(content);

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var writeStream = new IsolatedStorageFileStream(path, FileMode.Create, store))
            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write(serial);
            }
        }

        public static T ReadFromFile<T>(string path)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.FileExists(path))
                    store.CreateFile(path);
                using (var readStream = new IsolatedStorageFileStream(path, FileMode.Open, store))
                using (var reader = new StreamReader(readStream))
                {
                    var fileContent = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(fileContent);
                }
            }
        }
    }
}