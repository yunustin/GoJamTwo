using UnityEngine;

public class ComputerZoom : MonoBehaviour
{
    // Hareket ettirmek istediðiniz obje
    public GameObject targetObject;
    // Hedef pozisyon
    public Transform targetPosition;
    public Vector2Int PCTile;

    private GridMovement gridMovement;
    // Objeye týklanýp týklanmadýðýný belirten bool deðiþkeni
    public bool isClicked = false;

    // Smooth hareket için süre
    public float moveSpeed = 2f;

    void Start()
    {
        gridMovement = targetObject.GetComponent<GridMovement>();

    }
    // Update, týklama kontrolü yapmak için
    void Update()
    {
        // Eðer sol fare tuþuna týklanmýþsa
        if (Input.GetMouseButtonDown(0))
        {

            
            // Týklanan objeyi kontrol etmek için raycast kullanýyoruz
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Eðer týklanan obje bu script'e baðlý obje ise
                if (hit.transform == transform)
                {
                   
                    // isClicked deðerini true yap
                    isClicked = true;
                }
            }
        }

        if (gridMovement != null && gridMovement.currentTilePosition == PCTile)
        {
            gridMovement.enabled = false;
        }







        // Eðer týklanmýþsa, objeyi smooth þekilde hareket ettir
        if (isClicked)
        {
            // Objeyi hedef pozisyona smooth bir þekilde taþý
            MoveObjectSmoothly();
        }
    }

    // Hedef objeyi smooth bir þekilde hareket ettirir
    void MoveObjectSmoothly()
    {
        // targetObject'ý hedef pozisyona yumuþak bir þekilde taþýr
        if (targetObject != null && targetPosition != null)
        {
            targetObject.transform.position = Vector3.Lerp(
                targetObject.transform.position,
                targetPosition.position,
                Time.deltaTime * moveSpeed
            );
        }
    }
}