using UnityEngine;
using UnityEngine.UI;

public class TitleUI : ViewBase
{
    [SerializeField] private Button Button_Login;
    [SerializeField] private Button Button_Setting;
    [SerializeField] private Button Button_Quit;

    private void Awake()
    {
        Button_Login.onClick.AddListener(OnClickLogin);
        Button_Setting.onClick.AddListener(OnClickSetting);
        Button_Quit.onClick.AddListener(OnClickQuit);
    }

    private void OnClickLogin()
    {
        UIManager.Inst.OpenLoginUI();
        UIManager.Inst.CloseTitleUI();
    }

    private void OnClickSetting()
    {
        UIManager.Inst.OpenSettingUI();
    }

    private void OnClickQuit()
    {
        Application.Quit();
    }
}

