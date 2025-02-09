using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DmgText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float lifetime = 1;
    public Vector2 speedRange = new Vector2(1, 3);

    private float speed;
    void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        transform.position += speed * Time.deltaTime * Vector3.up;
    }

    public void ChangeText(int damage)
    {
        text.text = damage.ToString();
    }
}
