using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public int velocity = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.forward * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.back * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.position += Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.position += Vector3.down * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.rotation *= Quaternion.Euler(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.rotation *= Quaternion.Euler(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.rotation *= Quaternion.Euler(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.rotation *= Quaternion.Euler(0, 1, 0);
        }

    }
}
