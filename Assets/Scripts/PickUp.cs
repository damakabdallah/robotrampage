﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>()!=null && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().pickUpItem(type);
            GetComponentInParent<PickupSpawn>().pickupWasPickedup();
            Destroy(gameObject);
        }
    }
}
