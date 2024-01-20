using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{   
    private bool hasUSB = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hasUSB);
    }

    public void setHasUSB(bool hasUSB)
    {
        this.hasUSB = hasUSB;
    }
    
    public bool getHasUSB()
    {
        return hasUSB;
    }
}
