using UnityEngine;

public class PlayerShot : MonoBehaviour
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

        if (timeToShot < 0 && Input.GetKey(KeyCode.Mouse0))
        {
            Shot();
            timeToShot = shotCooldown;
        }
    }


    private void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.forward = this.transform.forward;
        bullet.transform.position = gun.transform.position;
    }
}
