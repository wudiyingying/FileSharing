using Minio;

namespace FileSharing.ServiceModel
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public MinioClient Minio { get; set; }


        public Client()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Client(string name, string password) : this()
        {
            Name = name;
            Password = password;
            Minio = new MinioClient()
                .WithEndpoint("")
                .WithCredentials(Name, Password);
            //为用户建桶
            //将用户信息存入数据库
        }
        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   Id == client.Id &&
                   Name == client.Name;
        }
        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
