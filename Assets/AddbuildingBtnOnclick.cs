using UnityEngine;

public class AddbuildingBtnOnclick : MonoBehaviour {

    public void onClick()
    {
        // if store gets opened
        if (UIManager.instance.ToggleStore())
        {
            Store.instance.showBuildings(0);
        }
    }

}
