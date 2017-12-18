using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UnifiedAutomation.UaBase;

namespace AssemblyStationClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // applications without a UnifiedAutomation license embedded as a resource will stop working after 1 hour.
            ApplicationLicenseManager.AddProcessLicenses(System.Reflection.Assembly.GetExecutingAssembly(), "UnifiedAutomation.Sample.License.License.lic");

            // Create the certificate if it does not exist yet
            ApplicationInstance.Default.AutoCreateCertificate = true;

            // start the application.
            ApplicationInstance.Default.Start();
        }
    }
}
