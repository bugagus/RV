using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rama : MonoBehaviour
{
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
