using System;

using R5T.Frisia;
using R5T.Pictia.Frisia.Extensions;


namespace R5T.Pictia.Frisia
{
    public class FrisiaSftpClientWrapperProvider : ISftpClientWrapperProvider
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
