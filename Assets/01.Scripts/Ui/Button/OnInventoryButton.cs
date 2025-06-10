using UnityEngine.EventSystems;

public class OnInventoryButton : UiButton
{
    private void Start()
    {
        UiManager.Instance.Add<OnInventoryButton>(this);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        touch.SetActive(false);
        this.gameObject.SetActive(false);

        UiManager.Instance.Show<InventoryUi>(true);
    }
}
