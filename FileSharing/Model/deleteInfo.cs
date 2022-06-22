namespace FileSharing.Model
{
    public class deleteInfo
    {
        public deleteInfo(string id, string password, string destPath)
        {
            Id = id;
            Password = password;
            this.destPath = destPath;
        }

        public string Id { get; set; }

        public string Password { get; set; }

        public string destPath { get; set; }


    }
}
