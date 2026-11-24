using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPunch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 origin;
    private Tween tween;

    private void Awake()
    {
        tween?.Kill();
        origin = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = origin;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tween?.Kill();
        tween = transform.DOScale(origin * 1.05f, 0.15f).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tween?.Kill();
        tween = transform.DOScale(origin, 0.15f).SetEase(Ease.OutBack);
    }
}
