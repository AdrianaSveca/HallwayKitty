
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text buttonText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = Color.white;
        buttonText.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = new Color32(0xD4, 0xD4, 0xD4, 0xFF);
        buttonText.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

