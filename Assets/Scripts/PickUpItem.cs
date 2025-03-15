using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform targetPosition; // Objeyi ta��yaca��m�z hedef nokta (Inspector'dan atanacak)
    public float moveSpeed = 5f; // Objeyi s�z�lerek ta��ma h�z�

    private bool isMoving = false; // Objeyi ta��maya ba�lad�k m� kontrol etmek i�in

    public void PickUpThisItem(GameObject item)
    {
        StartCoroutine(MoveItemToTarget(item));
    }

    private IEnumerator MoveItemToTarget(GameObject item)
    {
        isMoving = true;
        float timeElapsed = 0f;

        Vector3 startPos = item.transform.position; // Objeyi ald��� anki konum
        Vector3 endPos = targetPosition.position; // Objeyi ta��yaca��m�z nokta

        // Objeyi hedef pozisyona s�z�lerek ta��
        while (timeElapsed < 1f)
        {
            timeElapsed += Time.deltaTime * moveSpeed;
            item.transform.position = Vector3.Lerp(startPos, endPos, timeElapsed);
            yield return null;
        }

        // Objeyi tam hedef noktaya yerle�tir ve child yap
        item.transform.position = endPos;
        item.transform.SetParent(targetPosition); // Objeyi targetPosition'un child'� yap

        isMoving = false;
    }
}
