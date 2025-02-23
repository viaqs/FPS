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

    private void OnCollisionEnter(Collision other)
    {
        //print($"Hit {other.gameObject.name} for {Random.Range(damageRange.x, damageRange.y)}");
        var damage = Random.Range(damageRange.x, damageRange.y);
        dmgIndicator.instance.DisplayDamage((int)damage, transform.position);
        Destroy(gameObject);
        var zombie = other.gameObject.GetComponent<ZOmbie>();
        if (zombie !=null) zombie.GetHurt();
    }
}
