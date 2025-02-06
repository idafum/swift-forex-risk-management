namespace Risk2.Data;

public class FileAccessHelper
{
    //As per iOS guidelines for where files should be stored 'Library Folder'
    //The FileSystem.AppDataDirectory returns this folder
    //
    public static string GetLocalFilePath(string filename)
    {

        return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
    }
}