using DG.Tweening;
using System;
using UnityEngine;

public class PanelSlide : MonoBehaviour
{
    [SerializeField] private RectTransform Rect_Panel;
    [SerializeField] private float Speed_Duration;
    [SerializeField] Ease Ease = Ease.OutCubic;

    [SerializeField] private bool IsPlayOnEnable = true;
    [SerializeField] private Vector2 Dicrection_Enter = Vector2.zero;

    private Vector2 _homePos;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        if (IsPlayOnEnable == true)
        {
            SlideIn(Dicrection_Enter);
        }
    }

    private void Init()
    {
        if (_isInit == true)
        {
            return;
        }

        _homePos = Rect_Panel.anchoredPosition;
        _isInit = true;
    }

    private Vector2 GetOffset(Vector2 direction)
    {
        RectTransform parent = Rect_Panel.parent as RectTransform;

        float x = direction.x * (parent.rect.width * 0.5f + Rect_Panel.rect.width);
        float y = direction.y * (parent.rect.height * 0.5f + Rect_Panel.rect.height);

        return new Vector2(x, y);
    }

    public void SlideIn(Vector2 from, Action onComplete = null)
    {
        Init();

        DOTween.Kill(Rect_Panel);

        if (Rect_Panel.gameObject.activeSelf == false)
        {
            Rect_Panel.gameObject.SetActive(true);
        }

        Rect_Panel.anchoredPosition = _homePos + GetOffset(from);
        Rect_Panel.DOAnchorPos(_homePos, Speed_Duration).SetEase(Ease).SetTarget(Rect_Panel).OnComplete(() => onComplete?.Invoke());
    }

    public void SlideOut(Vector2 to, Action onComplete = null)
    {
        Init();

        DOTween.Kill(Rect_Panel);

        Rect_Panel.DOAnchorPos(_homePos + GetOffset(to), Speed_Duration).SetEase(Ease).SetTarget(Rect_Panel).OnComplete(() =>
        {
            if (Rect_Panel.gameObject.activeSelf == true)
            {
                Rect_Panel.gameObject.SetActive(false);
            }

            Rect_Panel.anchoredPosition = _homePos;
            onComplete?.Invoke();
        });
    }
}
