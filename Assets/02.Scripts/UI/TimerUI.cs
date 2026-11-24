using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : ViewBase
{
    [Header("패널")]
    [SerializeField] private PanelSlide PanelSlide;
    [SerializeField] private PanelSwitcher PanelSwitcher;

    [Header("사운드")]
    [SerializeField] private Button Button_Prev;
    [SerializeField] private Button Button_Next;
    [SerializeField] private Button Button_Play;
    [SerializeField] private Button Button_Pause;

    [Header("오늘")]
    [SerializeField] private Image Image_Wheater;
    [SerializeField] private TextMeshProUGUI Text_Wheater;
    [SerializeField] private TextMeshProUGUI Text_TodayTimer;

    [Header("현재")]
    [SerializeField] private Button Button_Left;
    [SerializeField] private Button Button_Right;
    [SerializeField] private Image Image_State;
    [SerializeField] private TextMeshProUGUI Text_State;
    [SerializeField] private TextMeshProUGUI Text_CurrentTimer;
    [SerializeField] private Button Button_Start;
    [SerializeField] private Button Button_End;

    [Header("수집")]
    [SerializeField] private Image Image_Food;
    [SerializeField] private TextMeshProUGUI Text_Progress;

    private void Awake()
    {
        
    }

    public PanelSlide GetPanelSlide()
    {
        return PanelSlide;
    }
}
