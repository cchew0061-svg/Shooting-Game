using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private Interactables interactables;

    void Start()
    {
		cam = Camera.main;
		playerUI = GetComponent<PlayerUI>();
		inputManager = GetComponent<InputManager>();
		interactables = GetComponent<Interactables>();
    }

    void Update()
    {
		playerUI.UpdateText(string.Empty);
		//creates a ray at the centre of the camera to detect collisions
		Ray ray = new Ray(cam.transform.position, cam.transform.forward);
		Debug.DrawRay(ray.origin, ray.direction * distance);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray, out hitInfo, distance, mask))
		{
			//if item is detected by the ray, text appears
			if(hitInfo.collider.GetComponent<Interactables>() != null)
			{
				Interactables interactables = hitInfo.collider.GetComponent<Interactables>();
				playerUI.UpdateText(interactables.promptMessage);
				//if F is pressed on an object, triggers the PickUp() function
				if(inputManager.onFoot.Grab.triggered)
				{
					interactables.PickUp();
				}
			}
		}
    }
}
