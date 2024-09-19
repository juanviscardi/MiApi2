using APIServiceFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
try
    {
    builder.Services.AddServices();
    builder.Services.AddConnectionString("Server=localhost;Database=Devices;Trusted_Connection=True;");
}
catch (Exception e)
{
    Console.WriteLine  
        ("Error: " + e.Message);    
    }*/
builder.Services.AddServices();
builder.Services.AddConnectionString("Server=localhost;Database=Devices;Trusted_Connection=True;");

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
