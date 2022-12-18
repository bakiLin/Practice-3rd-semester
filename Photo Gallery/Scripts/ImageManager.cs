using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ImageManager : MonoBehaviour
{
    [SerializeField] GameObject textField;
    [SerializeField] GameObject content;
    [SerializeField] FileManager fileManager;

    private FileInfo[] info;

    void Start()
    {
        InstTextField();
    }

    //Вносит элементы в Scroll View
    public void InstTextField()
    {
        ClearTextField();
        info = fileManager.GetImages();

        Text txt = textField.GetComponentInChildren<Text>();

        for (int i = 0; i < info.Length; i++)
        {
            txt.text = info[i].Name;

            RawImage img = textField.GetComponentInChildren<RawImage>();
            WWW www = new WWW("file://" + info[i].FullName);
            img.texture = www.texture;

            Instantiate(textField, content.transform, false);
        }
    }

    //Удаляет все объекты внутри Scroll View 
    private void ClearTextField()
    {
        for (int i = 0; i < content.transform.childCount; i++)
            Destroy(content.transform.GetChild(i).gameObject);
    }

    //Удаляет объекты Scroll View, у которых включен переключатель
    public void DeleteImage()
    {
        for (int i = 0; i < info.Length; i++)
        {
            Transform field = content.transform.GetChild(i);
            Transform child = field.Find("Toggle");
            Toggle toggle = child.gameObject.GetComponent<Toggle>();

            if (toggle.isOn)
            {
                string path = info[i].FullName;
                FileUtil.DeleteFileOrDirectory(path);
            }
        }

        InstTextField();
    }
}
