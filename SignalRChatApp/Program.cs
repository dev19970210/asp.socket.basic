using SignalRChatApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
// builder.Services.AddControllersWithViews();
// builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         builder =>
//         {
//             builder.WithOrigins("https://example.com")
//                 .AllowAnyHeader()
//                 .WithMethods("GET", "POST")
//                 .AllowCredentials();
//         });
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000") // your client origin
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // important for cookies/auth
    });
});
var app = builder.Build();
app.UseCors("CorsPolicy");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors();
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chatHub");

app.MapRazorPages();

app.Run();
