using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : ViewBase
{
    [SerializeField] private PanelSwitcher PanelSwitcher;
    [SerializeField] private PanelSlide PanelSlide;
    [SerializeField] private Button Button_Login;
    [SerializeField] private Button Button_Regist;
    [SerializeField] private Toggle Toggle_AutoLogin;
    [SerializeField] private TMP_InputField Input_UserID;
    [SerializeField] private TMP_InputField Input_Password;

    private void Awake()
    {
        Button_Login.onClick.AddListener(() => OnClickLogin().Forget());
        Button_Regist.onClick.AddListener(OnClickRegist);

        Toggle_AutoLogin.onValueChanged.AddListener(OnAutoLogin);
    }

    private async UniTask OnClickLogin()
    {
        MainUI main = UIManager.Inst.OpenMainUI();
        main.gameObject.SetActive(false);

        await PanelSwitcher.SwitchTo(main.GetPanelSlide(), Vector2.right, Vector2.right);

        UIManager.Inst.CloseLoginUI();
    }

    private void OnClickRegist()
    {

    }

    private void OnAutoLogin(bool isOn)
    {

    }

    public PanelSlide GetPanelSlide()
    {
        return PanelSlide;
    }
}
