namespace Anray.Helpers
{
    public static class FileManeger
    {
        public static string saveFile(string path,string folder,IFormFile file)
        {
            string name = file.FileName;
            name= name.Length>64 ? name.Substring(name.Length - 64, 64) : name;
            name=Guid.NewGuid().ToString()+name;
            string savepath=Path.Combine(path,folder,name);
            using(FileStream fs =new FileStream(savepath, FileMode.Create))
            {
               file.CopyTo(fs);
            }
            return name;
        }
        public static void DeleteFile(string path, string folder,string filename)
        {
            string delete=Path.Combine(path,folder,filename);
            if(System.IO.File.Exists(delete))
            {
                System.IO.File.Delete(delete);
            }
        }
    }
}
