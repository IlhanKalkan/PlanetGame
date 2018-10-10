using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHolder : MonoBehaviour {

    public Sun sun;

    private Vector3 rotation;
    private float selfRotateSpeed;

    private List<GameObject> goPlanets = new List<GameObject>();

    // Use this for initialization
    void Start () {
        transform.localScale = sun.Size;
        GetComponent<Renderer>().material = sun.material;
        rotation = new Vector3(sun.xRotation, sun.yRotation, sun.zRotation);
        selfRotateSpeed = sun.selfRotateSpeed;

        GameManager m = GameManager.instance;
        foreach(Planet p in sun.planets)
        {
            goPlanets.Add(m.instantiate(transform, p));
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation * Time.deltaTime * selfRotateSpeed);
    }
}
