using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
   
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;
   
    void FixedUpdate()
    {
        if (!player)
         {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerRB = player.GetComponent<Rigidbody>();
            }
        
        Vector3 playerForward = (playerRB.velocity + player.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position,
            player.position + player.transform.TransformVector(Offset)
            + playerForward * (-5f),
            speed * Time.deltaTime);
        transform.LookAt(player);
    }
}
