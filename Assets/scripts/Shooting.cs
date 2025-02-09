using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    //public float cooldown = 0.2f;
    // public float reload = 2f;
    public TextMeshProUGUI ammosLeft;
    public Transform muzzle;
    public GameObject bulletPref;

    public int magazineCapacity = 20;
    public int magazine;
    private bool canFire = true;
    void Start()
    {
        magazine = magazineCapacity;
        ammosLeft.text = magazine.ToString("D2");
    }

    
    void Update()
    {
        if (magazine> 0 && canFire && Input.GetMouseButtonDown(0)) {
            magazine--;
            ammosLeft.text = magazine.ToString("D2");
            Instantiate(bulletPref, muzzle.position,transform.rotation);
            StartCoroutine(CoolDown(0.2f));
            
        }
        else if( magazine == 0 && canFire && Input.GetMouseButtonDown(0))
        {
            ammosLeft.text = magazine.ToString("D2");
            StartCoroutine(Reloader(2f));
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammosLeft.text = magazine.ToString("D2");
            StartCoroutine(Reloader(2f));
        }
    }
   public IEnumerator CoolDown(float cooldown)
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
    
   public IEnumerator Reloader(float reload)
    {
        canFire = false;
    
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        magazine = magazineCapacity;
        ammosLeft.text = magazine.ToString("D2");

        canFire = true;
    }

}
