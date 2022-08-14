using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class RotateArroundAxis : MonoBehaviour
{
    public GameObject target;
    public float radius = 5;
    [Range(0f, 1f)] public float offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.PI * 2f * offset;
        float _x = Mathf.Cos(angle) * radius;
        float _y = Mathf.Sin(angle) * radius;

        float x = target.transform.position.x + _x;
        float z = target.transform.position.z + _y;
        float y = transform.position.y;

        transform.position = new Vector3(x, y, z);
        // transform.RotateAround(target.transform.position, Vector3.up, speed);
        transform.LookAt(target.transform.position);
    }
}
