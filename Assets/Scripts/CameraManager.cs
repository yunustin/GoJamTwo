using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>(); // Kameralarý burada tutuyoruz
    private int activeCamIndex = 0;

    private void Start()
    {
        // Baþlangýçta tüm kameralarý listeye ekleyelim
        cameras.AddRange(FindObjectsOfType<Camera>());

        // Bütün kameralarý kapatýp sadece ilk kamerayý açalým
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        if (cameras.Count > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    public void CamSwitch(int camIndex)
    {
        if (camIndex < 0 || camIndex >= cameras.Count)
        {
            Debug.LogWarning("Geçersiz kamera indexi: " + camIndex);
            return;
        }

        // Þu anki kamerayý kapat
        cameras[activeCamIndex].gameObject.SetActive(false);

        // Yeni kamerayý aç
        activeCamIndex = camIndex;
        cameras[activeCamIndex].gameObject.SetActive(true);

        Debug.Log("Kamera deðiþti: " + activeCamIndex);
    }
}
