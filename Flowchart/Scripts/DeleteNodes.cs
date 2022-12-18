using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteNodes : MonoBehaviour, IEndDragHandler
{
    private GameObject deleteZone;

    private void Start()
    {
        deleteZone = GameObject.Find("Delete zone");
    }

    //Удаляет узел после расположения его дальше определенной точки
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.localPosition.x < -880)
            Destroy(transform.parent.gameObject);
    }
}
