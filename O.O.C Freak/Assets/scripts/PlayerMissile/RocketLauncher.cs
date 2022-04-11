using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : Singleton<RocketLauncher>
{
    public int currentAmmo = 100;
    public int maxAmmo;
    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        currentAmmo = maxAmmo;
        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }
        


        
    }


    void Update()
    {
        currentAmmoToDisplay(currentAmmo);
        
    }
    void currentAmmoToDisplay(int ammoToDisplay)
    {
        if (ammoToDisplay < 0)
        {
            ammoToDisplay = 0;
        }
        

        ammoText.text = string.Format("Ammo:{0}", ammoToDisplay);

    }
}
