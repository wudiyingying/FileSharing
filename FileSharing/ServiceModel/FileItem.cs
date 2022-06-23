using Nest;

namespace FileSharing.Model
{
    [ElasticsearchType(Name = "fileitem")]
    public class FileItem 
    {
        public string Id { set; get; }
        [Text(Analyzer="ik_max_word",Name ="name")]
        public string Name { get ; set ; }
        [Text(Analyzer = "ik_smart", Name = "description")]
        public string Description { get ; set ; }
        [Boolean(Name ="isprivate")]
        public bool IsPrivate { get ; set ; }
        [Keyword(Name ="clientid")]
        public string ClientId { get; set; }
        [Date(Name ="uploadtime")]
        public DateTime UploudTime { get; set; }
        [Text(Analyzer = "ik_max_word", Name = "type")] 
        public string Type { get; set; }
        [Number(NumberType.Double,Name ="length")]
        public double Length { get; set; }

        public FileItem(string id,string name, string description, bool isprivate, string clientid, DateTime time, string type, double length) { 
            Id = id;
            Name = name;
            Description = description;
            IsPrivate = isprivate;
            ClientId = clientid;
            UploudTime = time;
            Type = type;
            Length = length;

        } 
        public FileItem() { }
    }
}
