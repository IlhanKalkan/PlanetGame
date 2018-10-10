using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {

    public List<Planet> planets;
    private GameManager GM;

    public List<GameObject> planetObjects;

    private void Start()
    {
        GM = GameManager.instance;
        foreach(Planet p in planets)
        {
            planetObjects.Add(GM.instantiate(transform, p));
        }
    }
}
