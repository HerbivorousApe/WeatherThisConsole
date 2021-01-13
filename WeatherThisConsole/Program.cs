using System.Threading.Tasks;
using WeatherThisConsole.Views;

namespace WeatherThisConsole
{
    class Program
    {
        static async Task Main()
        {    
            MainWelcomeView.Header();

            await APICallsView.GetGeoDataFromIP();
            await APICallsView.GetLocationData();

        }
    }
}