using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    InputSystem_Actions input;
    [Header("Video Options")]
    public Toggle fullscreenSelect;

    [Header("Audio Options")]
    public AudioMixer theMixer;
    public TMP_Text mastLabel, musicLabel, sfxLabel;
    public Slider mastSlider, musicSlider, sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
         input = new InputSystem_Actions();
    }
    void Start()
    {
        fullscreenSelect.isOn = Screen.fullScreen;

        float vol = 0f;
        theMixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;
        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        mastLabel.text = (mastSlider.value + 80).ToString();
        musicLabel.text = (musicSlider.value + 80).ToString();
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        menuCanvas.SetActive(false);
    }
    
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMasterVol()
    {
        mastLabel.text = (mastSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", mastSlider.value);
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);

    }
    public void SetMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);

    }
     public void SetSFXVol()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);

    }
    
    public void ApplyFullscreen()
    {
        Screen.fullScreen = fullscreenSelect.isOn;
        
    }
}


