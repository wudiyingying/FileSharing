namespace FileSharing.Model
{
    public class uploadInfo
    {
        public uploadInfo(string id, string password, string destPath, string srcPath)
        {
            Id = id;
            Password = password;
            this.destPath = destPath;
            this.srcPath = srcPath;
        }

        public string Id { get; set; }

        public string Password { get; set; }

        public string destPath { get; set; }
        public string srcPath { get; set; }

        
    }
}
