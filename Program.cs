
using LWAJWTLOG.Interface;
using LWAJWTLOG.Linq;
using LWAJWTLOG.Model;
using LWAJWTLOG.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NLog;
using NLog.Web;
using System.Configuration;

//nlog
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("LWAPP Launched");



var builder = WebApplication.CreateBuilder(args);
//var logger = NLog.LogManager.GetCurrentClassLogger();
//logger.Info("App started {arguments} {username}", args, "Guruprasad");

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

//stored procedure database connection
builder.Services.AddDbContext<StoredDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnections")));

//Linq Datbase 

builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

//builder.Services.AddDbContext<DatabaseContext_2>(opts => opts.UseSqlServer(bConfiguration["ConnectionString:EmployeeDB"]));
//Builder.Services.AddControllers();


builder.Services.AddTransient<IUserRegistrations, UserRegistrationRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins("http://localhost:55076"
    ).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//linq starts here


//getting Enrollements data List


var Enrollements = EnrollementsDatabase.GetEnrollmentsData();
//method based syntax
var data = Enrollements.Select(b => b.Seller);
//Query Based Suntax



//get multiple data using method based 

var getdetails = Enrollements.Select(b => new
{
    CustomerName = b.Name,
    EnrolledCourse = b.Seller
});


//get multiple data using Query based 

var getcutomerdetails = from b in Enrollements
                        select new
                        {
                            customername = b.Name,
                            enrolledcourse = b.Seller
                        };


//get multiple data using tuple based 
//var getdetailss = Enrollements.Select(b => (CustomerName: b.Price));

var datas = from b in Enrollements select b.Seller;


foreach(var enrollment in data)
{
    Console.WriteLine(enrollment);
}




//Linq Ends here 





var app = builder.Build();

//logger.Info("App started {arguments} {username}", args, "Guruprasad");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();



