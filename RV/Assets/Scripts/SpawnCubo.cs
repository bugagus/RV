using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubo : MonoBehaviour
{

	[SerializeField] GameObject prefabObject;
	private void Start()
	{
		prefabObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Cuchillo"))
		{
			prefabObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Cuchillo"))
		{
			prefabObject.SetActive(false);
		}
	}

}
