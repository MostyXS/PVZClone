using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeRegulator;
    [SerializeField] float defaultVolume = 0.2f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;
    // Start is called before the first frame update
    void Start()
    {
        volumeRegulator.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeRegulator.value);
        }
        else 
            Debug.LogWarning("No music player found...");
        
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeRegulator.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetToDefault()
    {
        volumeRegulator.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }


}
