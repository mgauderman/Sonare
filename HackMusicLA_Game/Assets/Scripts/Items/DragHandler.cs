using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

    public static MusicalItem itemBeingDragged;
    public static InventorySlot inventorySlotBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    Transform itemBeingDraggedTransform;

	public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = GetComponentInParent<InventorySlot>().item;
        inventorySlotBeingDragged = GetComponentInParent<InventorySlot>();
        startPosition = transform.position;
        startParent = transform.parent;
        //itemBeingDraggedTransform = transform.Find("Icon");
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        inventorySlotBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if ( transform.parent != startParent )
        {
            transform.position = transform.parent.position;
            Debug.Log("Parent stuff");
        }
        else
        {
            transform.position = startPosition;
        }
        //transform.position = startPosition;
    }
}
