using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    int choquesHierro;
    private bool construccion;
    [SerializeField] Mesh mesh1,mesh2,mesh3;

    [SerializeField] Mesh meshPiedra;
    [SerializeField] Mesh meshHacha_Aux;
    [SerializeField] Mesh meshFlecha;
    Color colorOriginal;
    Color colorAtenuado;
    void Start(){
        ActionManager.current.iniciarCrafteo += EntrarModoCrafteo;
        ActionManager.current.terminarCrafteo += SalirModoCrafteo;
        choquesHierro = 3;
        colorOriginal =  GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshFilter>().mesh = meshPiedra;
    }

    public void SetAtenuado(){
        GetComponent<MeshRenderer>().material.color = colorAtenuado;
    }

    public void SetNormal(){
        GetComponent<MeshRenderer>().material.color = colorOriginal;
    }

    public void CrearFlecha(){
        gameObject.tag = "Flecha";
        GetComponent<MeshFilter>().mesh = meshFlecha;
    }

    public void CrearHacha_Aux(GameObject objetoColision){
        gameObject.tag = "Hacha_Aux";
        GetComponent<MeshFilter>().mesh = meshHacha_Aux;
        Destroy(objetoColision);
    }

    public void CrearCuchillo(){
        GetComponent<MeshFilter>().mesh = mesh3;
        gameObject.tag = "Cuchillo";
    }

    public void EntrarModoCrafteo(){
        construccion = true;
    }

    public void SalirModoCrafteo(){
        construccion = false;
    }

    public void ChocarConHierro(){
        choquesHierro--;
        if(choquesHierro==2){
            GetComponent<MeshFilter>().mesh = mesh1;
        }
        else if(choquesHierro==1){
            GetComponent<MeshFilter>().mesh = mesh2;
        }
        else if(choquesHierro==0){
            CrearCuchillo();
        }
    }

    void OnCollisionEnter(Collision collision){
        if(construccion){
            if(collision.gameObject.tag == "Hierro" && gameObject.tag == "Cuchillo"){
                CrearFlecha();
            }
            if(collision.gameObject.tag == "Rama" && gameObject.tag == "Cuchillo"){
                GameObject objetoColision = collision.gameObject;
                CrearHacha_Aux(objetoColision);
            }
        }else{
            if(collision.gameObject.tag == "Hierro" && gameObject.tag == "Roca"){
                ChocarConHierro();
            }
        }
    }


}
