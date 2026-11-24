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

    public static TitleUI OpenTitleUI(this UIManager uiManager)
    {
        UIBase uiBase = uiManager.OpenUI(UIRoot.Main, UIType.TitleUI);

        if (uiBase is TitleUI title)
        {
            return title;
        }

        return null;
    }

    public static void CloseTitleUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.TitleUI);
    }

    public static SettingUI OpenSettingUI(this UIManager uiManager, bool isTitle = false)
    {
        UIBase uiBase = uiManager.OpenUI(UIRoot.Main, UIType.SettingUI);
        
        if (uiBase is SettingUI settingUI)
        {
            settingUI.SetIsTitle(isTitle);
            return settingUI;
        }

        return null;
    }

    public static void CloseSettingUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.SettingUI);
    }

    public static LoginUI OpenLoginUI(this UIManager uiManager)
    {
        UIBase uiBase = uiManager.OpenUI(UIRoot.Main, UIType.LoginUI);

        if (uiBase is LoginUI loginUI)
        {
            return loginUI;
        }

        return null;
    }

    public static void CloseLoginUI(this UIManager uiManager)
    {
        uiManager.CloseUI(UIRoot.Main, UIType.LoginUI);
    }
}
