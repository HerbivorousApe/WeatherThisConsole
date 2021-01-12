using System.Threading.Tasks;
using WeatherThisConsole.Views;

namespace WeatherThisConsole
{
    class Program
    {
        static async Task Main()
        {    
            var view = new MainWelcomeView();
                view.Header();

            var apiView = new APICallsView();
                await apiView.GetGeoDataFromIP();
                await apiView.GetLocationData();
        }
    }
}