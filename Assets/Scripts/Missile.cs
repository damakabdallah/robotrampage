using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    Vector3 player;
    int nb=0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("deathTimer");
        player = GameObject.FindGameObjectWithTag("Player").transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != player && nb == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player,speed*Time.deltaTime);
        }
        else
        {
            nb++;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
