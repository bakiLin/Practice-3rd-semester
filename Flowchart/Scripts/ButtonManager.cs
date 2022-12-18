using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameObject[] nodes;

    [SerializeField] GameObject node;
    [SerializeField] GameObject canvas;

    public void Move() => SetState(true);

    public void Type() => SetState(false);

    public void AddNode() => Instantiate(node, canvas.transform, false);

    //Отвечает за включение\выключение child объектов узла
    private void SetState(bool state)
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");

        if (nodes != null)
        {
            foreach (var node in nodes)
            {
                Transform bg = node.transform.Find("BG");
                bg.gameObject.SetActive(state);

                Transform edges = node.transform.Find("Edges");
                edges.gameObject.SetActive(state);

                Transform fontSize = node.transform.Find("Font Size");
                fontSize.gameObject.SetActive(!state);
            }
        }
    }
}
