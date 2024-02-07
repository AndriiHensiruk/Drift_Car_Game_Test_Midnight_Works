using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CarController : MonoBehaviour {

    public WheelAlignment[] steerableWheels;
    private PhotonView photonView;
    public float BreakPower;
     public Vector3 centerOfMass;
    public float Horizontal;
    public float Vertical;
    //Steering variables
    public float wheelRotateSpeed;
    public float wheelSteeringAngle;

    //Motor variables
    public float wheelAcceleration;
    public float wheelMaxSpeed;



    private Rigidbody playerRB;

     void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass;
        
    }

    // Update is called once per frame
    void Update ()
    {
        wheelControl();      
	}


    //Applies steering and motor torque
    void wheelControl()
    {
        for (int i = 0; i < steerableWheels.Length; i++)
        {
            //Sets default steering angle
            steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, 0, Time.deltaTime * wheelRotateSpeed);
            //Sets default motor speed
            steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, 0, Time.deltaTime * wheelAcceleration);



            //Motor controls

            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

            if (Vertical > 0.1)
            {
                steerableWheels[i].wheelCol.motorTorque = Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
                steerableWheels[i].WheelEffects(); 
            }

            if (Vertical < -0.1)
            {
                steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration * BreakPower);
                playerRB.drag = 0.3f;
                steerableWheels[i].WheelEffects();
            }
            else
            {
                playerRB.drag = 0;
            }


            if (Horizontal > 0.1)
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
                           
            }

            if (Horizontal < -0.1)
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, -wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
            }
        }
    }

}
