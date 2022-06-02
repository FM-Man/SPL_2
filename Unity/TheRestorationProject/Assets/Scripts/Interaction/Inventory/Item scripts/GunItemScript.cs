using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item/GunItem")]
public class GunItemScript : Item
{
    public override void Use(GameObject player)
    {
        //Debug.Log(" hehe Using " + name + " item");
        player.GetComponent<ShooterController>().SetGun(true);
    }
}
