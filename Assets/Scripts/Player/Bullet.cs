using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        BulletHit();
        Destroy(this.gameObject);
    }

    private void BulletHit()
    {

    }
}
