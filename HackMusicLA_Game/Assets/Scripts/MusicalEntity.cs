using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalEntity : MonoBehaviour 
{
	[SerializeField]
	protected MusicalItem m_item;

	private GameObject emanatingSource;

	// Returns the item;
	public MusicalItem GetItem() 
	{ 
		return m_item; 
	}
		
    protected virtual void Start()
    {
		m_item.icon = GetComponentInChildren<SpriteRenderer>().sprite;
		emanatingSource = m_item.PlayEmanatingSound (transform.position);
		emanatingSource.transform.parent = transform;
	}

	public void DestroyMusicalEntity()
	{
		Destroy (emanatingSource);
		Destroy (gameObject);
	}
}