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
        planet.transform.SetParent(parent);
        planet.GetComponent<Planetholder>().Initialize();
        planet.GetComponent<Planetholder>().planet = objectPlanet;
        planet.name = objectPlanet.name;
        Debug.Log("Planet initialized: " + planet.name);

        return planet;
    }

    public GameObject instantiate(Transform parent, Moon objectMoon)
    {
        GameObject moon = (GameObject)Instantiate(moonPrefab);
        moon.transform.SetParent(parent);
        moon.GetComponent<Moonholder>().moon = objectMoon;
        moon.GetComponent<Moonholder>().Initialize();
        moon.name = objectMoon.name;
        Debug.Log("Moon initialized:  " + moon.name);

        return moon;
    }
}
