using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public Transform eyePointA;
    public Transform eyePointB;
    public float speed = 1f;


    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(eyePointA.position, eyePointB.position, t);
    }
}
