var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
            builder => builder.WithOrigins(
                            "http://localhost:4200")                         
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    
                    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllOrigins");
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
