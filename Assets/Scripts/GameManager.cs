using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject planetPrefab;
    public GameObject moonPrefab;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
	
	public GameObject instantiate(Sun sun, Transform parent, int nthPlanet, Planet objectPlanet)
    {
        if (sun.Xorbits.Count < nthPlanet)
        {
            return null;
        }
        if (sun.Yorbits.Count < nthPlanet)
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
        script.xAxis = sun.Xorbits[nthPlanet];
        Debug.Log("planet " + objectPlanet.name + " xorbit set to " + sun.Xorbits[nthPlanet].ToString());
        script.yAxis = sun.Yorbits[nthPlanet];
        Debug.Log("planet " + objectPlanet.name + " yorbit set to " + sun.Yorbits[nthPlanet].ToString());
        p.name = objectPlanet.name;
        //Debug.Log("Planet initialized: " + planet.name);

        return planet;
    }

    public GameObject instantiate(Transform parent, Moon objectMoon)
    {
        GameObject moon = (GameObject)Instantiate(moonPrefab);
        moon.transform.SetParent(parent.parent);
        GameObject m = moon.transform.GetChild(0).gameObject;
        m.GetComponent<Moonholder>().moon = objectMoon;
        m.GetComponent<Moonholder>().Initialize();
        m.name = objectMoon.name;
        //Debug.Log("Moon initialized:  " + moon.name);

        return moon;
    }
}
