using UnityEngine;

public class ChangeColorOnRaycast : MonoBehaviour
{
    void Update()
    {
        // Raycast detection
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits an object with the Highlight script
            Highlight highlightScript = hit.collider.GetComponent<Highlight>();
            if (highlightScript != null)
            {
                // Toggle the isHighlighted property
                highlightScript.ToggleHighlight(true);
            }
        }
        else
        {
            // If the ray doesn't hit any object, untoggle isHighlighted for all objects
            Highlight[] allHighlightScripts = FindObjectsOfType<Highlight>();
            foreach (Highlight highlightScript in allHighlightScripts)
            {
                highlightScript.ToggleHighlight(false);
            }
        }
    }
}
