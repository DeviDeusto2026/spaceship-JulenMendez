using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    protected GameObject player;

    [SerializeField] protected float speed;


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        this.transform.position += direction * speed * Time.deltaTime;
        this.transform.LookAt(player.transform);
    }


    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
