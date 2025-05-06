using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private Vector3 offset; //초기거리
    public Tilemap tilemap;

    void Start()
    {
        offset = transform.position - target.position;

        Bounds localBounds = tilemap.localBounds;
        minBounds = new Vector2(localBounds.min.x+9, localBounds.min.y+5);
        maxBounds = new Vector2(localBounds.max.x-9, localBounds.max.y+5);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime *smoothSpeed);
    }
}
