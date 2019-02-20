using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppWithSerilog
{
    internal class Startup //: IStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            //throw new NotImplementedException();

            app.UseDeveloperExceptionPage();
        }

        //public IServiceProvider ConfigureServices(IServiceCollection services)
        public void ConfigureServices(IServiceCollection services)
        {
            //throw new NotImplementedException();

            //services.
        }

    
    }
}