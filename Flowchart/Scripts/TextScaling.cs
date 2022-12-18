using UnityEngine;
using UnityEngine.UI;

public class TextScaling : MonoBehaviour
{
    [SerializeField] ScaleRectangle scaleRectangle;
    [SerializeField] Dropdown dropdown;

    private RectTransform text;
    private InputField inputField;

    void Start()
    {
        text = GetComponent<RectTransform>();
        inputField = GetComponent<InputField>();
    }

    //Масштабирует и двигает текстовое поле относительно блока
    void Update()
    {
        Vector2[] scaling = scaleRectangle.GetScale();

        text.sizeDelta = scaling[0];
        text.anchoredPosition = scaling[1];

        Vector2 dropdownPosition = new Vector2(text.anchoredPosition.x, text.anchoredPosition.y - scaling[0][1] / 2 - 30);
        dropdown.transform.localPosition = dropdownPosition;
    }

    //Масштабирует размер текста 
    public void SetFontScale()
    {
        if (dropdown.value == 0)
            inputField.textComponent.fontSize = 30;
        if (dropdown.value == 1)
            inputField.textComponent.fontSize = 40;
        if (dropdown.value == 2)
            inputField.textComponent.fontSize = 50;
    }
}
