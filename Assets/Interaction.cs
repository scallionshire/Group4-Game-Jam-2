using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera playerCamera; 
    public float interactDistance = 5f;
    public LayerMask layers;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; 
        }
    }

    void Update()
    {   
        // Constantly detect ray
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red, 2f);
        if (Physics.Raycast(ray, out hit, interactDistance, layers))
        {   
            Debug.Log("Hit " + hit.collider.gameObject.name);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {   
                interactable.LookAt();
            }
            if (Input.GetKeyDown("e")) // "e" is the key to interact with objects
            {   
                if (interactable != null)
                {   
                    interactable.Interact();
                }
            }
        }
    
    }
}
