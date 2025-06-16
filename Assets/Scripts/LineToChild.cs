using UnityEngine;

public class LineToChild : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public Color color;
    LineRenderer lr;

    public void Set(Transform _origin,Transform _target, Color _color)
    {
        origin = _origin;
        target = _target;
        color = _color;
    }
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.widthMultiplier = 0.05f;
        lr.useWorldSpace = true;
        lr.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {
        if (origin != null && target != null && lr != null)
        {
            lr.SetPosition(0, origin.position);
            lr.SetPosition(1, target.position);
        }
    }
    //public void Enable
}
