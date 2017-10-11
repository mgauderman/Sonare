using UnityEngine;


public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject craftingUI;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(!inventoryUI.activeSelf);
        craftingUI.SetActive(!craftingUI.activeSelf);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButtonDown("Inventory") )
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.C) ) {
            craftingUI.SetActive(!craftingUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        for( int i = 0; i < slots.Length; i++ )
        {
            if( i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
