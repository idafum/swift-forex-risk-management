using System.Diagnostics;

namespace Risk2.Data;

public class FileAccessHelper
{
    //As per iOS guidelines for where files should be stored 'Library Folder'
    //The FileSystem.AppDataDirectory returns this folder
    //
    public static string GetLocalFilePath(string filename)
    {
#if DEBUG
        //Store database in a folder on Desktop when debugging
        string debugFolder = "/Users/somto/Desktop/Risk2.DB";

        // Ensure the folder exists
        if (!Directory.Exists(debugFolder))
        {
            Directory.CreateDirectory(debugFolder);
        }

        string dbPath = Path.Combine(debugFolder, filename);
#else

        //Defult location for production (App Sandbox)
        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
#endif

        Debug.WriteLine($"[SQLite] Database Path: {dbPath}");
        return dbPath;
    }
}