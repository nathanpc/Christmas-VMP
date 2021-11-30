using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
