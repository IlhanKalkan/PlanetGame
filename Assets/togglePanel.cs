using UnityEngine;

public class togglePanel : MonoBehaviour {

    public void toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
