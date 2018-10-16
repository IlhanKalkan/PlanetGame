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

    public void AddBtn(Planet planet)
    {
        Button g = Instantiate(PlanetBtn);
        var script = g.GetComponent<UIPlanetButton>();
        script.planet = planet;
        g.transform.SetParent(PlanetsPanel.transform, false);
        var text = g.GetComponentInChildren<Text>();
        text.text = planet.name;
    }
}
