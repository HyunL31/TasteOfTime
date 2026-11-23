using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] private Canvas Canvas_Main;
    [SerializeField] private Canvas Canvas_Popup;

    private Dictionary<UIType, UIBase> _createdUI = new Dictionary<UIType, UIBase>();
    private HashSet<UIType> _activeUI = new HashSet<UIType>();

    private void Start()
    {
        this.OpenTitleUI();
    }

    public UIBase OpenUI(UIRoot root, UIType type)
    {
        UIBase openedUI = GetOpenedUI(root, type);

        if (_activeUI.Contains(type) == false)
        {
            openedUI.gameObject.SetActive(true);
            _activeUI.Add(type);
        }

        return openedUI;
    }

    public void CloseUI(UIRoot root, UIType type)
    {
        if (_activeUI.Contains(type))
        {
            UIBase openedUI = GetOpenedUI(root, type);
            openedUI.gameObject.SetActive(false);
            _activeUI.Remove(type);
        }
    }

    private void CreateUI(UIRoot root, UIType type)
    {
        if (_createdUI.ContainsKey(type) == false)
        {
            string path = this.GetUIPath(root, type);

            GameObject prefab = Resources.Load<GameObject>(path);
            Transform rootTransform = GetRootTransform(root);
            GameObject ui = Instantiate(prefab, rootTransform);

            if (ui != null)
            {
                UIBase uiBase = ui.GetComponent<UIBase>();
                _createdUI.Add(type, uiBase);
            }
        }
    }

    public UIBase GetOpenedUI(UIRoot root, UIType type)
    {
        return GetCreatedUI(root, type);
    }

    private UIBase GetCreatedUI(UIRoot root, UIType type)
    {
        if (_createdUI.ContainsKey(type) == false)
        {
            CreateUI(root, type);
        }

        return _createdUI[type];
    }

    private Transform GetRootTransform(UIRoot root)
    {
        Transform rootTransform = null;

        switch (root)
        {
            case UIRoot.Main:
                rootTransform = Canvas_Main.transform;
                break;

            case UIRoot.Popup:
                rootTransform = Canvas_Popup.transform;
                break;
        }

        return rootTransform;
    }
}