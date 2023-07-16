using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    float maxTiltAngle = 80f;
    public GameObject muzzle;
    
    //[SerializeField]
    //[Range(0, 100)]
    int shootingBaseSpeed = 400;
    Vector3 direction;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // Set the z position to the desired distance from the camera

        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        cursorWorldPos.z = transform.position.z; // Set the z position of the cursor to match the cannon's z position

        direction = cursorWorldPos - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //angle = Mathf.Clamp(angle, -maxTiltAngle, maxTiltAngle);
        if ((angle > -90 - maxTiltAngle) && (angle < -90 + maxTiltAngle))
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Vector3 getShootingVector()
    {
        return direction.normalized * shootingBaseSpeed;
    }
}
