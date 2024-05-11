using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{

    [Header("Global")]
    public float moveTimer = 0f;
    public float timerDirection = 2f;
    
    [Header("Translation")]
    public float speed = 1f;

    [Header("Rotation")]
    public float direction = 0f;
    public float turnSpeed = 50f;

    void Update()
    {
        ForwardMove();
        LimitDestroy();
    }

    void ForwardMove(){
        ChangeMovement();
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
        transform.Rotate (Vector3.up, Time.deltaTime * direction * turnSpeed);
    }

    void ChangeMovement(){
        LimitChangeMovement();

        speed = 1 + Random.Range(1f, 5f);

        moveTimer += Time.deltaTime;
        if (moveTimer >= timerDirection){
            direction = Random.Range(1f, -1f);
            moveTimer = 0;
        }
    }

    void LimitChangeMovement (){
        if (transform.rotation.y < -0.0436194){
            transform.rotation = Quaternion.Euler (0f, -5f, 0f);
        }
        if(transform.rotation.y > 0.0436194){
            transform.rotation = Quaternion.Euler (0f, 5f, 0f);
        }
    }

    void LimitDestroy (){
        if (transform.position.z > 130f || transform.position.y < -20f){
            Destroy(gameObject);
        }
    }
}
