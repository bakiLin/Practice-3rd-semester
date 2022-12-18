using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleRectangle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Transform[] edge;

    private RectTransform rectTransform;
    private bool isMoving = false;
    private float width;
    private float height;
    private Vector2 center;

    public void OnBeginDrag(PointerEventData eventData) => isMoving = true;

    //Читает позицию курсора и двигает блок
    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        rectTransform.position = rayPoint;
    }

    public void OnEndDrag(PointerEventData eventData) => isMoving = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Двигает углы, если перетаскивается блок
    private void Update()
    {
        if (!isMoving)
            Scaling();
        else
        {
            edge[0].localPosition = rectTransform.anchoredPosition + new Vector2(-width / 2, height / 2);
            edge[1].localPosition = rectTransform.anchoredPosition + new Vector2(width / 2, height / 2);
            edge[2].localPosition = rectTransform.anchoredPosition + new Vector2(width / 2, -height / 2);
            edge[3].localPosition = rectTransform.anchoredPosition + new Vector2(-width / 2, -height / 2);
        }
    }

    //Подгоняет масштаб блока под положение углов
    private void Scaling()
    {
        width = Vector2.Distance(edge[0].localPosition, edge[1].localPosition);
        height = Vector2.Distance(edge[1].localPosition, edge[2].localPosition);

        float centerX = edge[0].localPosition.x + width / 2;
        float centerY = edge[2].localPosition.y + height / 2;

        center = new Vector2(centerX, centerY);

        rectTransform.sizeDelta = new Vector2(width, height);
        rectTransform.anchoredPosition = center;
    }

    //Возвращает масштаб и положение узла
    public Vector2[] GetScale()
    {
        Vector2 size = new Vector2(width, height);
        Vector2[] scaling = { size, rectTransform.anchoredPosition };

        return scaling;
    }
}
