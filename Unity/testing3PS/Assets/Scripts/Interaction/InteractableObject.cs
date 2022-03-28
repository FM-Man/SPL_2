using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float radiusOfInteraction = 1.5f;
    bool isFocus;
    bool hasInteracted = false;
    Transform player;

    public void OnFocus(Transform playerTransform) { 
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;

    }
    public void OnDefocus() { 
        isFocus=false;
        hasInteracted=false;
        player = null;
    }

    public virtual void Interact()
    {

    }

    public void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < radiusOfInteraction) {
                //Debug.Log("interact");
                Interact();
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusOfInteraction);
    }
}
