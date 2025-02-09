using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
   
    public GameObject[] guns;
    private int index = 0;
    private Shooting GunStats;
    private int ammos;


    void Start()
    {
        SwitchGun(0);
        GunStats = guns[index].GetComponent<Shooting>();
    }


    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            SwitchGun((index + 1) % guns.Length);
            
        }
        else if (scroll < 0)
        {
            SwitchGun((index - 1 + guns.Length) % guns.Length);
        }
    }

    void SwitchGun(int newIndex)
    {
        guns[index].SetActive(false);
        index = newIndex;
        guns[index].SetActive(true);
    
        if(newIndex == 1)
        {
            StartCoroutine(GunStats.CoolDown(0.5f));
            StartCoroutine(GunStats.Reloader(3f));
          

        }
        else if(newIndex == 2)
        {
                StartCoroutine(GunStats.CoolDown(0.1f));
                StartCoroutine(GunStats.Reloader(1.5f));
              
        }

                
    }

}
