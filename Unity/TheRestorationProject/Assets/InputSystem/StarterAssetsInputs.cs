using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
        [Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool pickUp;
		public bool sprint;
		public bool aim;
        public bool shoot;
		public bool shootable;
		public bool inventoryUI;
		public bool testAnimate;
		public bool pause;

		[Header("Movement Settings")]
		public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = false;
		public bool cursorInputForLook = true;

        public global::System.Boolean Shoot { get => shoot; set => shoot = value; }
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}
		public void OnShoot(InputValue value)
		{
			if(shootable)
				ShootInput(value.isPressed);
		}
		public void OnInventoryUI(InputValue value)
		{
			InventoryUIInput(value.isPressed);
		}
		public void OnPickUp(InputValue value)
		{
			PickUpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAim(InputValue value){
			AimInput(value.isPressed);
		}

		public void OnAnimateTest(InputValue value)
		{
			TestAnimateInput(value.isPressed);
		}

		public void OnPause(InputValue value)
		{
			PauseInput(value.isPressed);
		}

#else
		// old input sys if we do decide to have it (most likely wont)...
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}


		public void ShootInput(bool newShootState)
		{
			Shoot = newShootState;
		}
		public void InventoryUIInput(bool newInventoryUIState)
		{
			inventoryUI = newInventoryUIState;
		}
		public void PickUpInput(bool newPickUpState)
		{
			pickUp = newPickUpState;
		}
		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}
		public void TestAnimateInput(bool newTestAnimateState)
		{
			testAnimate = newTestAnimateState;
		}

		public void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.None;
			Cursor.visible = true;
		}

#endif

	}
	
}