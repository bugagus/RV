using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchHands : MonoBehaviour
{

    XRGrabInteractable grabInteractable;

    [SerializeField] Transform left;
    [SerializeField] Transform right;

    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    //[System.Obsolete]
    public void SwapHands()
    {
        if (grabInteractable.selectingInteractor.name == leftHand.name)
        {
            grabInteractable.attachTransform = left;
        }
        if (grabInteractable.selectingInteractor.name == rightHand.name)
        {
            grabInteractable.attachTransform = right;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Mano Derecha"))
		{
            grabInteractable.attachTransform = right;
        }
        if (other.CompareTag("Mano Izquierda"))
		{
            grabInteractable.attachTransform = left;
        }
    }
}
