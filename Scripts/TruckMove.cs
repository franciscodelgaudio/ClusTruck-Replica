using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{

    [Header("Global")]
    public float timerDirection = 1f;
    private float moveTimer = 1f;
    
    [Header("Translation")]
    public float speed = 10f;
    private float speedAux;

    [Header("Rotation")]
    public float direction = 0f;
    public float turnSpeed = 50f;

    void Update()
    {
        ForwardMove();
        LimitDestroy();
    }

    void ForwardMove()
    {
        ChangeMovement();
        transform.Translate (Vector3.forward * Time.deltaTime * speedAux);
        transform.Rotate (Vector3.up, Time.deltaTime * direction * turnSpeed);
    }

    void ChangeMovement()
    {
        LimitChangeMovement();
        if (moveTimer >= timerDirection){
            direction = Random.Range(0.1f, -0.1f);
            speedAux = speed + Random.Range(5f, 10f);
            moveTimer = 0;
        }
        moveTimer += Time.deltaTime;

    }

    void LimitChangeMovement ()
    {
        if (transform.rotation.y < -0.0436194){
            transform.rotation = Quaternion.Euler (0f, -5f, 0f);
        }
        if(transform.rotation.y > 0.0436194){
            transform.rotation = Quaternion.Euler (0f, 5f, 0f);
        }
    }

    void LimitDestroy ()
    {
        if (transform.position.z > 210f || transform.position.y < -20f){
            Destroy(gameObject);
        }
    }
}
