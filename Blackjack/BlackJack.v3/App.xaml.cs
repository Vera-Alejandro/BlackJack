using BlackJack.v3.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace BlackJack.v3
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            _host = HostFactory.Create();
            ServiceProvider = _host.Services;
        }
    }
}
