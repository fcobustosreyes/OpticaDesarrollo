using System.Globalization;
namespace OpticaVision;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-NI");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-NI");
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
