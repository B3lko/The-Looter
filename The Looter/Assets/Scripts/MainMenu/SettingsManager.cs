using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour{

    [Header("UI Sliders")]
    public Slider mouseSensitivitySlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    private const string MouseSensitivityKey = "MouseSensitivity";
    private const string SFXVolumeKey = "SFXVolume";
    private const string MusicVolumeKey = "MusicVolume";

    void Start()
    {
        // Cargar los valores guardados al iniciar la escena
        LoadSettings();

        // Suscribir funciones para actualizar los PlayerPrefs cuando cambien los sliders
        mouseSensitivitySlider.onValueChanged.AddListener(SetMouseSensitivity);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void LoadSettings()
    {
        // Cargar sensibilidad del mouse
        float savedMouseSensitivity = PlayerPrefs.GetFloat(MouseSensitivityKey, 1.0f);
        mouseSensitivitySlider.value = savedMouseSensitivity;

        // Cargar volumen de efectos de sonido (SFX)
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1.0f);
        sfxVolumeSlider.value = savedSFXVolume;

        // Cargar volumen de la música
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1.0f);
        musicVolumeSlider.value = savedMusicVolume;
    }

    public void SetMouseSensitivity(float sensitivity){
        PlayerPrefs.SetFloat(MouseSensitivityKey, sensitivity);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("MouseSensitivity", 1.0f));
    }

    public void SetSFXVolume(float volume){
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
        PlayerPrefs.Save();
        // Aquí puedes agregar lógica para actualizar el volumen SFX en tiempo real
    }

    public void SetMusicVolume(float volume){
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
        // Aquí puedes agregar lógica para actualizar el volumen de la música en tiempo real
    }
}
