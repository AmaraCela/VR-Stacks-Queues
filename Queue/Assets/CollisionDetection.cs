using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //public queueOperations movement;
    public GameObject cube;
    void OnCollisionEnter(Collision collisionInfo)
    {
       
        if (collisionInfo.collider.tag == "Obstacle")
        {
            cube.GetComponent<Rigidbody>().freezeRotation = true;
            //movement.enabled = false;

        }
    }
}
