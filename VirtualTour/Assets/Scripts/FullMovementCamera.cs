using UnityEngine;

public class FullMovementCamera : MonoBehaviour
{
    public Transform lookAt;   // spot (e.g., player head or crosshair)
    
    public float zoomSensitivity = 0.5f;

    public const float Y_ANGLE_MIN = -50.0f; // max look down
    public const float Y_ANGLE_MAX = 50.0f;  //max look up

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float invertedY;

    private Vector3 position;

    Vector3 offset;
    Vector3 zoomOffset;

    Vector3 closestZoomPermitted;
    Vector3 farthestZoomPermitted;

    private void Start()
    {   
        offset     = transform.position - lookAt.position;
        zoomOffset = offset; // initial zoom offset

        closestZoomPermitted  = offset * 0.25f;
        farthestZoomPermitted = offset * 4f;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X"); // rotate around player
        currentY += Input.GetAxis("Mouse Y"); // look up and down

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        invertedY = -currentY; // to achieve desired behavior
    }

    private void LateUpdate()
    {
        Vector3 direction = Vector3.zero;  // needed for Quaternion multiplication      
        Quaternion rotation = Quaternion.Euler(invertedY, currentX, 0);

        if (Input.GetKey(KeyCode.R))
        {
            // Input.mouseScrollDelta.y e.g., -2, -1, 0, 1, 2
            float delta = Input.mouseScrollDelta.y * zoomSensitivity;  

            if (delta != 0)
            {
                zoomOffset *= (1 + delta); // zoom
            }

            if (zoomOffset.magnitude < closestZoomPermitted.magnitude)
            {
                zoomOffset = closestZoomPermitted;
            }
            else if (zoomOffset.magnitude > farthestZoomPermitted.magnitude)
            {
                zoomOffset = farthestZoomPermitted;
            }

            direction.z = zoomOffset.z; // keep camera behind player at zoom offset
        }
        else 
        {
            zoomOffset  = offset; // restore
            direction.z = offset.z;
        }
        
        //Vector3 startPosition = transform.position;
        Vector3 endPosition   = lookAt.position + rotation * direction;
        
        transform.position = endPosition;
        //camTransform.position = Vector3.Lerp(startPosition,endPosition,20*Time.deltaTime);

        transform.LookAt(lookAt.position);
    }    
}
