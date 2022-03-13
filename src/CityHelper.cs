using ColossalFramework.UI;

namespace AllHelpers
{
    public class CityHelper
    {
        // Display City Name on Startup
        public void DisplayCityName()
        {
            string sCityName = SimulationManager.instance.m_metaData.m_CityName;
            ExceptionPanel exceptionPanel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            exceptionPanel.SetMessage(sCityName, "Welcome back to your beautiful city, " + sCityName + ", mayor!", false);
        }     
    }
}
