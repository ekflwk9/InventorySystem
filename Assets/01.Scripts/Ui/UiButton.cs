using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject touch;

    protected virtual void Reset()
    {
        touch = this.TryGetChildComponent<GameObject>(StringMap.Touch);
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        touch.SetActive(true);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if(!touch.activeSelf) touch.SetActive(false);
    }
}
