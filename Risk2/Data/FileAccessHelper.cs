using System.Diagnostics;

namespace Risk2.Data;

public class FileAccessHelper
{
    //As per iOS guidelines for where files should be stored 'Library Folder'
    //The FileSystem.AppDataDirectory returns this folder
    //
    public static string GetLocalFilePath(string filename)
    {
        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        Debug.WriteLine($"[SQLite] Database Path: {dbPath}");

        return dbPath;
    }
}