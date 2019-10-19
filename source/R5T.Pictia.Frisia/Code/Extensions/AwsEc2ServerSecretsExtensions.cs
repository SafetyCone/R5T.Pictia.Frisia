using System;

using Renci.SshNet;

using R5T.Frisia;


namespace R5T.Pictia.Frisia.Extensions
{
    public static class AwsEc2ServerSecretsExtensions
    {
        public static ConnectionInfo GetConnectionInfo(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var connectionInfo = Utilities.GetConnectionInfo(
                awsEc2ServerSecrets.HostUrl,
                awsEc2ServerSecrets.UserID,
                awsEc2ServerSecrets.Password,
                awsEc2ServerSecrets.PrivateKeyFilePath);
            return connectionInfo;
        }

        /// <summary>
        /// Gets a <see cref="SftpClientWrapper"/> for which the Connect() method has NOT been called.
        /// </summary>
        public static SftpClientWrapper GetUnconnectedSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var connectionInfo = awsEc2ServerSecrets.GetConnectionInfo();

            var clientWrapper = new SftpClientWrapper(connectionInfo);
            return clientWrapper;
        }

        /// <summary>
        /// Gets a connected <see cref="SftpClientWrapper"/>.
        /// </summary>
        public static SftpClientWrapper GetConnectedSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var clientWrapper = awsEc2ServerSecrets.GetUnconnectedSftpClientWrapper();

            clientWrapper.SftpClient.Connect();

            return clientWrapper;
        }

        /// <summary>
        /// Gets a connected <see cref="SftpClientWrapper"/>.
        /// </summary>
        public static SftpClientWrapper GetSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var output = awsEc2ServerSecrets.GetConnectedSftpClientWrapper();
            return output;
        }

        /// <summary>
        /// Gets a <see cref="SshClientWrapper"/> for which the Connect() method has NOT been called.
        /// </summary>
        public static SshClientWrapper GetUnconnectedSshClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var connectionInfo = awsEc2ServerSecrets.GetConnectionInfo();

            var clientWrapper = new SshClientWrapper(connectionInfo);
            return clientWrapper;
        }

        /// <summary>
        /// Gets a connected <see cref="SshClientWrapper"/>.
        /// </summary>
        public static SshClientWrapper GetConnectedSshClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var clientWrapper = awsEc2ServerSecrets.GetUnconnectedSshClientWrapper();

            clientWrapper.SshClient.Connect();

            return clientWrapper;
        }

        /// <summary>
        /// Gets a connected <see cref="SshClientWrapper"/>.
        /// </summary>
        public static SshClientWrapper GetSshClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var output = awsEc2ServerSecrets.GetConnectedSshClientWrapper();
            return output;
        }
    }
}
