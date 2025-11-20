using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(ControlMusicaVolumen);
    }

    private void Start()
    {
        Cargar();
    }

    private void ControlMusicaVolumen(float valor)
    {
        mixer.SetFloat("VolumenMusica", Mathf.Log10(valor) * 20);
        PlayerPrefs.SetFloat("VolumenMusica", musicSlider.value);
    }

    private void Cargar()
    {
        musicSlider.value = PlayerPrefs.GetFloat("VolumenMusica", 0.75f);
        ControlMusicaVolumen(musicSlider.value);
    }

}
