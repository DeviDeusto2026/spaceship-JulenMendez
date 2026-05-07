using System.Runtime.CompilerServices;
using UnityEngine;

public class Orbiting : MonoBehaviour
{

    [Header("Central body")]
    [Tooltip("The game object this is going to orbit around")]
    public Transform centralBody;


    [Header("Elipse shape")]
    [Tooltip("Semi-major axis. Max distance from the central body. (X direction)")]
    public float semiMajorAxis = 2f;

    [Tooltip("Semi-minor axis. Min distance from the central body. (Z direction)")]
    public float semiMinorAxis = 1f; //If this is equal to the major one, it will be a circular shape instead

    [Header("Orbit speed")]
    [Tooltip("Degrees per second around the orbit")]
    public float orbitSpeed = 1f;


    [Header("Orbit tilt")]
    [Tooltip("Tilt of the orbit in degrees")]
    [Range(0f,180f)]
    public float orbitalTilt = 0f;

    [Tooltip("The point of less distance between two celestial bodies")]
    [Range(0f, 360f)]
    public float periapsisAngle = 0f;

    [Header("Debug")]
    [Tooltip("Drawing of the orbit in the scene view")]
    public bool showOrbitGizmo = true;
    public Color gizmoColor = Color.white;


    private float _currentAngle = 0f;
    private Quaternion _orbitRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _orbitRotation = Quaternion.Euler(orbitalTilt,periapsisAngle,0f); //This sets the tilt and the periapsis angle.

        if (centralBody == null) {
            Debug.LogWarning($"{name}: central body is missing", this); //Warning message in case there's no celestial body assigned to orbit around
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If there's no celestial body assigned, the program won't do anything below the if
        if (centralBody == null) {
            return;
        }


        SetTheAngle();
        CalculateNewPosition(_currentAngle);

        transform.position = CalculateNewPosition(_currentAngle);
    }

    /// <summary>
    /// This function sets the angle. It is doing it based on the orbit speed
    /// </summary>
    private void SetTheAngle() {
        _currentAngle += orbitSpeed * Time.deltaTime;
    }

    /// <summary>
    /// This function calculates the new position. It will respect the tilt and the periapsis angle of the orbitRotation.
    /// Parameter: the angle of the current position in the elipse
    /// /// </summary>
    private Vector3 CalculateNewPosition(float angle) { 
        float rad = Mathf.Deg2Rad * angle; //Transformation to degrees to rads

        //This is the position where the planet will end up. For that, the angle will be decomposed as if it was 2D
        Vector3 point = new Vector3 (
            semiMajorAxis * Mathf.Cos(rad), 
            0f, 
            semiMinorAxis * Mathf.Sin(rad)
        );

        return centralBody.position + _orbitRotation * point;
    }


    //-----------------------------------------------------------------------------------------
#if UNITY_EDITOR
    void OnDrawGizmosSelected() {
        if (!showOrbitGizmo) {
            return;
        }
        DrawOrbitGizmo();
    }

    private void DrawOrbitGizmo() { 
        Gizmos.color = gizmoColor;
        int segment = 64;
        Vector3 prev = Vector3.zero;
        for (int i=0; i<=segment; i++) {
            float angle = i * 360f / segment;
            Vector3 point = CalculateNewPosition(angle);
            if (i>0) {
                Gizmos.DrawLine(prev, point);
            }
            prev = point;
        }

        //Mark the periapsis
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(CalculateNewPosition(0f), 0.5f);
        
    }


    private void OnValidate()
    {
        _orbitRotation = Quaternion.Euler(orbitalTilt, periapsisAngle, 0f);
    }

#endif
}
