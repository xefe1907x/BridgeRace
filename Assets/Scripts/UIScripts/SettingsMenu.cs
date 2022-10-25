using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Slider slider;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
