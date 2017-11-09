using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;

    private void Update()
    {
        transform.position += Vector3.up * speed;

        if (transform.position.y > 30f)
        {
            Destroy(gameObject);
        }
    }
}
