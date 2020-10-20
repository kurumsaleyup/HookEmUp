using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectHooked : MonoBehaviour
{
    private hookScript hookScriptlol;
    void OnCollisionEnter(Collision collisionInfo) //information about collision
    {
        
        if (collisionInfo.collider.tag == "Player")
        {
            hookScriptlol = FindObjectOfType<hookScript>();
            hookScriptlol.throwHook = false;
        }
        Debug.Log("Something");
    }
}
