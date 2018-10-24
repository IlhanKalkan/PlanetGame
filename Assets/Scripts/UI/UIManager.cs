using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [Header("OrbiterPanels")]
    public GameObject PlanetsPanel;
    public GameObject MoonsPanel;
    public Button PlanetBtn;
    public Button MoonBtn;

    [Header("Resource Panel")]
    public GameObject ResourcesPanel;
    public GameObject ResourcePrefab;

    [Header("Pop-ups")]
    public GameObject PopupPanel;
    public GameObject textPrefab;

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

    public void ShowPopup(Planetholder p)
    {
        PopupPanel.SetActive(true);
        PopupPanel.transform.GetChild(0).GetComponent<Text>().text = p.planet.name;

        ClearImgChildren();
        var t = PopupPanel.transform.GetChild(2);
        foreach(Building b in p.planet.Buildings)
        {
            var txt = Instantiate(textPrefab) as GameObject;
            txt.transform.SetParent(t, false);
            txt.GetComponentInChildren<Text>().text = b.name;
        }
    }

    public void ShowPopup(Moonholder m)
    {
        PopupPanel.SetActive(true);
        PopupPanel.transform.GetChild(0).GetComponent<Text>().text = m.moon.name;

        ClearImgChildren();
        var t = PopupPanel.transform.GetChild(2);
        foreach (Building b in m.moon.Buildings)
        {
            var txt = Instantiate(textPrefab) as GameObject;
            txt.transform.SetParent(t, false);
            txt.GetComponentInChildren<Text>().text = b.name;
        }
    }

    private void ClearImgChildren()
    {
        foreach(Transform child in PopupPanel.transform.GetChild(2))
        {
            Destroy(child.gameObject);
        }
    }

    public void HidePopup()
    {
        ClearImgChildren();
        PopupPanel.SetActive(false);
    }

    public void InitResource(Resource r)
    {
        GameObject UIResource = GameObject.Instantiate(ResourcePrefab);
        UIResource.transform.GetChild(1).GetComponent<Image>().sprite = r.sprite;
        UIResource.GetComponentInChildren<Text>().text = r.amount.ToString();
        UIResource.transform.SetParent(ResourcesPanel.transform, false);
    }
}
