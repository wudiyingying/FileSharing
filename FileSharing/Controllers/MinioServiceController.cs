using FileSharing.Model;
using FileSharing.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace FileSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinioServiceController : ControllerBase
    {
        private Client client;
        
        [HttpGet("")]
        public string downloadObj()
        {
            return "sssss";
        }
        
        [HttpPost("upload")]
        public bool uploadObj(uploadInfo uploadInfo)
        {
            client = new Client(uploadInfo.Id, uploadInfo.Password);
            try { 
                var result=MinioService.MinioService.uploadFile(client, uploadInfo.srcPath, uploadInfo.destPath).Result;
                return true;
            }
            catch (Exception e)
            {

                return false;
            } 
        }

        [HttpDelete]
        public bool deleteObj(deleteInfo delete)
        {
            client = new Client(delete.Id, delete.Password);
            try
            {
                var result = MinioService.MinioService.deleteFile(client, delete.destPath).Result;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
