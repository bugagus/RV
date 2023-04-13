using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Tallo : MonoBehaviour
{
    public XRGrabInteractable G;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CortarTallo(){
        G.trackPosition = true;
        G.trackRotation = true;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Cuchillo" && gameObject.tag == "Tallo"){
            CortarTallo();
        }
    }
}
