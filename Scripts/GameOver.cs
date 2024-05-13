using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Global")]
    public Collision road;
    public PlayerBottomCollider playerBottomCollider;
    public GameObject canvaGameOver;
    public GameObject canvaWinner;
    // Update is called once per frame
    void Start(){
        canvaGameOver.SetActive(false);
        canvaWinner.SetActive(false);
    }
    void Update()
    {
        if (playerBottomCollider.isTriggerRoad == true || transform.position.y < -1f){
            IsOver();
            canvaGameOver.SetActive(true);
            Retry();
        }

        if (transform.position.z > 120f){
            canvaWinner.SetActive(true);
            IsOver();
            Retry();
        }
    }

    void IsOver (){
        if (Time.timeScale == 1){
            Time.timeScale = 0;
        }
    }

    void Retry(){
        if(Input.anyKeyDown){
            SceneManager.LoadScene("Level_One", LoadSceneMode.Single);
            Time.timeScale = 1;
        }
    }
}
