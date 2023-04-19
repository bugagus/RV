using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Rama : MonoBehaviour
{

    public XRGrabInteractable G;
    Color colorOriginal;
    Color colorAtenuado;
    [SerializeField] Mesh meshRama;
    
    void Start()
    {
        GetComponent<MeshFilter>().mesh = meshRama;
        colorOriginal =  GetComponent<MeshRenderer>().material.color;
    }

    public void SetAtenuado(){
        GetComponent<MeshRenderer>().material.color = colorAtenuado;
    }

    public void SetNormal(){
        GetComponent<MeshRenderer>().material.color = colorOriginal;
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
