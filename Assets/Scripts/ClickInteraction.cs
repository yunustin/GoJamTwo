using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer objRenderer;
    public GameObject character;
    private GridMovement gridMov;
    public Vector2Int objectTilePosition;

    private PickUpItem pickUpItemScript;

    void Start()
    {
        if (character != null)
        {
            gridMov = character.GetComponent<GridMovement>();
        }

        objRenderer = GetComponent<Renderer>();
        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }

        pickUpItemScript = GetComponent<PickUpItem>();

        if (gridMov == null)
        {
            Debug.LogWarning("GridMovement component not found on the character.");
        }
    }

    void OnMouseDown()
    {
        if (gridMov != null && gridMov.currentTilePosition == objectTilePosition)
        {
            if (pickUpItemScript != null)
            {
                if (!PlayerItemCheck.instance.HasItem()) // Eðer elimizde item yoksa al
                {
                    Debug.Log("Objeye týkladýn: " + gameObject.name);
                    PlayerItemCheck.instance.SetItemPickedUp(true);
                    pickUpItemScript.PickUpThisItem(gameObject);
                }
                else if (pickUpItemScript.IsPickedUp()) // Eðer elimizdeki item buysa geri býrak
                {
                    Debug.Log("Eldeki item býrakýlýyor.");
                    pickUpItemScript.PutDownItem();
                    PlayerItemCheck.instance.SetItemPickedUp(false);
                }
            }
        }
    }

    void OnMouseEnter()
    {
        if (gridMov != null && gridMov.currentTilePosition == objectTilePosition)
        {
            if (highlightMaterial != null && objRenderer != null)
            {
                objRenderer.material = highlightMaterial;
            }
        }
    }

    void OnMouseExit()
    {
        if (originalMaterial != null && objRenderer != null)
        {
            objRenderer.material = originalMaterial;
        }
    }
}
