using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControlScript : MonoBehaviour {

    public GameObject line;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            line.SetActive(!line.activeSelf);
        }
    }
}
