using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortarCerdo : MonoBehaviour
{
    [SerializeField] GameObject brillos;
    [SerializeField] GameObject cerdo;
	// Start is called before the first frame update
	bool cortar;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("CerdoBrillo"))
		{
			cortar = true;
		}	
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("CerdoBrillo"))
		{
			cortar = false;
		}
	}

	public void Cortar()
	{
		if (cortar == true)
		{
			Destroy(brillos);
			Destroy(cerdo);
		}
	}
}
