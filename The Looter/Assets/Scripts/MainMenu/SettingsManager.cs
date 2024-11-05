using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour{

    [Header("UI Sliders")]
    public AudioMixer audioMixer;
    public Slider mouseSensitivitySlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    private const string MouseSensitivityKey = "MouseSensitivity";
    private const string SFXVolumeKey = "SFXVolume";
    private const string MusicVolumeKey = "MusicVolume";

    private void LoadVolumeSettings(){

        float sensi = PlayerPrefs.GetFloat("MouseSensitivity", 100f);
        mouseSensitivitySlider.value = sensi;

        // Cargar los valores guardados en los sliders y el AudioMixer
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        masterSlider.value = masterVolume;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);

        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        musicSlider.value = musicVolume;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);

        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        sfxSlider.value = sfxVolume;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
    }

    private void Start(){
        LoadVolumeSettings();
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void OnDisable(){
        PlayerPrefs.Save();
    }

    public void SetMouseSensitivity(float sensitivity){
        PlayerPrefs.SetFloat(MouseSensitivityKey, sensitivity);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("MouseSensitivity", 1.0f));
    }
    
    public void SetMasterVolume(float value){
        float dB = (value <= 0.0001f) ? -80f : Mathf.Log10(value) * 20;
        audioMixer.SetFloat("MasterVolume", dB);
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value){
        float dB = (value <= 0.0001f) ? -80f : Mathf.Log10(value) * 20;
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value){
        float dB = (value <= 0.0001f) ? -80f : Mathf.Log10(value) * 20;
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
