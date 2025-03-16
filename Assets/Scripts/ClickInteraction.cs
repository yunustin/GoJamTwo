using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickInteraction : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer objRenderer;
    public GameObject character;
    private bool isInTwoD = false;
    private CameraSwitcher camswitcher;
    private Character myCharacter;
    public Image flashEffect;

    private int currentCamIndex = 0;
    private List<int> camSequence = new List<int> { 1, 2, 3, 4 ,5 ,6 ,7 ,8 ,9 ,10  }; // Sadece 1-2-3-4 sýrayla geçilecek

    public Vector2Int objectTilePosition;
    private PickUpItem pickUpItemScript;

    void Start()
    {
        if (character != null)
        {
            myCharacter = character.GetComponent<Character>();
        }

        camswitcher = FindObjectOfType<CameraSwitcher>(); // Scene’deki herhangi bir CameraSwitcher’ý bul
        if (camswitcher == null)
        {
            Debug.LogError("CameraSwitcher bulunamadý! Sahneye CameraSwitcher eklediðinizden emin olun.");
        }

        objRenderer = GetComponent<Renderer>();
        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }

        pickUpItemScript = GetComponent<PickUpItem>();

        if (myCharacter == null)
        {
            Debug.LogWarning("Character component not found on the character.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            camswitcher.CamSwitch(0); // K tuþuna basýnca her zaman 0. kamera
            isInTwoD = false;
            Debug.Log("K tuþuna basýldý, kamera 0'a döndü.");
        }
    }

    void OnMouseDown()
{
    if (myCharacter != null && myCharacter.currentTilePosition == objectTilePosition)
    {
        // Eðer elimde item varsa
        if (PlayerItemCheck.instance.HasItem())
        {
                // Scanner tag'li objeye týklanmýþsa
                if (CompareTag("Scanner"))
                {
                    Debug.Log("Týklanan objenin tag'ý: " + gameObject.tag);
                }
            }
        
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

        if (CompareTag("Bilgisayar"))
        {
            isInTwoD = true;
            StartCoroutine(FlashEffect());

            // Kamerayý sýradaki kamera ile deðiþtir
            camswitcher.CamSwitch(camSequence[currentCamIndex]);
            Debug.Log("Geçilen kamera: " + camSequence[currentCamIndex]);

            // Bir sonraki adýma geç, eðer sona geldiysek baþa dön
            currentCamIndex = (currentCamIndex + 1) % camSequence.Count;

            Debug.Log("Bilgisayara týkladýn!");
            ComputerGame();
        }
    }
}
    void OnMouseEnter()
    {
        if (myCharacter != null && myCharacter.currentTilePosition == objectTilePosition)
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

    public void ComputerGame()
    {
        Debug.Log("Pc ON");
    }

    IEnumerator FlashEffect()
    {
        Color flashColor = flashEffect.color;
        flashColor.a = 1;
        flashEffect.color = flashColor;

        yield return new WaitForSeconds(0.1f);

        while (flashEffect.color.a > 0)
        {
            flashColor.a -= Time.deltaTime * 2;
            flashEffect.color = flashColor;
            yield return null;
        }
    }
}
