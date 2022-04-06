using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Image icon;
    Item item;
    Button removeButton;
    Inventory playerInventory;

    public void Start()
    {
        icon = transform.Find("itemButton").transform.Find("Item").GetComponent<Image>();
        removeButton = transform.Find("removeButton").GetComponent<Button>();
    }

    public void SetInventory(Inventory inventory) 
    { 
        playerInventory = inventory;
    }

    public void AddItem(Item newItem) 
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot() 
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() { 
        playerInventory.Remove(item);
    }
}
