using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject QuitButton;

    public Slider volumeSlider;

    public AudioMixer audioMixer;  // Audio Mixer'ý burada tanýmlýyoruz

    private void Start()
    {
        // Kaydedilen ses seviyesi yüklenir
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);  // Kaydedilen ses seviyesini ayarla
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("KaanSex"); // "GameScene" yerine oyunun ana sahnesini yaz
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        //playButton.SetActive(false);
        //optionsButton.SetActive(false);
        //QuitButton.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        //playButton.SetActive(true);
        //optionsButton.SetActive(true);
        //QuitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan Çýktýn");
    }

    public void SetVolume(float volume)
    {
        // Ses seviyesini Audio Mixer üzerinden ayarla
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);  // 0-1 arasý bir deðer, dB'ye çevrildi
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
