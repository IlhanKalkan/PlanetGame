using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    public List<Resource> resources;

    public Dictionary<string, int> resourceAmounts = new Dictionary<string, int>();

    private UIManager uim;

    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        uim = UIManager.instance;

        foreach (Resource r in resources)
        {
            resourceAmounts.Add(r.name, r.amount);
            uim.InitResource(r);
        }
    }

    public bool Add(string resourceName, int amount)
    {
        resourceAmounts[resourceName] += amount;
        return true;
    }

    public bool Deduct(string resourceName, int amount)
    {
        if (CanDeduct(resourceName, amount))
        {
            resourceAmounts[resourceName] -= amount;
            return true;
        }
        return false;
    }

    public bool CanDeduct(string resourceName, int amount)
    {
        int amt = resourceAmounts[resourceName];
        if ((amt - amount) < 0)
        {
            return false;
        }
        return true;
    }

    public bool CanCraft(Building building)
    {
        foreach(Resource r in building.recipe.requiredResources)
        {
            if (!CanDeduct(r.name, r.amount))
            {
                return false;
            }
        }
        return true;
    }
}
