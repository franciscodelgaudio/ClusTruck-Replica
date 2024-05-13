using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeResolution(int width, int height, bool fullscreen)
    {
        Screen.SetResolution(1920, 1080, fullscreen);
    }
}
