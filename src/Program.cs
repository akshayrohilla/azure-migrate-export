using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;
using System;
using System.Windows.Forms;

using Azure.Migrate.Export.Authentication;
using Azure.Migrate.Export.Forms;

namespace Azure.Migrate.Export
{
    static class Program
    {
        public static string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
        public static string CommonAuthorityEndpoint = "https://login.microsoftonline.com/common/oauth2/authorize";
        public static string TenantAuthorityEndpoint = "https://login.microsoftonline.com/_tenantID/oauth2/authorize";
        public static IPublicClientApplication clientApp;
        private static NativeWindow NativeWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AzureMigrateExportMainForm());
        }

        public static IPublicClientApplication PublicClientApp { get { return clientApp; } }

        public static void InitializeCommonAuthentication(NativeWindow nativeWindow)
        {
            NativeWindow = nativeWindow;

            clientApp = PublicClientApplicationBuilder.Create(PowerShellClientId)
                                                      .WithAuthority(new Uri(CommonAuthorityEndpoint))
                                                      .WithParentActivityOrWindow(GetWindowHandle)
                                                      .WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows)
                                                      {
                                                          Title = "Azure Migrate Export",
                                                      })
                                                      .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);
        }

        public static void InitializeTenantAuthentication(string tenantID, NativeWindow nativeWindow)
        {
            NativeWindow = nativeWindow;

            string finalAuthorityEndpoint = TenantAuthorityEndpoint.Replace("_tenantID", tenantID);
            clientApp = PublicClientApplicationBuilder.Create(PowerShellClientId)
                                                      .WithAuthority(new Uri(finalAuthorityEndpoint))
                                                      .WithParentActivityOrWindow(GetWindowHandle)
                                                      .WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows)
                                                      {
                                                          Title = "Azure Migrate Export",
                                                      })
                                                      .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);
        }

        private static IntPtr GetWindowHandle()
        {
            return NativeWindow.Handle;
        }
    }
}
