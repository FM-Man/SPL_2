using UnityEngine;

public class ItemPickUp : InteractableObject
{
    public Item item;

    public override void Interact() { 
        //base.Interact();
        PickUp();
        Debug.Log("Interact");
    }

    void PickUp() {
        Debug.Log("picking up item "+item.name);
        //adding to inventory
        Destroy(gameObject);
    }
}
