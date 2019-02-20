using System;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace ConsoleAppWithSerilog
{
    class Program
    {
            const string logDB = @"Data Source=PANTALONE;Initial Catalog=RELog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            const string logTable = "Logs";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));


            //var options = new ColumnOptions();
            //options.Store.Remove(StandardColumn.Properties);
            //options.Store.Add(StandardColumn.LogEvent);
            //options.LogEvent.DataLength = 2048;
            //options.PrimaryKey = options.TimeStamp;
            //options.TimeStamp.NonClusteredIndex = true;

            //var log = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.MSSqlServer(autoCreateSqlTable:true,
            //        connectionString: logDB,
            //        tableName: logTable
            //  //      columnOptions: options
            //    ).CreateLogger();


            //for (int i = 0; i < 1000; i++)
            //{
            //    var position = new { Latitude = 25, Longitude = 134 };
            //    var elapsedMs = 34;

            //    log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);


            //    log.Information("dfdfdfd", 100);


            //    log.Verbose("dfhfgjfjfgjfgjfjfjfj");
            //}

            //Log.CloseAndFlush();

            //Console.ReadLine();





            try
            {
                Log.Information("Starting web host");
                BuildWebHost(args).Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((context, configuration) =>
                {
                    configuration
                        .Enrich.WithMemoryUsage()
                        .Enrich.WithProcessId()
                        .Enrich.WithProcessName()
                        .MinimumLevel.Debug()
                        .WriteTo.MSSqlServer(
                            autoCreateSqlTable: true,
                            connectionString: logDB,
                            tableName: logTable
                            //      columnOptions: options
                        );
                })
                .Build();
    }




}
