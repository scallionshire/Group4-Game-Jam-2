using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera playerCamera; 
    public float interactDistance = 5f;
    public LayerMask layers;
    public PlayerManager playerManager;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; 
        }
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {   
        // Constantly detect ray
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        // Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red, 2f);
        if (Physics.Raycast(ray, out hit, interactDistance, layers))
        {   
            Debug.Log("Hit " + hit.collider.gameObject.name);
            InteractablePC interactablePC = hit.collider.GetComponent<InteractablePC>();
            InteractableUSB interactableUSB = hit.collider.GetComponent<InteractableUSB>();

            if (interactablePC != null)
            {   
                interactablePC.LookAt();
            }
            else if (interactableUSB != null)
            {   
                interactableUSB.LookAt();
            }

            if (Input.GetKeyDown("e")) // "e" is the key to interact with objects
            {   
                if (interactablePC != null && playerManager.getHasUSB())
                {   
                    interactablePC.Interact();
                }
                else if (interactableUSB != null)
                {   
                    interactableUSB.Interact();
                    playerManager.setHasUSB(true);
                }
            }
        }
    
    }
}
