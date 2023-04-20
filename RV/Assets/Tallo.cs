using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Tallo : MonoBehaviour
{
    public XRGrabInteractable G;
    private bool construccion;
    [SerializeField] Mesh meshTallo;
    [SerializeField] Mesh meshCuerda;
    [SerializeField] Mesh meshHacha;
    Color colorOriginal;
    Color colorAtenuado;
    GameObject objetoColision;
    
    void Start()
    {
        ActionManager.current.iniciarCrafteo += EntrarModoCrafteo;
        ActionManager.current.terminarCrafteo += SalirModoCrafteo;
        colorOriginal =  GetComponent<MeshRenderer>().material.color;
        //GetComponent<MeshFilter>().mesh = meshTallo;
        construccion = false;
    }

    public void SetAtenuado(){
        GetComponent<MeshRenderer>().material.color = colorAtenuado;
    }

    public void SetNormal(){
        GetComponent<MeshRenderer>().material.color = colorOriginal;
    }
    public void CrearCuerda(GameObject objetoColision){
        gameObject.tag = "Cuerda";
        GetComponent<MeshFilter>().mesh = meshCuerda;
        Destroy(objetoColision);
    }

    public void CrearHacha(GameObject objetoColision){
        Destroy(objetoColision);
        gameObject.tag = "Hacha";
        GetComponent<MeshFilter>().mesh = meshHacha;
    }

    public void EntrarModoCrafteo(){
        construccion = true;
    }

    public void SalirModoCrafteo(){
        construccion = false;
    }

    public void CortarTallo(){
        G.trackPosition = true;
        G.trackRotation = true;
        
    }

    void OnCollisionEnter(Collision collision){
        if(construccion){
            if(collision.gameObject.tag == "Tallo" && gameObject.tag == "Tallo"){
                objetoColision = collision.gameObject;
                CrearCuerda(objetoColision);
            }
            if(collision.gameObject.tag == "Hacha_Aux" && gameObject.tag == "Cuerda"){
                objetoColision = collision.gameObject;
                CrearHacha(objetoColision);
            }
        }else{
            if(collision.gameObject.tag == "Cuchillo" && gameObject.tag == "Tallo"){
                CortarTallo();
            }
        }
    }
}
