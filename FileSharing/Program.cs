using FileSharing.Model;
using FileSharing.ESService;
Client client1 = new Client("1","a",DateTime.Now,"3");
Client client2 = new Client("2", "b", DateTime.Now, "2");
ESService.getConnection();
Console.WriteLine( ESService.indexClient(client1));
Console.WriteLine(ESService.indexClient(client2));
var result1= ESService.findClientById("1");
if (result1 == null) { Console.WriteLine("客户查询为空"); }
else
{
    Console.WriteLine(result1.Id + result1.Name + result1.Password);
}
    FileItem fileItem1 = new FileItem("1","数据库", "mysql数据库讲解内核", false, "1", DateTime.Now, "软件工程", 1.0);
    FileItem fileItem2 = new FileItem("2", "java", "java核心技术操作系统", false, "1", DateTime.Now, "软件工程", 1.0);
    FileItem fileItem3 = new FileItem("3", "操作系统", "linux内核", false, "1", DateTime.Now, "软件工程", 1.0);
Console.WriteLine(ESService.indexFileItem(fileItem1));
Console.WriteLine(ESService.indexFileItem(fileItem2));
Console.WriteLine(ESService.indexFileItem(fileItem3));
//ESService.elasticClient.Bulk(a=>a.Index("fileitem").IndexMany(new List<FileItem>() { fileItem1,fileItem2,fileItem3 }));
    var result2 = ESService.findFileItemByString("操作系统");
    if (result2.Count == 0) { Console.WriteLine("文件查询为空"); }
    else
    {
        foreach (FileItem fileItem in result2)
        {
            Console.WriteLine(fileItem.Name + " " + fileItem.Description + " " + fileItem.IsPrivate + " " + fileItem.UploudTime + " " + fileItem.Type + " " + fileItem.Length);

        }

    }

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

