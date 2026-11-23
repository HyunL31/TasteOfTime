using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : ViewBase
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Button Button_Close;
    [SerializeField] private Button Button_Reset;
    [SerializeField] private Button Button_Logout;
    [SerializeField] private Slider Slider_BGM;
    [SerializeField] private Slider Slider_SFX;

    private float _defaultVolume = 0.5f;

    private const string BGM = "BGM";
    private const string SFX = "SFX";

    private void Awake()
    {
        Slider_BGM.value = PlayerPrefs.GetFloat(BGM, _defaultVolume);
        Slider_SFX.value = PlayerPrefs.GetFloat(SFX, _defaultVolume);

        Button_Close.onClick.AddListener(OnClickClose);
        Button_Reset.onClick.AddListener(OnClickReset);
        Button_Logout.onClick.AddListener(OnClickLogout);

        Slider_BGM.onValueChanged.AddListener(OnChangeBGM);
        Slider_SFX.onValueChanged.AddListener(OnChangeSFX);
    }

    private void OnClickClose()
    {
        PlayerPrefs.Save();
        UIManager.Inst.CloseSettingUI();
    }

    private void OnClickLogout()
    {
        UIManager.Inst.CloseSettingUI();
    }

    private void OnChangeBGM(float value)
    {
        AudioMixer.SetFloat(BGM, Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat(BGM, value);
    }
    
    private void OnChangeSFX(float value)
    {
        AudioMixer.SetFloat(SFX, Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat(SFX, value);
    }

    private void OnClickReset()
    {
        PlayerPrefs.SetFloat(BGM, _defaultVolume);
        PlayerPrefs.SetFloat(SFX, _defaultVolume);

        OnChangeBGM(_defaultVolume);
        OnChangeSFX(_defaultVolume);

        Slider_BGM.value = _defaultVolume;
        Slider_SFX.value = _defaultVolume;
    }
}
