using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer bile�eni
    public GameObject menuUI; // Ana men� butonlar�

    void Start()
    {
        // Men� butonlar�n� gizle
        if (menuUI != null)
            menuUI.SetActive(false);

        // Video otomatik oynas�n
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished; // Video bitince �al��acak fonksiyonu ba�la
        }
    }

    void Update()
    {
        // Space tu�una bas�l�nca videoyu ge�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false); // Video objesini tamamen kapat
        ShowMenu(); // Men� butonlar�n� a�
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
