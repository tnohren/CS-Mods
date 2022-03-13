using UnityEngine;

namespace AllHelpers
{
    public class TreeHelper
    {
        // Replace All Road Trees with Specified Tree Type
        public void DefaultAllRoadTrees(string psNewTree)
        {
            for (uint iNetworks = 0; iNetworks < PrefabCollection<NetInfo>.LoadedCount(); iNetworks++)
            {
                NetInfo networks = PrefabCollection<NetInfo>.GetLoaded(iNetworks);
                SetDefaultTree(networks.name, psNewTree);
            }
        }

        // Replaces a Specified Road Type's Trees with Specified  Tree Type
        private void SetDefaultTree(string psRoadToReplace, string psNewTree)
        {
            // Retrieve roads and tree specified
            NetInfo networks = PrefabCollection<NetInfo>.FindLoaded(psRoadToReplace);
            TreeInfo trees = PrefabCollection<TreeInfo>.FindLoaded(psNewTree);

            if (networks == null)
            {
                Debug.LogError("Network type not found: " + psRoadToReplace);
                return;
            }

            if (trees == null)
            {
                Debug.LogError("Tree type not found: " + psNewTree);
                return;
            }

            Debug.Log("Networks and trees loaded in for " + psRoadToReplace + " and " + psNewTree);

            // Only looking for networks that contain lanes
            if (networks.m_lanes != null)
            {
                foreach (NetInfo.Lane lane in networks.m_lanes)
                {
                    // Only looking for lanes that contain props
                    if (lane.m_laneProps.m_props != null)
                    {
                        foreach (NetLaneProps.Prop prop in lane.m_laneProps.m_props)
                        {
                            if (prop != null)
                            {
                                if (prop.m_tree != null) prop.m_tree = trees;
                                if (prop.m_finalTree != null) prop.m_finalTree = trees;
                            }
                        }
                    }
                }
            }
        }
    }
}
