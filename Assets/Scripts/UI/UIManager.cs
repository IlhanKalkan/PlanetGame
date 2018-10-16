using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject PlanetsPanel;
    public GameObject MoonsPanel;
    public Button PlanetBtn;
    public Button MoonBtn;

    [HideInInspector]
    public List<Button> PlanetBtns;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void AddPlanetBtn(GameObject planetGameObject)
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

    public void AddMoonBtn(GameObject moonGameObject)
    {
        // Create and initialize button
        Button btn = Instantiate(MoonBtn);
        var script = btn.GetComponent<UIMoonButton>();
        script.moonGameObject = moonGameObject;
        btn.transform.SetParent(MoonsPanel.transform, false);

        // Set button text
        var text = btn.GetComponentInChildren<Text>();
        Moon m = moonGameObject.GetComponentInChildren<Moonholder>().moon;
        text.text = m.name;
    }

    public void ClearMoonBtns()
    {
        foreach (Transform child in MoonsPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
