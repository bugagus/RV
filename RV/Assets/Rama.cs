using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Rama : MonoBehaviour
{

    public XRGrabInteractable G;

    [SerializeField] Mesh atenuado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CortarRama(){
        G.trackPosition = true;
        G.trackRotation = true;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Cuchillo" && gameObject.tag == "Rama"){
            CortarRama();
        }
    }
}
