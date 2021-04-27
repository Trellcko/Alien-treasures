using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorGraphic.Instance.SetInteractTexture();
        Debug.Log("haha");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorGraphic.Instance.SetDefaultCursor();
    }
}
