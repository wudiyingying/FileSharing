namespace FileSharing.ServiceModel
{
    public class ContentType
    {
        private static readonly Dictionary<string, string> DictionaryContentType = new Dictionary<string, string>
        {
            {"default","application/octet-stream"},
            {"bmp","application/x-bmp"},
            {"doc","application/msword"},
            {"docx","application/msword"},
            {"exe","application/x-msdownload"},
            {"gif","image/gif"},
            {"html","text/html"},
            {"jpg","image/jpeg"},
            {"mp4","video/mpeg4"},
            {"mpeg","video/mpg"},
            {"mpg","video/mpg"},
            {"ppt","application/x-ppt"},
            {"pptx","application/x-ppt"},
            {"png","image/png"},
            {"rar","application/zip"},
            {"txt","text/plain"},
            {"xls","application/x-xls"},
            {"xlsx","application/x-xls"},
            {"zip","application/zip"},
        };

        public static string GetContentType(string fileExtension)
        {
            return DictionaryContentType.ContainsKey(fileExtension) ? DictionaryContentType[fileExtension] : DictionaryContentType["default"];
        }
    }
}
