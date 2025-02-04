using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3;
    public Vector2 damageRange = new Vector2(10, 20);
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;


    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
