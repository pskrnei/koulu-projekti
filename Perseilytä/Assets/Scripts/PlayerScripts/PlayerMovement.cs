using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 25f;
    public float rotSpeed = 1000f;
    //Vector3 previousMousePosition;

    // Start is called before the first frame update
    void Start()
    {
       // previousMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if(Input.mousePosition != previousMousePosition) { 

        // Rotate the ship based on mouse input
        Vector3 mousePosition = Input.mousePosition;
        Vector3 shipPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePosition - shipPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

  //          previousMousePosition = Input.mousePosition;
//}


        // Move the ship
        Vector2 pos = transform.position;

        // Adjust vertical movement based on input
        Vector2 upDown = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime);

        // Adjust horizontal movement based on input
        Vector2 leftRight = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0);

        // Apply rotation to vertical movement
        //upDown = transform.rotation * upDown;

        // Apply rotation to horizontal movement
        //leftRight = transform.rotation * leftRight;

        // Apply both vertical and horizontal movement
        pos += upDown + leftRight;

        transform.position = pos;
    }

}