using Nest;

namespace FileSharing.Model
{
    [ElasticsearchType(Name = "client")]
    public class Client
    {

        
        public string Id { get; set; }
        [Text(Analyzer = "ik_max_word", Name = "name")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Password { get; set; }
        public Client() { }
        public Client(string id, string name, DateTime time, string password) { Id = id; Name = name; Created = time; Password = password; }
    }
}
