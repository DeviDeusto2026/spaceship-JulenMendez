using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int health;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
        }

        if (collider.gameObject.CompareTag("Bomb"))
        {
            health -= health;
        }


        if (health == 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }


}
