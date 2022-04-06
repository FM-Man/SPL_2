using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float radiusOfInteraction = 1.5f;
    bool isFocus;
    bool hasInteracted = false;
    GameObject playerObject;

    public void OnFocus(GameObject playergameobject) { 
        isFocus = true;
        hasInteracted = false;
        playerObject = playergameobject;
    }
    public void OnDefocus() { 
        isFocus=false;
        hasInteracted=false;
        playerObject=null;
    }

    public virtual void Interact(Inventory inventory)
    {

    }

    public void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(playerObject.transform.position, transform.position);
            if (distance < radiusOfInteraction) {
                //Debug.Log("interact");
                Interact(playerObject.GetComponent<Inventory>());
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfInteraction);
    }
}
