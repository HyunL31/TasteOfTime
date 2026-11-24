using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : ViewBase
{
    [SerializeField] private PanelSwitcher PanelSwitcher;
    [SerializeField] private PanelSlide PanelSlide;
    [SerializeField] private Button Button_Login;
    [SerializeField] private Button Button_Setting;
    [SerializeField] private Button Button_Quit;

    private PanelSlide _nextPanel;

    private void Awake()
    {
        Button_Login.onClick.AddListener(() => OnClickLogin().Forget());
        Button_Setting.onClick.AddListener(() => OnClickSetting().Forget());
        Button_Quit.onClick.AddListener(OnClickQuit);
    }

    private async UniTask OnClickLogin()
    {
        LoginUI login = UIManager.Inst.OpenLoginUI();
        login.gameObject.SetActive(false);

        await PanelSwitcher.SwitchTo(login.GetPanelSlide(), Vector2.right, Vector2.right);
        UIManager.Inst.CloseTitleUI();
    }

    private async UniTask OnClickSetting()
    {
        SettingUI setting = UIManager.Inst.OpenSettingUI(true);
        setting.gameObject.SetActive(false);

        await PanelSwitcher.SwitchTo(setting.GetPanelSlide(), Vector2.right, Vector2.right);
        UIManager.Inst.CloseTitleUI();
    }

    private void OnClickQuit()
    {
        Application.Quit();
    }

    public PanelSlide GetPanelSlide()
    {
        return PanelSlide;
    }
}

