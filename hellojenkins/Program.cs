var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:8083");

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.MapGet("/", () => "Hello World!");


app.Run();



