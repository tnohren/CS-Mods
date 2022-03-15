using ICities;
using AllHelpers;

namespace TreeEditor
{
    public class TreeEditorLoading : ILoadingExtension
    {
        public void OnCreated(ILoading loading)
        {

        }

        public void OnLevelLoaded(LoadMode mode)
        {
            // Simply displays city name in context panel
            CityHelper cityHelper = new CityHelper();
            cityHelper.DisplayCityName();

            // Removes billboards and neon signs
            BuildingHelper buildingHelper = new BuildingHelper();
            buildingHelper.RemoveBuildingProps();

            // Replace all road trees with California Palm
            TreeHelper treeHelper = new TreeHelper();
            treeHelper.DefaultAllRoadTrees("");
        }

        public void OnLevelUnloading()
        {

        }

        public void OnReleased()
        {

        }
    }
}
