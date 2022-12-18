using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    [SerializeField] GameObject[] arrows;

    private RawImage image;
    private int imageCounter;
    private DirectoryInfo dir = new DirectoryInfo("C:/Users/ilnur/OneDrive/Документы/project images");
    private FileInfo[] info;

    private void Start()
    {
        image = GetComponent<RawImage>();

        SetImageRow();
    }

    //Возвращает переменную, отвечающую за номер изображения на сцене, к первому элементу и считывает все файлы из папки
    public void SetImageRow()
    {
        imageCounter = 0;
        info = dir.GetFiles("*.*");
        LoadImage();
    }

    //Понижает переменную imageCounter, которая отвечает за текущее изображение
    public void LeftArrow()
    {
        if (imageCounter != 0)
            imageCounter--;

        LoadImage();
    }

    //Повышает переменную imageCounter, которая отвечает за текущее изображение 
    public void RightArrow()
    {
        if (imageCounter != info.Length - 1)
            imageCounter++;

        LoadImage();
    }

    //Меняет текстуру RawImage на изображение из пути 
    private void LoadImage()
    {
        //Если в папке есть файлы, то происходит смена текстуры, если их нет, то отключаются стрелки и текстура равняется null
        if ((imageCounter >= 0) && (info.Length > 0))
        {
            string path = "file://" + info[imageCounter].FullName;
            WWW www = new WWW(path);
            image.texture = www.texture;

            IsEdgeImage();
        } else
        {
            arrows[0].SetActive(false);
            arrows[1].SetActive(false);

            image.texture = null;
        }  
    }

    //Регулировка отображения стрелок (кроме случая, когда в папке изображений нет) 
    private void IsEdgeImage()
    {
        if (imageCounter == 0)
            arrows[0].SetActive(false);
        else
            arrows[0].SetActive(true);

        if (imageCounter == info.Length - 1)
            arrows[1].SetActive(false);
        else
            arrows[1].SetActive(true);
    }

    //Возвращает переменную, содержащую файлы из пути dir 
    public FileInfo[] GetImages()
    {
        info = dir.GetFiles("*.*");
        return info;
    }
}
