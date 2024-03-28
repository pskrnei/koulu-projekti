/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthSize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;


    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthSize) / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthSize, yMax - camOrthSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, camY, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;

    }
}
Jätän vanhan koodin tähä, jos sattuu tarvimaa. GPT muokkaili tota toimivaa vähä ja teki siitä simppelimmän
*/

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;
    public float smoothSpeed = 0.1f;

    private Vector3 desiredPosition;
    private Camera mainCam;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (followTransform == null)
            return;

        // Calculate desired position based on followTransform's position
        Vector3 targetPosition = followTransform.position;
        targetPosition.z = transform.position.z; // Maintain the camera's original z position

        // Clamp desired position to map bounds
        Vector3 minBound = mapBounds.bounds.min;
        Vector3 maxBound = mapBounds.bounds.max;
        float camHalfHeight = mainCam.orthographicSize;
        float camHalfWidth = camHalfHeight * mainCam.aspect;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minBound.x + camHalfWidth, maxBound.x - camHalfWidth);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBound.y + camHalfHeight, maxBound.y - camHalfHeight);

        // Smoothly move towards desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    // Draw gizmos to visualize the camera bounds in the editor
    private void OnDrawGizmosSelected()
    {
        if (mapBounds != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(mapBounds.bounds.center, mapBounds.bounds.size);
        }
    }
}


