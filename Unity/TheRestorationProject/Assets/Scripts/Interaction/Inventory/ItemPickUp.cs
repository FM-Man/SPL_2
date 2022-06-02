using UnityEngine;

public class ItemPickUp : InteractableObject
{
    public Item item;

    public override void Interact(GameObject player) 
    { 
        //base.Interact();
        PickUp(player.GetComponent<Inventory>());
        player.GetComponent<Animator>().SetBool("PickingUp", true);
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
