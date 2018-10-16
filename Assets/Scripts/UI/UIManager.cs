using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject PlanetsPanel;
    public Button PlanetBtn;

    [HideInInspector]
    public List<Button> PlanetBtns;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void AddBtn(GameObject planetGameObject)
    {
        // Create and initialize button
        Button btn = Instantiate(PlanetBtn);
        var script = btn.GetComponent<UIPlanetButton>();
        script.planetGameObject = planetGameObject;
        btn.transform.SetParent(PlanetsPanel.transform, false);

        // Set button text
        var text = btn.GetComponentInChildren<Text>();
        Planet p = planetGameObject.GetComponentInChildren<Planetholder>().planet;
        text.text = p.name;
    }
}
