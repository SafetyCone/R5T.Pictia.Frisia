using System;

using R5T.Frisia;
using R5T.Pictia.Frisia.Extensions;

using R5T.T0064;


namespace R5T.Pictia.Frisia
{
    [ServiceImplementationMarker]
    public class FrisiaSftpClientWrapperProvider : ISftpClientWrapperProvider, IServiceImplementation
    {
        public IAwsEc2ServerSecretsProvider AwsEc2ServerSecretsProvider { get; }


        public FrisiaSftpClientWrapperProvider(IAwsEc2ServerSecretsProvider awsEc2ServerSecretsProvider)
        {
            this.AwsEc2ServerSecretsProvider = awsEc2ServerSecretsProvider;
        }

        public SftpClientWrapper GetSftpClientWrapper(bool connected = true)
        {
            var awsEc2ServerSecrets = this.AwsEc2ServerSecretsProvider.GetAwsEc2ServerSecrets();

            var sftpClientWrapper = awsEc2ServerSecrets.GetSftpClientWrapper();
            return sftpClientWrapper;
        }
    }
}
