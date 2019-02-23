using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Text ammoText;
    [SerializeField]
    Text healthText;
    [SerializeField]
    Text armorText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text pickupText;
    [SerializeField]
    Text waveText;
    [SerializeField]
    Text enemyText;
    [SerializeField]
    Text waveClearText;
    [SerializeField]
    Text newWaveText;
    [SerializeField]
    Player player;
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Image Reticle;

    // Start is called before the first frame update
    void Start()
    {
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }
    public void SetArmorText(int armor)
    {
        armorText.text = "Armor : " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health : " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo : " + ammo;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "nextWave : " + time;
    }
    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies : " + enemies;
    }

    // Update is called once per frame
    public  void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                Reticle.sprite = redReticle;
                break;
            case Constants.ShotGun:
                Reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                Reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }
    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }
    public void setPickupText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }
    public void showNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
}
