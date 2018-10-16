using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseDrawer : MonoBehaviour {

    public GameObject linePrefab;
    Vector3[] points;

    private void Start()
    {
        points = new Vector3[12];

        for (int i = 5; i <= 50; i += 5)
        {
            drawCircle(i);
        }
    }

    private void drawCircle(int width)
    {
        Ellipse e = new Ellipse(width, width);
        for (int i = 0; i < 12; i++)
        {
            Vector2 v = e.Evaluate(i * (1f / 12f));
            points[i] = new Vector3(v.x, 0, v.y);
        }
        GameObject lineholder = GameObject.Instantiate(linePrefab);
        lineholder.transform.SetParent(this.transform);
        LineRenderer lr = lineholder.AddComponent<LineRenderer>();
        lr.positionCount = 12;
        lr.SetPositions(points);
        lr.loop = true;
        lr.startWidth = 0.5f;
        lr.endWidth = 0.5f;
    }
}
