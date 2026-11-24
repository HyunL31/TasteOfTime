using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : ViewBase
{
    [SerializeField] private Button Button_Login;
    [SerializeField] private Button Button_Regist;
    [SerializeField] private Toggle Toggle_AutoLogin;
    [SerializeField] private TMP_InputField Input_UserID;
    [SerializeField] private TMP_InputField Input_Password;

    private void Awake()
    {
        Button_Login.onClick.AddListener(OnClickLogin);
        Button_Regist.onClick.AddListener(OnClickRegist);

        Toggle_AutoLogin.onValueChanged.AddListener(OnAutoLogin);
    }

    private void OnClickLogin()
    {
        UIManager.Inst.CloseLoginUI();
    }

    private void OnClickRegist()
    {

    }

    private void OnAutoLogin(bool isOn)
    {

    }
}
