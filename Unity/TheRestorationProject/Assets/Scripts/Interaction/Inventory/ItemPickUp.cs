using UnityEngine;

public class ItemPickUp : InteractableObject
{
    public Item item;

    public override void Interact(Inventory inventory) 
    { 
        //base.Interact();
        PickUp(inventory);
    }

    void PickUp(Inventory inventory) 
    {
        //adding to inventory
        if (inventory.Add(item)) 
        {
            Destroy(gameObject);
        }
       
    }
}
