using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiple_Camera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    private Vector3 vel;
    public float time = 0.5f;
    public float min_zoom = 40;
    public float max_zoom = 10;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Move_cam();
        Zoom();
    }

    void Zoom()
    {
        float zoom = Mathf.Lerp(max_zoom, min_zoom, getdist());
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,zoom,Time.deltaTime);
    }
    void Move_cam()
    {
        Vector3 cen = Centre();
        Vector3 newpos = cen + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref vel, time);
    }
    Vector3 Centre()
    {
        var bounding = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0;i<targets.Count;i++)
        {
            bounding.Encapsulate(targets[i].position);
        }

        return bounding.center;
    }
    float getdist()
    {
        var bound2 = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bound2.Encapsulate(targets[i].position);
        }

        return bound2.size.x;
    }
}
