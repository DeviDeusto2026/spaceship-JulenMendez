using System.Collections;
using UnityEngine;

public class BossMovement : EnemyMovement
{

    [SerializeField] private float zigZagSpeed;


    private void Start()
    {
        StartCoroutine(ChangeZigZagDirection());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = (player.transform.position - this.transform.position).normalized;
        this.transform.position += playerDirection * speed * Time.deltaTime;

        Vector3 zigZagDirection =  Quaternion.AngleAxis(90, Vector3.up) * playerDirection;
        this.transform.position += zigZagDirection * zigZagSpeed * Time.deltaTime;

        this.transform.LookAt(player.transform);
    }


    private IEnumerator ChangeZigZagDirection()
    {
        while (true)
        {
            zigZagSpeed *= -1;
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
