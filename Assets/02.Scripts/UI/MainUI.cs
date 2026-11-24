using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : ViewBase
{
    [SerializeField] private PanelSwitcher PanelSwitcher;
    [SerializeField] private PanelSlide PanelSlide;
    [SerializeField] private Button Button_MyPage;
    [SerializeField] private Button Button_Timer;
    [SerializeField] private Button Button_Map;
    [SerializeField] private Button Button_Dictionary;
    [SerializeField] private Button Button_Quest;
    [SerializeField] private Button Button_Inventory;
    [SerializeField] private Button Button_Setting;

    private void Awake()
    {
        Button_MyPage.onClick.AddListener(OnClickMyPage);
        Button_Timer.onClick.AddListener(() => OnClickTimer().Forget());
        Button_Map.onClick.AddListener(OnClickMap);
        Button_Dictionary.onClick.AddListener(OnClickDictionary);
        Button_Quest.onClick.AddListener(OnClickQuest);
        Button_Inventory.onClick.AddListener(OnClickInventory);
        Button_Setting.onClick.AddListener(() => OnClickSetting().Forget());
    }

    private void OnClickMyPage()
    {

    }

    private async UniTask OnClickTimer()
    {
        TimerUI timer = UIManager.Inst.OpenTimerUI();
        timer.gameObject.SetActive(false);

        await PanelSwitcher.SwitchTo(timer.GetPanelSlide(), Vector2.right, Vector2.right);
        UIManager.Inst.CloseMainUI();
    }

    private void OnClickMap()
    {

    }

    private void OnClickDictionary()
    {

    }

    private void OnClickQuest()
    {

    }

    private void OnClickInventory()
    {

    }

    private async UniTask OnClickSetting()
    {
        SettingUI setting = UIManager.Inst.OpenSettingUI();
        setting.gameObject.SetActive(false);

        await PanelSwitcher.SwitchTo(setting.GetPanelSlide(), Vector2.right, Vector2.right);
        UIManager.Inst.CloseMainUI();
    }

    public PanelSlide GetPanelSlide()
    {
        return PanelSlide;
    }
}
