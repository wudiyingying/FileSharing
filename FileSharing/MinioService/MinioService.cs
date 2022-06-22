using FileSharing.ServiceModel;
using Minio;

namespace FileSharing.MinioService
{
    public class MinioService
    {
        public async static Task<bool> creatBucket(Client client)
        {
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                         .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);

                var location = "us-east-1";
                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await client.Minio.MakeBucketAsync(makeBucketArgs);
                    return true;
                }
                //新建名为ID的用户桶
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public static bool deleteBucket(string ID)
        {
            //删除名为ID的用户桶
            return true;
        }
        public async static Task<bool> uploadFile(Client client, string srcPath, string destPath)
        {
            if (!File.Exists(srcPath)) return false;
            var location = "us-east-1";
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);

                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await client.Minio.MakeBucketAsync(makeBucketArgs);
                }

                string objectName = destPath + srcPath.Substring(srcPath.LastIndexOf(@"\"));
                string objectType = ContentType.GetContentType(srcPath.Substring(srcPath.LastIndexOf(".") + 1));

                var putObjectArgs = new PutObjectArgs()
                   .WithBucket(client.Id)
                   .WithContentType(objectType)
                   .WithFileName(srcPath)
                   .WithObject(objectName);

                var fileInfo = new FileInfo(srcPath);
                //var partNumber = (int)(fileInfo.Length / MinimumPartSize) + 1;
                //var log = new LogHandler(partNumber);

                client.Minio.SetTraceOn();

                await client.Minio.PutObjectAsync(putObjectArgs);


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
            finally
            {
                client.Minio.SetTraceOff();
            }

        }

        public async static Task<bool> deleteFile(Client client,string dest)
        {
            try
            {
                var args = new RemoveObjectArgs()
               .WithBucket(client.Id)
               .WithObject(dest);
                            
                await client.Minio.RemoveObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
