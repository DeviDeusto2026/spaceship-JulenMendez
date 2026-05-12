using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.rotation *=  Quaternion.Euler(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.rotation *= Quaternion.Euler(Vector3.left * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.rotation *= Quaternion.Euler(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.rotation *= Quaternion.Euler(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }
}
