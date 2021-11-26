using BlazorPresent.Client;
using BlazorPresent.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<ITransientIdProvider, TransientIdProvider>();
builder.Services.AddScoped<IScopedIdProvider, ScopedIdProvider>();
builder.Services.AddSingleton<ISingletonIdProvider, SingletonIdProvider>();

await builder.Build().RunAsync();
