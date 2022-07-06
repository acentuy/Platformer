using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Saw : Enemy
{
    private float speed = 0.04f;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
    }
}
