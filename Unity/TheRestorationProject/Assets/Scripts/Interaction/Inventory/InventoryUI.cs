using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject inventoryUI;
    GameObject itemsParent;
    Inventory playerInventory;
    StarterAssetsInputs inputSystem;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerGameObject.GetComponent<Inventory>();
        playerInventory.onItemChangedCallBack += UpdateUI;
        itemsParent = transform.Find("Inventory").transform.Find("itemsParent").gameObject;
        inputSystem = playerGameObject.GetComponent<StarterAssetsInputs>();
        slots = itemsParent.transform.GetComponentsInChildren<InventorySlot>();
        
    }

    void Update() {
        if (inputSystem.inventoryUI) 
        {
            if (inventoryUI.activeSelf) 
            {
                inventoryUI.SetActive(false);
                inputSystem.shootable = true;
            }
            else
            {
                inventoryUI.SetActive(true);
                inputSystem.shootable = false;
            }
            inputSystem.inventoryUI = false;
        }
        
    }

    void UpdateUI() 
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            //Debug.Log(i);
            slots[i].SetInventory(playerInventory);
            if (i<playerInventory.items.Count/*playerInventory.items[i]!=null*/)
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
