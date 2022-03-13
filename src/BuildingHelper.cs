using System.Text;
using ColossalFramework.UI;

namespace AllHelpers
{
    public class BuildingHelper
    {
        // Removes Specified Props from Buildings
        public void RemoveBuildingProps()
        {
            string sMessage = "Removing props:\n";
            for (uint iBuilding = 0; iBuilding < PrefabCollection<BuildingInfo>.LoadedCount(); iBuilding++)
            {
                // Retrieve All Loaded Building Prefabs
                BuildingInfo buildingInfo = PrefabCollection<BuildingInfo>.GetLoaded(iBuilding);

                // Only Remove Props from Buildings with Props
                if (buildingInfo != null && buildingInfo.m_props != null)
                {
                    bool bFoundProp = false;
                    for (uint iProp = 0; iProp < buildingInfo.m_props.Length; iProp++)
                    {
                        BuildingInfo.Prop prop = buildingInfo.m_props[iProp];

                        // Parse Trees, etc
                        if (prop.m_prop != null)
                        {
                            string sPropName = prop.m_prop.name.ToLower();
                            if (sPropName.StartsWith("billboard_big") ||
                                sPropName == "neon-yakisoba-noodles" ||
                                sPropName == "neon-burned-bean-coffee" ||
                                sPropName == "neon-morellos")
                            {
                                prop.m_probability = 0;
                                if (!bFoundProp)
                                {
                                    sMessage += buildingInfo.name + "\n";
                                }
                                sMessage += "\t" + sPropName + "\n";
                            }
                        }
                    }
                }
            }

            // Configure Dialogue Panel to Display Names of Props Removed
            ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            panel.SetMessage("Remove It", sMessage, false);
        }

        // Retrieve All Building Names
        public void ListBuildingNames()
        {
            // Get Total Building Prefab Count
            int iBuildingInfoCount = PrefabCollection<BuildingInfo>.LoadedCount();
            StringBuilder sbBuildings = new StringBuilder();

            // Generate List of All Building Names
            for (uint i = 0; i < iBuildingInfoCount; i++)
            {
                BuildingInfo buildingInfo = PrefabCollection<BuildingInfo>.GetLoaded(i);
                if (i != 0) { sbBuildings.Append(", "); }
                sbBuildings.Append(buildingInfo.name);
            }

            // Configure Dialogue Panel to Display All Building Names
            ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            panel.SetMessage("Remove It", sbBuildings.ToString(), false);
        }
    }
}
