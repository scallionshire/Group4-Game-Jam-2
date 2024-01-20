using UnityEngine;

public class Interactable : MonoBehaviour
{   
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    void Update()
    {
        RemoveHighlight();
    }

    void Highlight()
    {
        renderer.material = highlightMaterial;
    }

    void RemoveHighlight()
    {
        renderer.material = originalMaterial;
    }

    public void Interact()
    {
        // Implement your interaction logic here
        Debug.Log("Interacted with " + gameObject.name);
        // Hide this object
        gameObject.SetActive(false);
    }

    public void LookAt()
    {
        Highlight();
    }
}
