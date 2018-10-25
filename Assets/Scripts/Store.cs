using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    public static Store instance;

    public List<Building> ResourceBuildings;
    public List<Building> ArmyBuildings;
    public List<Building> ScienceBuildings;

    public Dictionary<byte, List<Building>> buyableList;

    private UIManager uim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        uim = UIManager.instance;

        // Initialize dict
        buyableList = new Dictionary<byte, List<Building>>
        {
            { 0, ResourceBuildings },
            { 1, ArmyBuildings },
            { 2, ScienceBuildings }
        };
    }

    public void showBuildings(byte key)
    {
        if (key >= buyableList.Count)
        {
            return;
        }

        var list = buyableList[key];
        showBuildings(list);
    }

    private void showBuildings(List<Building> list)
    {
        uim.ClearStore();
        if (list.Count == 0)
        {
            return;
        }

        foreach(Building b in list)
        {
            if (b != null)
            {
                uim.DrawShopItem(b.name, b.Description, b.recipe);
            }
        }
    }


    // for the buttons
    public void showResources()
    {
        showBuildings(0);
    }

    public void showArmy()
    {
        showBuildings(1);
    }

    public void showScience()
    {
        showBuildings(2);
    }
}
