using FontCreator.MVVM.ViewModels;
using FontCreator.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace FontCreator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? _AppHost;

        public App()
        {
            _AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {

                    services.AddTransient<IMainViewModel, MainViewModel>();
                    services.AddTransient(provider => new MainWindow
                    {
                        DataContext = provider.GetRequiredService<IMainViewModel>()
                    });

                }).Build();
        }

        /// <inheritdoc cref="Application.OnStartup"/>
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _AppHost!.StartAsync();
            var startUpWindows = _AppHost.Services.GetRequiredService<MainWindow>();
            startUpWindows.Show();
            base.OnStartup(e);
        }

        /// <inheritdoc cref="Application.OnExit"/>
        protected override async void OnExit(ExitEventArgs e)
        {
            await _AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
