using UnityEngine;

[CreateAssetMenu(fileName= "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name + " item");
    }

}
