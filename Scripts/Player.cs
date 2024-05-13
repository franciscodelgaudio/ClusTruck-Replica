using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 1f;
    public float forceJump = 50f, forceImpulse = 20f, velocity;
    private float jump, impulse; 
    public Rigidbody playerRigidbody;
    public PlayerBottomCollider playerBottomCollider;
    private TruckMove truckMove;

    [Header("Camera")]
    public GameObject player;
    public GameObject mainCamera;
    public float sensitivity = 1f;
    private float mouseX = 0f, mouseY = 0f;
    
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovementMouse();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Translate (Vector3.forward * Time.deltaTime * velocity);

        playerRigidbody.AddForce(transform.up * jump * Input.GetAxis("Jump"));
        playerRigidbody.AddForce(transform.forward * impulse * Input.GetAxis("Jump"));
    }

    void OnCollisionEnter (Collision other){
        velocity = 0;
    }

    void OnCollisionStay(Collision other)
    {
        if (playerBottomCollider.isTriggerTruck == true)
        {
            jump = forceJump;
            impulse = forceImpulse;
            transform.SetParent(other.transform);   
        }
    }

    void OnCollisionExit(Collision other){
        truckMove = other.gameObject.GetComponent<TruckMove>();
        velocity = truckMove.speedAux;
        jump = 0f;
        impulse = 0f;
        transform.SetParent(null);
    }

    void MovementMouse(){
        mouseX += Input.GetAxisRaw("Mouse X") * sensitivity;
        mouseY += Input.GetAxisRaw("Mouse Y") * sensitivity;
        
        //mouseX = Mathf.Clamp(mouseX, -90f, 90f);
        //mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        mainCamera.transform.localEulerAngles = new Vector3 (-mouseY, 0, 0);
        player.transform.localEulerAngles = new Vector3 (0, mouseX, 0);
    }
}
