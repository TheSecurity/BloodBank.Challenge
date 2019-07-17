using System;
using BloodBank.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.ConsoleApp
{
    public class DependencyContainer
    {
        public static IServiceProvider SetupServiceProvider
            => new ServiceCollection()
                .AddSingleton<UserInterface>()
                .AddSingleton<IPersonService, PersonService>()
                .BuildServiceProvider();
    }
}