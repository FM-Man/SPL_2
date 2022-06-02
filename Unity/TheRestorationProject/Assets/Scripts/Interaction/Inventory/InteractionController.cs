using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour{
    [SerializeField] public InteractableObject focus;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update(){
        if (starterAssetsInputs.pickUp){
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 999)) {
                //get the interactable component
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                
                if (focus == null){
                    if (interactable != null) {//if there is no focus and the ray hit something then focus on that
                        setFocus(interactable);
                        GetComponent<Animator>().SetBool("PickingUp", false);
                    }
                    else
                    {
                        starterAssetsInputs.pickUp = false;
                        GetComponent<Animator>().SetBool("PickingUp", false);
                    }
                }
                else {//else defocus
                    deFocus();
                    starterAssetsInputs.pickUp = false;
                    GetComponent<Animator>().SetBool("PickingUp", false);
                }
            }

            starterAssetsInputs.pickUp = false;
            GetComponent<Animator>().SetBool("PickingUp", false);
        }
    }

    void setFocus(InteractableObject newFocus) { 
        focus = newFocus;
        newFocus.OnFocus(gameObject);
    }

    void deFocus() {
        focus.OnDefocus();
        focus = null;
    }
}
