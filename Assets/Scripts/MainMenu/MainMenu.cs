using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject QuitButton;

    public Slider volumeSlider;
    //public AudioSource backgroundMusic;

    private void Start()
    {
        // Load saved volume level
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        //backgroundMusic.volume = savedVolume;
        volumeSlider.value = savedVolume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("KaanSex"); // "GameScene" yerine oyununun ana sahnesini yaz
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        QuitButton.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        QuitButton.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan Çýktýn");
    }

    public void SetVolume(float volume)
    {
        //backgroundMusic.volume = volume;
        //PlayerPrefs.SetFloat("Volume", volume);
        //PlayerPrefs.Save();
    }
}
