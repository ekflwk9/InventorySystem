using UnityEngine.EventSystems;

public class CloseInventoryButton : UiButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        touch.SetActive(false);

        UiManager.Instance.Show<InventoryUi>(false);
        UiManager.Instance.Show<OnInventoryButton>(true);
    }
}
