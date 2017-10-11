using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

#region Singleton

    public static Inventory instance;

    public int space = 20;

    public MusicalItem currentSelected = null;

    void Awake()
    {
        if( instance != null )
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<MusicalItem> items = new List<MusicalItem>();

    public bool Add(MusicalItem item) // returns whether successfully added item
    {
        if( items.Count >= space )
        {
            Debug.Log("Not Enough Room");
            return false;
        }

        items.Add(item);
        if( onItemChangedCallback != null )
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(MusicalItem item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
