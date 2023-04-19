using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;


public class ActionManager : MonoBehaviour
{
    public static ActionManager current;
    private InputAction myActionMenu;
    private InputAction myActionCrafteo;
    public event Action iniciarCrafteo;
    public event Action terminarCrafteo;
    bool crafteo;
    [Space][SerializeField] private InputActionAsset myActionsAsset;

    void Start()
    {
        crafteo = false;
        current = this;
        myActionMenu = myActionsAsset.FindAction("XRI LeftHand/Sacar Menu");
        myActionCrafteo = myActionsAsset.FindAction("XRI LeftHand/Sacar Menu");
    }

    void Update()
    {
        if (myActionMenu.WasPerformedThisFrame())
        {
            SacarMenu();
        }
        if (myActionCrafteo.WasPerformedThisFrame() && !crafteo)
        {
            crafteo = true;
            IniciarCrafteo();
        }
        else if (myActionCrafteo.WasPerformedThisFrame() && crafteo){
            crafteo = false;
            TerminarCrafteo();
        }

    }

    private void SacarMenu(){

    }

    private void IniciarCrafteo(){
        if(iniciarCrafteo!=null){
            iniciarCrafteo();
        }
    }
    private void TerminarCrafteo(){
        if(terminarCrafteo!=null){
            terminarCrafteo();
        }
    } 
}
