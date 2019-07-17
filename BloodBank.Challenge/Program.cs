using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.ConsoleApp
{
    public class Program
    {
        public async void Main()
        {
            var services = DependencyContainer.SetupServiceProvider;
            await services.GetRequiredService<UserInterface>().Initialize();
        }
        
    }
}
