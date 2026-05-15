using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToExplode;
    [SerializeField] private float explosionTime;
    private bool hasExploded = false;
    [SerializeField] private Color color;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToExplode > 0) Move();
        else if (!hasExploded) Explode();
        else DoExplosion();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded) Explode();
    }

    private void Move()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
        timeToExplode -= Time.deltaTime;
    }

    private void Explode()
    {
        timeToExplode = 0;
        hasExploded = true;
        Destroy(this.gameObject, explosionTime);
    }

    private void DoExplosion()
    {
        Debug.Log($"Exploding, scale {this.transform.localScale}");
        this.transform.localScale += Vector3.one * Mathf.Pow(speed, 2) * Time.deltaTime;
    }

}
