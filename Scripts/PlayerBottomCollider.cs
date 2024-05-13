using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBottomCollider : MonoBehaviour
{
    public bool isTriggerTruck = false;
    public bool isTriggerRoad = false;
    public Collider road;
    void OnTriggerStay (Collider other)
    {
        if (other == road){
            isTriggerRoad = true;
        }
        if (other.CompareTag("Truck")){
            isTriggerTruck = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isTriggerTruck = false;
        isTriggerRoad = false;
    }
}
