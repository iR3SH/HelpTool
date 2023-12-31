﻿using HelpData;
using HelpData.IRepository;
using HelpData.Repository;
using HelpTool.Languages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Security.Principal;
using System.Windows;

namespace HelpTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            //SharedObjects.IsConfigured = true;
            LanguageSetter.SetLanguage(new CultureInfo("fr-FR"));
            SharedObjects.DbHost = "127.0.0.1";
            SharedObjects.DbName = "tool";
            SharedObjects.DbNameLogin = "tool_login";
            SharedObjects.DbUser = "root";
            SharedObjects.DbPass = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(Configuration);
            serviceCollection.AddMySQLServer<HelpDbContext>("Server=" + SharedObjects.DbHost + "; Database=" + SharedObjects.DbName + "; Uid=" + SharedObjects.DbUser + "; Pwd=" + SharedObjects.DbPass);
            serviceCollection.AddMySQLServer<LoginDbContext>("Server=" + SharedObjects.DbHost + "; Database=" + SharedObjects.DbNameLogin + "; Uid=" + SharedObjects.DbUser + "; Pwd=" + SharedObjects.DbPass);
            serviceCollection.AddTransient<IAccountsRepository, AccountsRepository>();
            serviceCollection.AddTransient<IMonstersRepository, MonstersRepository>();
            serviceCollection.AddTransient<IItemsRepository, ItemsRepository>();
            serviceCollection.AddTransient<IObjectsRepository, ObjectsRepository>();
            serviceCollection.AddTransient<IPlayersRepository, PlayersRepository>();
            serviceCollection.AddTransient<ISortsRepository, SortsRepository>();
            serviceCollection.AddTransient(typeof(MainWindow));

            SharedObjects.ServiceProvider = serviceCollection.BuildServiceProvider();
            var services = SharedObjects.ServiceProvider;
            SharedObjects.Context = services.GetRequiredService<HelpDbContext>();
            SharedObjects.LoginDbContext = services.GetRequiredService<LoginDbContext>();
            SharedObjects.AccountRepository = services.GetRequiredService<IAccountsRepository>();
            SharedObjects.ItemsRepository = services.GetRequiredService<IItemsRepository>();
            SharedObjects.MonstersRepository = services.GetRequiredService<IMonstersRepository>();
            SharedObjects.SortsRepository = services.GetRequiredService<ISortsRepository>();
            SharedObjects.ObjectsRepository = services.GetRequiredService<IObjectsRepository>();
            SharedObjects.PlayersRepository = services.GetRequiredService<IPlayersRepository>();
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //LoadTest(new MonstersRepository(SharedObjects.Context));
        }
        public IConfiguration? Configuration { get; private set; }
    }
}
