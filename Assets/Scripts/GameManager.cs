using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject planetPrefab;
    public GameObject moonPrefab;

	// Use this for initialization
	void Awake () {
        instance = this;
	}

    public GameObject instantiate(Sun parentSun, Transform parent, int nthPlanet, Planet objectPlanet)
    {
        if (parentSun.Xorbits.Count < nthPlanet)
        {
            return null;
        }
        if (parentSun.Yorbits.Count < nthPlanet)
        {
            return null;
        }
        GameObject planet = (GameObject)Instantiate(planetPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        planet.transform.parent = parent.parent;
        GameObject p = planet.transform.GetChild(0).gameObject;
        var script = p.GetComponent<Planetholder>();
        script.planet = objectPlanet;
        script.Initialize();
        // Set orbit
        script.xAxis = parentSun.Xorbits[nthPlanet];
        //Debug.Log("planet " + objectPlanet.name + " xorbit set to " + parentSun.Xorbits[nthPlanet].ToString());
        script.yAxis = parentSun.Yorbits[nthPlanet];
        //Debug.Log("planet " + objectPlanet.name + " yorbit set to " + parentSun.Yorbits[nthPlanet].ToString());
        p.name = objectPlanet.name;
        //Debug.Log("Planet initialized: " + planet.name);

        return planet;
    }

    public GameObject instantiate(Planet parentPlanet, Transform parent, int nthMoon, Moon objectMoon)
    {
        if (parentPlanet.Xorbits.Count < nthMoon)
        {
            return null;
        }
        if (parentPlanet.Yorbits.Count < nthMoon)
        {
            return null;
        }
        GameObject moon = (GameObject)Instantiate(moonPrefab);
        moon.transform.SetParent(parent.parent);
        GameObject m = moon.transform.GetChild(0).gameObject;
        var script = m.GetComponent<Moonholder>();
        script.moon = objectMoon;
        script.Initialize();
        // Set orbit
        script.xAxis = parentPlanet.Xorbits[nthMoon];
        //Debug.Log("moon " + objectMoon.name + " xorbit set to " + parentPlanet.Xorbits[nthMoon].ToString());
        script.yAxis = parentPlanet.Yorbits[nthMoon];
        //Debug.Log("moon " + objectMoon.name + " yorbit set to " + parentPlanet.Yorbits[nthMoon].ToString());
        m.name = objectMoon.name;
        //Debug.Log("Moon initialized:  " + moon.name);

        return moon;
    }
}
