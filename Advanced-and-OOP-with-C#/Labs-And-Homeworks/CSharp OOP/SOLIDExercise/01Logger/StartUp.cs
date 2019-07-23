using System;
using System.Collections.Generic;

using _01Logger.Models.Contracts;
using _01Logger.Factories;
using _01Logger.Core;

namespace _01Logger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppenderData(appendersCount, appenders, appenderFactory);
            ILogger logger = new Models.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppenderData(int appendersCount, ICollection<IAppender> appenders,
            AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];
                string levelString = "INFO";

                if (appenderInfo.Length == 3)
                {
                    levelString = appenderInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelString);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
