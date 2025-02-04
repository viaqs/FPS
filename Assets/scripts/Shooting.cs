using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public float cooldown = 0.2f;
    public float reload = 2f;
    public Transform muzzle;
    public GameObject bulletPref;

    public int magazineCapacity = 20;
    public int magazine;
    private bool canFire = true;
    void Start()
    {
        magazine = magazineCapacity;
    }

    
    void Update()
    {
        if (magazine> 0 && canFire && Input.GetMouseButtonDown(0)) {
            magazine--;
            Instantiate(bulletPref, muzzle.position,transform.rotation);
            StartCoroutine(CoolDown());
            
        }
        else if( magazine == 0 && canFire && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Reloader());
        }
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reloader());
        }
    }
    IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
    
    IEnumerator Reloader()
    {
        canFire = false;
    
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        magazine = magazineCapacity;
        canFire = true;
    }

}
