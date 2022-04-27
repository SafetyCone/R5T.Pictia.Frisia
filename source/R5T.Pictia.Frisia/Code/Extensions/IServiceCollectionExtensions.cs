using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Frisia;

using R5T.T0063;


namespace R5T.Pictia.Frisia
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FrisiaSftpClientWrapperProvider"/> implementation of <see cref="ISftpClientWrapperProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFrisiaSftpClientWrapperProvider(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerSecretsProvider> addAwsEc2ServerSecretsProvider)
        {
            services
                .Run(addAwsEc2ServerSecretsProvider)
                .AddSingleton<ISftpClientWrapperProvider, FrisiaSftpClientWrapperProvider>()
                ;

            return services;
        }
    }
}
