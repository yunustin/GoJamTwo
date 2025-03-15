using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer bileþeni
    public GameObject menuUI; // Ana menü butonlarý

    void Start()
    {
        // Menü butonlarýný gizle
        if (menuUI != null)
            menuUI.SetActive(false);

        // Video otomatik oynasýn
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished; // Video bitince çalýþacak fonksiyonu baðla
        }
    }

    void Update()
    {
        // Space tuþuna basýlýnca videoyu geç
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false); // Video objesini tamamen kapat
        ShowMenu(); // Menü butonlarýný aç
    }

    void SkipVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            ShowMenu();
        }
    }

    void ShowMenu()
    {
        if (menuUI != null)
            menuUI.SetActive(true);
    }
}
