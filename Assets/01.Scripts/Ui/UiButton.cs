using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiButton : UiBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject touch;

    public override void Init()
    {
        touch = this.TryFindChild(StringMap.Touch);
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        touch.SetActive(true);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if(touch.activeSelf) touch.SetActive(false);
    }
}
