using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    //Script to make the camera follow the player

    public GameObject target;
    public float damping = 1; //Modifier for rotation time
    public bool p2 = false;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position; //Gets the initial distance between player and camera, so it can be maintained when the camera moves
    }

    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y; //Gets the player's direction
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping); //Smoothly rotates to match player rotation

        if (p2)
        {
            angle += 180f; //Needed as player 2 starts facing the other way
        }

        Quaternion rotation = Quaternion.Euler(0, angle, 0); //Updates rotation
        transform.position = target.transform.position - (rotation * offset); //Updates position to follow behind player

        transform.LookAt(target.transform);
    }
}
