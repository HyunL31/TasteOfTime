using UnityEngine;

public enum UIRoot
{
    None,
    Main,
    Popup
}

public enum UIType
{
    None,
    TitleUI,
    SettingUI,
    LoginUI
}

public static class UIExtension
{
    public static string GetUIPath(this UIManager uiManager, UIRoot root, UIType type)
    {
        return $"Prefabs/UI/{root}/{type}";
    }

    public static void OpenTitleUI(this UIManager uiManager)
    {
        uiManager.OpenUI(UIRoot.Main, UIType.TitleUI);
    }

    public static void CloseTitleUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.TitleUI);
    }

    public static void OpenSettingUI(this UIManager uiManager)
    {
        uiManager.OpenUI(UIRoot.Main, UIType.SettingUI);
    }

    public static void CloseSettingUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.SettingUI);
    }

    public static void OpenLoginUI(this UIManager uiManager)
    {
        uiManager.OpenUI(UIRoot.Main, UIType.LoginUI);
    }

    public static void CloseLoginUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.LoginUI);
    }
}
