using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] pickups;
    void spawnPickup()
    {
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }
    private void Start()
    {
        spawnPickup();
    }
    public  void pickupWasPickedup()
    {
        StartCoroutine("respawnPickup");
    }

}
