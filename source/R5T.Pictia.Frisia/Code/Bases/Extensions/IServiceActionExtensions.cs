using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Frisia;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Pictia.Frisia
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FrisiaSftpClientWrapperProvider"/> implementation of <see cref="ISftpClientWrapperProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISftpClientWrapperProvider> AddFrisiaSftpClientWrapperProviderAction(this IServiceAction _,
            IServiceAction<IAwsEc2ServerSecretsProvider> addAwsEc2ServerSecretsProvider)
        {
            var serviceAction = _.New<ISftpClientWrapperProvider>(services => services.AddFrisiaSftpClientWrapperProvider(
                addAwsEc2ServerSecretsProvider));

            return serviceAction;
        }
    }
}
