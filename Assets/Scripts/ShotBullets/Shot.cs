using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private GameObject gun;

    [SerializeField] private float shotCooldown;
    private float timeToShot;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShot -= Time.deltaTime;

        if (ShotCondition())
        {
            DoShot();
            timeToShot = shotCooldown;
        }
    }


    protected virtual bool ShotCondition()
    {
        return timeToShot < 0;
    }

    protected virtual void DoShot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.forward = this.transform.forward;
        bullet.transform.position = gun.transform.position;
    }
}
