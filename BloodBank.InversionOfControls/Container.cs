using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.InversionOfControls
{
    public static class Container
    {
        public static IServiceCollection GetServices()
            => new ServiceCollection();
    }
}
