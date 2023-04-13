using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    int choquesHierro;
    [SerializeField] Mesh mesh1,mesh2,mesh3;
    void Start(){
        choquesHierro = 3;
    }
    public void ChocarConRoca(){

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
        if(collision.gameObject.tag == "Hierro" && gameObject.tag == "Roca"){
            ChocarConHierro();
        }
    }


}
