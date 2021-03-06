using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Image icon;
    Item item;
    Button removeButton;
    Inventory playerInventory;
    GameObject player;

    public void Start()
    {
        icon = transform.Find("itemButton").transform.Find("Item").GetComponent<Image>();
        removeButton = transform.Find("removeButton").GetComponent<Button>();
    }

    public void SetInventory(Inventory inventory, GameObject playerGameObject) 
    { 
        playerInventory = inventory;
        player = playerGameObject;
    }

    public void AddItem(Item newItem) 
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        removeButton.onClick.AddListener(delegate { playerInventory.Remove(item); });
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

    public void OnItemButtn()
    {
        item.Use(player);
    }
}
