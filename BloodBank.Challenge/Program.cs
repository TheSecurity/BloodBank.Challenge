using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.ConsoleApp
{
    public class Program
    {
        public static async Task Main()
        {
            var services = DependencyContainer.SetupServiceProvider;
            await services.GetRequiredService<UserInterface>().Initialize();
        }
        
    }
}
