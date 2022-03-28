using UnityEngine;

public class ItemPickUp : InteractableObject
{
    public Item item;

    public override void Interact(Inventory inventory) { 
        //base.Interact();
        PickUp(inventory);
        Debug.Log("Interact");
    }

    void PickUp(Inventory inventory) {
        Debug.Log("picking up item "+item.name);
        //adding to inventory
        if (inventory.Add(item)) 
        {
            Destroy(gameObject);
        }
       
    }
}
