using System;
using BloodBank.Core.DataStorage;
using BloodBank.Core.Services;
using BloodBank.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.ConsoleApp
{
    public class DependencyContainer
    {
        public static IServiceProvider SetupServiceProvider
            => new ServiceCollection()
                .AddSingleton<UserInterface>()
                .AddSingleton<IPersonService, PersonService>()
                .AddSingleton<IDataStorage, DataStorage>()
                .AddSingleton<IDataProvider, DataProvider>()
                .AddSingleton<PersonPropertyValidator>()
                .BuildServiceProvider();
    }
}