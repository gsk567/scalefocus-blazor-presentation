using BlazorPresent.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// ---------|||||||----------
// ----------|||||-----------
// -----------|||------------
// ------------|-------------
bool serverSideBlazor = false;
// ------------|-------------
// -----------|||------------
// ----------|||||-----------
// ---------|||||||----------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();


if (serverSideBlazor)
{
    builder.Services.AddServerSideBlazor();

    builder.Services.AddTransient<ITransientIdProvider, TransientIdProvider>();
    builder.Services.AddScoped<IScopedIdProvider, ScopedIdProvider>();
    builder.Services.AddSingleton<ISingletonIdProvider, SingletonIdProvider>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    if (serverSideBlazor)
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseWebAssemblyDebugging();
    }
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();

if (serverSideBlazor)
{
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
}
else
{
    app.MapFallbackToFile("index.html");
}

app.Run();
