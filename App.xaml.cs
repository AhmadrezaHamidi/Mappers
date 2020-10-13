using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using BookAndShelve.DbContext;

namespace BookAndShelve
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer("Server = .; Database=bookAndShelveData;Integrated Security = true;");
            });
        }
    }
}
