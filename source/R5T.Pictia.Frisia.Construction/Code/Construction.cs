using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Pictia.Frisia.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            Construction.TestGetConnectedSftpClientWrapper();
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
