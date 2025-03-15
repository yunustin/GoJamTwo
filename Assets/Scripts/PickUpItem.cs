using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform targetPosition; // Objeyi taþýyacaðýmýz hedef nokta (Inspector'dan atanacak)
    public float moveSpeed = 5f; // Objeyi süzülerek taþýma hýzý

    private bool isMoving = false; // Objeyi taþýmaya baþladýk mý kontrol etmek için

    public void PickUpThisItem(GameObject item)
    {
        StartCoroutine(MoveItemToTarget(item));
    }

    private IEnumerator MoveItemToTarget(GameObject item)
    {
        isMoving = true;
        float timeElapsed = 0f;

        Vector3 startPos = item.transform.position; // Objeyi aldýðý anki konum
        Vector3 endPos = targetPosition.position; // Objeyi taþýyacaðýmýz nokta

        // Objeyi hedef pozisyona süzülerek taþý
        while (timeElapsed < 1f)
        {
            timeElapsed += Time.deltaTime * moveSpeed;
            item.transform.position = Vector3.Lerp(startPos, endPos, timeElapsed);
            yield return null;
        }

        // Objeyi tam hedef noktaya yerleþtir ve child yap
        item.transform.position = endPos;
        item.transform.SetParent(targetPosition); // Objeyi targetPosition'un child'ý yap

        isMoving = false;
    }
}
