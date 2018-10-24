using UnityEngine;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager instance;

    private ResourceManager rm = ResourceManager.instance;

    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }

    public bool Build(Building b)
    {
        if (rm.CanCraft(b)){
            Debug.Log("Building building");
            return true;
        }
        return false;
    }
}
