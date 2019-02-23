using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    public Game game;
    public AudioClip playerDead;

    GunEquipper gunEquipper;
    Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        //if there is a still armor, don't need to process health damage
        int healthDamage = amount;
        if (armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;
            if(effectiveArmor>0)
            {
                armor = effectiveArmor / 2;
                gameUI.SetArmorText(armor);
                return;
            }
            armor = 0;
            gameUI.SetArmorText(armor);
        }
        health -= healthDamage;
        gameUI.SetHealthText(health);
        if (health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.gameOver();
        }
    }

    void pickUpHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
        gameUI.setPickupText("health picked up +50 health");
        gameUI.SetHealthText(health);
    }
    void pickUpArmor()
    {
        armor += 15;
        gameUI.setPickupText("Armor picked up +15 armor");
        gameUI.SetArmorText(armor);
    }

    void pickAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.setPickupText("Assault rifle ammo picked up +50 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }
    void pickUpPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.setPickupText("Pistol ammo picked up +20 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }
    void pickUpShotgunAmmo()
    {
        ammo.AddAmmo(Constants.ShotGun, 10);
        gameUI.setPickupText("shotgun ammo picked up +10 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.ShotGun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.ShotGun));
        }
    }
    public void pickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.pickUpArmor:
                pickUpArmor();
                break;
            case Constants.PickUpHealth:
                pickUpHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickAssaultRifleAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickUpShotgunAmmo();
                break;
            default:
                Debug.LogError("bad pickup type passed " + pickupType);
                break;
                

        }
    }
}
