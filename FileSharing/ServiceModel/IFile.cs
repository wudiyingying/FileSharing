namespace FileSharing.Model
{
    public interface IFile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public string ClientId { get; set; }
        public DateTime UploudTime { get; set; }
        public string Type { get; set; }
        public double Length { get; set; }
    }
}
