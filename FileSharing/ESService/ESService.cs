using Nest;
using FileSharing.Model;
namespace FileSharing.ESService
{
    public class ESService
    {
        public static ElasticClient elasticClient { get; set; }
        public static void getConnection()
        {
            var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("default");
             elasticClient = new ElasticClient(settings);
            if (!elasticClient.Indices.Exists("client").Exists) { var createIndexResponse = elasticClient.Indices.Create("client", c => c.Map<Client>(m => m.AutoMap())); }
            if (!elasticClient.Indices.Exists("fileitem").Exists) { var createIndexResponse1 = elasticClient.Indices.Create("fileitem", c => c.Map<FileItem>(m => m.AutoMap())); }
        }
        public static bool indexClient(Client client)
        {
            var indexResponse = elasticClient.Index(client, i => i.Index("client"));
            return indexResponse.IsValid;
        }
        public static bool indexFileItem(FileItem fileItem)
        {
            var indexResponse = elasticClient.Index(fileItem, i => i.Index("fileitem"));
            return indexResponse.IsValid;
        }
        public static List<FileItem> findFileItemByString(string context) {
            var searchResponse = elasticClient.Search<FileItem>(s=>s.Index("fileitem").From(0).Size(10).Query(q=>q
            .QueryString(m=>m
                .Fields(f=>f
                    .Field(d=>d.Description)
                    .Field(a=>a.Name))
                    .Query(context))));
            var files = searchResponse.Documents;
            return files.ToList();
        }
        public static Client findClientById(string id) {
            try
            {
                var searchResponse = elasticClient.Search<Client>(s => s.Index("client").Query(q => q
                        .Match(m => m
                                .Field(a=>a.Id)
                                .Query(id))));
                var client = searchResponse.Documents;
                return client.FirstOrDefault();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
