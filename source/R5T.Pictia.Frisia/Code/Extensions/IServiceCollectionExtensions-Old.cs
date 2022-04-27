using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Frisia;


namespace R5T.Pictia.Frisia
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FrisiaSftpClientWrapperProvider"/> implementation of <see cref="ISftpClientWrapperProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFrisiaSftpClientWrapperProvider_Old(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerSecretsProvider> addAwsEc2ServerSecretsProvider)
        {
            services
                .AddSingleton<ISftpClientWrapperProvider, FrisiaSftpClientWrapperProvider>()
                .RunServiceAction(addAwsEc2ServerSecretsProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FrisiaSftpClientWrapperProvider"/> implementation of <see cref="ISftpClientWrapperProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISftpClientWrapperProvider> AddFrisiaSftpClientWrapperProviderAction_Old(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerSecretsProvider> addAwsEc2ServerSecretsProvider)
        {
            var serviceAction = new ServiceAction<ISftpClientWrapperProvider>(() => services.AddFrisiaSftpClientWrapperProvider_Old(
                addAwsEc2ServerSecretsProvider));
            return serviceAction;
        }
    }
}
