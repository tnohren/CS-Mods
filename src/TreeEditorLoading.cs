using ICities;

namespace TreeEditor
{
    public class TreeEditorLoading : ILoadingExtension
    {
        public void OnCreated(ILoading loading)
        {

        }

        public void OnLevelLoaded(LoadMode mode)
        {
            // Replace all road trees with California Palm
            AllHelpers.CityHelper cityHelper = new AllHelpers.CityHelper();
            cityHelper.DisplayCityName();

            AllHelpers.BuildingHelper buildingHelper = new AllHelpers.BuildingHelper();
            buildingHelper.RemoveBuildingProps();

            AllHelpers.TreeHelper treeHelper = new AllHelpers.TreeHelper();
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
