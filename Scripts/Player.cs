using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1f;
    public float forceJump = 20f;
    private float jump;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement(){
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        rigidbody.AddForce(transform.up * jump * Input.GetAxis("Jump"));
    }

    void OnCollisionStay(Collision other){
        jump = forceJump;
    }
    void OnCollisionExit(Collision other){
        jump = 0f;
    }
}
