using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Slot : MonoBehaviour, IDropHandler {

    public GameObject item
    {
        get
        {
            if( transform.childCount > 0 )
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

	public void OnDrop(PointerEventData eventData)
    {
        //if( !item )
       // {
        GetComponent<InventorySlot>().AddItem(DragHandler.itemBeingDragged);
        DragHandler.inventorySlotBeingDragged.ClearSlot();
        Inventory.instance.Remove(DragHandler.itemBeingDragged);
        
       // }
    }
}
