using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject planetPrefab;
    public GameObject moonPrefab;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
	
	public GameObject instantiate(Transform parent, Planet objectPlanet)
    {
        GameObject planet = (GameObject)Instantiate(planetPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        planet.transform.parent = parent;
        GameObject p = planet.transform.GetChild(0).gameObject;
        p.GetComponent<Planetholder>().Initialize();
        p.GetComponent<Planetholder>().planet = objectPlanet;
        p.name = objectPlanet.name;
        Debug.Log("Planet initialized: " + planet.name);

        return planet;
    }

    public GameObject instantiate(Transform parent, Moon objectMoon)
    {
        GameObject moon = (GameObject)Instantiate(moonPrefab);
        moon.transform.SetParent(parent);
        GameObject m = moon.transform.GetChild(0).gameObject;
        m.GetComponent<Moonholder>().moon = objectMoon;
        m.GetComponent<Moonholder>().Initialize();
        m.name = objectMoon.name;
        Debug.Log("Moon initialized:  " + moon.name);

        return moon;
    }
}
