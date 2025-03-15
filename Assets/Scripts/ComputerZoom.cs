using UnityEngine;

public class ComputerZoom : MonoBehaviour
{
    // Hareket ettirmek istedi�iniz obje
    public GameObject targetObject;
    // Hedef pozisyon
    public Transform targetPosition;
    public Vector2Int PCTile;

    private GridMovement gridMovement;
    // Objeye t�klan�p t�klanmad���n� belirten bool de�i�keni
    public bool isClicked = false;

    // Smooth hareket i�in s�re
    public float moveSpeed = 2f;

    void Start()
    {
        gridMovement = targetObject.GetComponent<GridMovement>();

    }
    // Update, t�klama kontrol� yapmak i�in
    void Update()
    {
        // E�er sol fare tu�una t�klanm��sa
        if (Input.GetMouseButtonDown(0))
        {

            
            // T�klanan objeyi kontrol etmek i�in raycast kullan�yoruz
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // E�er t�klanan obje bu script'e ba�l� obje ise
                if (hit.transform == transform)
                {
                   
                    // isClicked de�erini true yap
                    isClicked = true;
                }
            }
        }

        if (gridMovement != null && gridMovement.currentTilePosition == PCTile)
        {
            gridMovement.enabled = false;
        }







        // E�er t�klanm��sa, objeyi smooth �ekilde hareket ettir
        if (isClicked)
        {
            // Objeyi hedef pozisyona smooth bir �ekilde ta��
            MoveObjectSmoothly();
        }
    }

    // Hedef objeyi smooth bir �ekilde hareket ettirir
    void MoveObjectSmoothly()
    {
        // targetObject'� hedef pozisyona yumu�ak bir �ekilde ta��r
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