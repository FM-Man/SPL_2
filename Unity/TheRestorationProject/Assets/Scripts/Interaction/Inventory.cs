using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int space = 10;

    //to invoke an event when the inventory has changed
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    
    public bool Add(Item item) 
    {
        if (!item.isDefaultItem) 
        {
            if (items.Count < space)
            {
                items.Add(item);
                if(onItemChangedCallBack != null) 
                    onItemChangedCallBack.Invoke();
                return true;
            }
        }
        return false;
        
    }

    public void Remove(Item item) { 
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
