using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class TestAnimation : MonoBehaviour
{
    public GameObject playerGameObject;
    StarterAssetsInputs inputSystem;
    Animator animator;
    bool aiming = false;

    // Start is called before the first frame update
    void Start()
    {
        inputSystem = playerGameObject.GetComponent<StarterAssetsInputs>();
        animator = playerGameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputSystem.aim && !aiming) 
        {
            //animator.SetBool("Aim", true);
            //inputSystem.testAnimate = false;
            //aiming = true;
        }
        else if(aiming && !inputSystem.aim)
        {
            //animator.SetBool("Aim", false);
            //aiming = false;
        }
    }
}
