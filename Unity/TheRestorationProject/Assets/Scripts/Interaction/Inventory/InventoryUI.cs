using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject playerGameObject;
    public Transform itemsParent;
    Inventory playerInventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerGameObject.GetComponent<Inventory>();
        playerInventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI() 
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            slots[i].SetInventory(playerInventory);
            if (i < playerInventory.items.Count)
            {
                slots[i].AddItem(playerInventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
