using UnityEngine;

public abstract class OrbiterHolder : MonoBehaviour {

    public Transform followthis;

    public float xAxis;
    public float yAxis;
    // for orbiting
    public bool orbitActive = true;
    public float orbitProgress;
    public float orbitPeriod;

    public Ellipse ellipse;
    public UIManager ui;
    public CameraManager camManager;

    // for rotating
    public Vector3 rotation;
    public float selfRotateSpeed;

    public abstract void Initialize();

    public void Start()
    {
        ui = UIManager.instance;
        camManager = CameraManager.instance;
    }

    public void CalculateOrbit()
    {
        Vector2 orbitPos = ellipse.Evaluate(orbitProgress);
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;

        if (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
        }

        Vector3 p = followthis.position;
        transform.position = new Vector3(p.x + orbitPos.x,p.y + 0, p.z + orbitPos.y);
    }

    public void Rotate()
    {
        transform.Rotate(rotation * Time.deltaTime * selfRotateSpeed);
    }

    public void setAxes(int xAxis, int yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    public void setAxes(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    public abstract void OnClick();
}
