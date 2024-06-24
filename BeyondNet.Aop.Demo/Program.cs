using System;
using System.IO;
using System.Reflection;
using Common.Logging;
using Common.Logging.Configuration;
using LightInject;
using Microsoft.Extensions.Configuration;

using BeyondNet.Aop.Demo;
using BeyondNet.Bootstrapper.LightInject;
using BeyondNet.Aop.Installer;
using BeyondNet.Aop.Logger.Serilog;


var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (string.IsNullOrWhiteSpace(env))
{
    env = "Development";
}

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

var applicationname = $"{config["ApplicationName"]}";

var logging = config.GetSection("Logging").Get<LogConfiguration>();
LogManager.Configure(logging);


var iocbootstrapper = new LightInjectBootStrapper( serviceContainer =>
{
    serviceContainer.AddAop(action: c =>
    {
        c.AddLogger<SerilogLogger>();
    });      
});


