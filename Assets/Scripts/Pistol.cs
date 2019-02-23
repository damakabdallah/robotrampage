using UnityEngine;

public class Pistol : Gun
{
    protected override void Update()
    {
        base.Update();
        //shotgun and pistol have semi-auto fire rate
        if(Input.GetMouseButtonDown(0)&& (Time.time - lastFireTime) > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
