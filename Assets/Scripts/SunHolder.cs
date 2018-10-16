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
        UIManager ui = UIManager.instance;
        for (int i = 0; i < sun.planets.Count; i++)
        {
            //Debug.Log("found planet in sun.planets:" + p.name.ToString());
            Planet p = sun.planets[i];
            GameObject g = m.instantiate(sun, transform, i, p);
            if (g != null)
            {
                goPlanets.Add(g);
                ui.AddBtn(g);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation * Time.deltaTime * selfRotateSpeed);
    }
}
