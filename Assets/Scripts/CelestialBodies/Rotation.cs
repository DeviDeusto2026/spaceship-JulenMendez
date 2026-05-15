using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Rotation : MonoBehaviour
{
    [Header("rotationSpeed")]
    [Tooltip("Speed at which the planet will rotate around its y axis")]
    public float rotationSpeed = 1f;

    [Header("axis")]
    [Tooltip("The tilt the planet will have at the start")]
    [Range(0f, 180f)]
    public float tilt = 0f;

    [Tooltip("Value of the y axis. A vector that will spin the object")]
    public Vector3 rotationPlanet = Vector3.up; //(0,1,0) We made this variable public so that we can change uranus rotation



    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The forward axis has a rotation applied by tilt and it is relative to the world, because otherwise it would take the sun's rotation 
        transform.Rotate(rotationPlanet, tilt, Space.World);  
    
    
    }

    // Update is called once per frame
    void Update()
    {
        float rotationToApply = rotationSpeed * Time.deltaTime; //rotationToApply is the magnitude
        transform.Rotate(rotationPlanet.normalized, rotationToApply, Space.World); //The vector is normalized because only the way and direction are of interest
    }
}
