using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingParent : MonoBehaviour 
{
	#region Singleton
	// pls work	
	public static CraftingParent instance;

	void Awake()
	{
		if( instance != null )
		{
			Debug.LogWarning("More than one instance of Inventory found!");
		}
		instance = this;
	}
	#endregion

	[SerializeField]
	MusicalItem cMajorSword;

    public Sprite noNote;
    public Sprite oneNote;
    public Sprite twoNotes;
    public Sprite threeNotes;

    InventorySlot[] slots;
	MusicalItem currentItem;

	// Use this for initialization
	void Start () 
	{
        slots = GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if( slots[0].item != null && slots[1].item != null && slots[2].item != null )
        {
            if (slots[2].item.GetNote() == Note.C && slots[1].item.GetNote() == Note.E && slots[0].item.GetNote() == Note.G)
            {
                //MusicalItem newItem = ScriptableObject.CreateInstance<MusicalItem>();
                //newItem.icon = cMajorSwordSprite;
               
				currentItem = cMajorSword;

				slots[3].AddItem(currentItem);
            }
        }

        if( slots[2].item != null )
        {
            if( slots[1].item != null )
            {
                if( slots[0].item != null )
                {
                    if (slots[4].item == null )
                    {
                        MusicalItem item1 = ScriptableObject.CreateInstance<MusicalItem>();
                        item1.icon = threeNotes;
                        slots[4].AddItem(item1);
                    }
                    else
                    {
                        MusicalItem item1 = ScriptableObject.CreateInstance<MusicalItem>();
                        item1.icon = threeNotes;
                        slots[4].ClearSlot();
                        slots[4].AddItem(item1);
                        
                    }
                    
                    //slots[4].item.icon = threeNotes;
                }
                else
                {
                    if (slots[4].item == null)
                    {
                        MusicalItem item2 = ScriptableObject.CreateInstance<MusicalItem>();
                        item2.icon = twoNotes;
                        slots[4].AddItem(item2);
                    }
                    else
                    {
                        MusicalItem item2 = ScriptableObject.CreateInstance<MusicalItem>();
                        item2.icon = twoNotes;
                        slots[4].ClearSlot();
                        slots[4].AddItem(item2);
                    }
                  
                    //slots[4].item.icon = twoNotes;
                }
            }
            else
            {
                if (slots[4].item == null)
                {
                    MusicalItem item3 = ScriptableObject.CreateInstance<MusicalItem>();
                    item3.icon = oneNote;
                   
                    slots[4].AddItem(item3);
                }
                else
                {
                    MusicalItem item3 = ScriptableObject.CreateInstance<MusicalItem>();
                    item3.icon = oneNote;
                    slots[4].ClearSlot();
                    slots[4].AddItem(item3);
                }
             
                //slots[4].item.icon = oneNote;
            }
        }
        else
        {
            if (slots[4].item == null)
            {
                MusicalItem item4 = ScriptableObject.CreateInstance<MusicalItem>();
                item4.icon = noNote;
                slots[4].AddItem(item4);
            }
            else
            {
                MusicalItem item4 = ScriptableObject.CreateInstance<MusicalItem>();
                item4.icon = noNote;
                slots[4].ClearSlot();
                slots[4].AddItem(item4);
            }
            
            //slots[4].item.icon = noNote;
        }
		
	}

	public MusicalItem GetCurrentItem() { return currentItem; }
}
