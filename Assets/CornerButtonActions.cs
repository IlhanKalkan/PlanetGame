using UnityEngine;
using UnityEngine.EventSystems;

public class CornerButtonActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject panel;

    private bool clicked = false;

    public void OnClick()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(!panel.activeSelf);
        }
        clicked = !clicked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!clicked)
        {
            panel.SetActive(false);
        }
    }
}
