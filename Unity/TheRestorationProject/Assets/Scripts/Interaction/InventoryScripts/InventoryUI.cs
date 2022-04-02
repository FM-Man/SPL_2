using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject playerGameObject;
    Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerGameObject.GetComponent<Inventory>();
        playerInventory.onItemChangedCallBack += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() 
    {
        Debug.Log("Updating UI");
    }
}
