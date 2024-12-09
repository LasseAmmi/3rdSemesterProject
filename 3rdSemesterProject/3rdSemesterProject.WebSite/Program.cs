using _3rdSemesterProject.WebSite.APIClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Here the builder assigns that any class the calls for a IRestClient is given a RestAPIClient with this given BaseURI
builder.Services.AddSingleton<IRestClient>((_) => new RestAPIClient("https://localhost:7034/api/v1/"));
//If need ever be is on the line under this written a line which redirects the IRestClient to a STUB
//builder.Services.AddSingleton<IRestClient>((_) => new RestAPIClientStub());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
