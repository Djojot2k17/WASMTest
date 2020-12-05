﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WASMTest.Server.Utilities;

namespace WASMTest.Server
{
  public class Program
  {
    public async static Task Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      await DataHelper.ManageData(host);
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.CaptureStartupErrors(true);
              webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
              webBuilder.UseStartup<Startup>();
            });
  }
}
