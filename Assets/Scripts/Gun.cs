using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float zoomFactor;
    public int range;
    public int damage;
    public float fireRate;
    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    float zoomFOV;
    float zoomSpeed = 6f;
    Camera cam;

    protected float lastFireTime;
    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = Time.time - 10;
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        lastFireTime = Time.time - 10;
        cam = GameObject.FindObjectOfType<Camera>();
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = Constants.CameraDefaultZoom;
        }
    }
    protected void Fire()
    {
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag,0);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }
        GetComponentInChildren<Animator>().Play("Fire");
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, range))
        {
            processHit(hit.collider.gameObject);
        }
    }

    void processHit(GameObject hitObject)
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().takeDamage(damage);
        }
    }
}
