using UnityEngine;
using UnityEngine.EventSystems;

public class MoveEdge : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform[] edge;

    //—читывает позицию курсора и двигает углы
    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        transform.position = rayPoint;

        if (transform.name == "Top Left")
            MoveNearbyEdge(3, 1);

        if (transform.name == "Top Right")
            MoveNearbyEdge(2, 0);

        if (transform.name == "Bottom Left")
            MoveNearbyEdge(0, 2);

        if (transform.name == "Bottom Right")
            MoveNearbyEdge(1, 3);
    }

    //ƒвигает соседние углы 
    private void MoveNearbyEdge(int horChange, int vertChange)
    {
        Vector2 p1 = new Vector2(transform.position.x, edge[horChange].position.y);
        edge[horChange].position = p1;

        Vector3 p2 = new Vector3(edge[vertChange].position.x, transform.position.y);
        edge[vertChange].position = p2;
    }
}
