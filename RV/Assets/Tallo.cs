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
    // Start is called before the first frame update
    void Start()
    {
        construccion = false;
    }

    public void ModeloAtenuado(){
    }

    public void ModeloNormal(){
        GetComponent<MeshFilter>().mesh = meshTallo;
    }
    public void JuntarTallos(){
        gameObject.tag = "Cuerda";
        GetComponent<MeshFilter>().mesh = meshCuerda;
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
                GameObject objetoColision = collision.gameObject;
                Destroy(objetoColision);
                JuntarTallos();
            }
            if(collision.gameObject.tag == "Hacha_Aux" && gameObject.tag == "Cuerda"){
                GameObject objetoColision = collision.gameObject;
                Destroy(objetoColision);
                gameObject.tag = "Hacha";
                GetComponent<MeshFilter>().mesh = meshHacha;
            }
        }else{
            if(collision.gameObject.tag == "Cuchillo" && gameObject.tag == "Tallo"){
                CortarTallo();
            }
        }
    }
}
