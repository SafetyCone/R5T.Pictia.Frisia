using System;
using System.IO;

using Microsoft.Extensions.DependencyInjection;

using R5T.Pictia.Extensions;


namespace R5T.Pictia.Frisia.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            //Construction.TestGetConnectedSftpClientWrapper();
            //Construction.TestGetOutputOfSshCommand("PATH GOES HERE!"); // Note: public!!! Be careful not to check-in identifying paths!
        }

        private static void TestGetOutputOfSshCommand(string directoryPath)
        {
            var serviceProvider = Program.GetServiceProvider();

            using (var sftpClientWrapper = serviceProvider.GetRequiredService<SftpClientWrapper>())
            using (var sshClientWrapper = sftpClientWrapper.GetSshClientWrapper())
            {
                var commandText = $"find \"{directoryPath}\" -print -ls";
                using (var command = sshClientWrapper.SshClient.CreateCommand(commandText))
                {
                    var output = command.Execute();
                    Console.WriteLine(output);
                }
            }
        }

        private static void TestGetConnectedSftpClientWrapper()
        {
            var serviceProvider = Program.GetServiceProvider();

            using (var sftpClientWrapper = serviceProvider.GetRequiredService<SftpClientWrapper>())
            {
                Console.WriteLine($"Is connected: {sftpClientWrapper.SftpClient.IsConnected}");
            }
        }
    }
}
