using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    public static string activeWeaponType;
    public GameObject Pistol;
    public GameObject AssaultRifle;
    public GameObject Shotgun;

    GameObject activeGun;

    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = Pistol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(Pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else
            if (Input.GetKeyDown("2"))
            {
                loadWeapon(AssaultRifle);
                activeWeaponType = Constants.AssaultRifle;
                gameUI.UpdateReticle();
            }
            else
                 if (Input.GetKeyDown("3"))
                 {
                    loadWeapon(Shotgun);
                    activeWeaponType = Constants.ShotGun;
                    gameUI.UpdateReticle();
                 }
        
    }

    void loadWeapon(GameObject weapon)
    {
        Pistol.SetActive(false);
        AssaultRifle.SetActive(false);
        Shotgun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
