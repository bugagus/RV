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
    void Start(){
        choquesHierro = 3;
    }
    public void ChocarConRoca(){

    }

    public void ModeloAtenuado(){
       
    }

    public void ModeloNormal(){
        GetComponent<MeshFilter>().mesh = meshPiedra;
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
            GetComponent<MeshFilter>().mesh = mesh3;
            gameObject.tag = "Cuchillo";
        }
    }

    void OnCollisionEnter(Collision collision){
        if(construccion){
            if(collision.gameObject.tag == "Hierro" && gameObject.tag == "Cuchillo"){
                gameObject.tag = "Flecha";
                GetComponent<MeshFilter>().mesh = meshFlecha;
            }
            if(collision.gameObject.tag == "Rama" && gameObject.tag == "Cuchillo"){
                GameObject objetoColision = collision.gameObject;
                Destroy(objetoColision);
                gameObject.tag = "Hacha_Aux";
                GetComponent<MeshFilter>().mesh = meshHacha_Aux;
            }
        }else{
            if(collision.gameObject.tag == "Hierro" && gameObject.tag == "Roca"){
                ChocarConHierro();
            }
        }
    }


}
