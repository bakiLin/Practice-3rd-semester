using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    [SerializeField] GameObject[] arrows;

    private RawImage image;
    private int imageCounter;
    private DirectoryInfo dir = new DirectoryInfo("C:/Users/ilnur/OneDrive/���������/project images");
    private FileInfo[] info;

    private void Start()
    {
        image = GetComponent<RawImage>();

        SetImageRow();
    }

    //���������� ����������, ���������� �� ����� ����������� �� �����, � ������� �������� � ��������� ��� ����� �� �����
    public void SetImageRow()
    {
        imageCounter = 0;
        info = dir.GetFiles("*.*");
        LoadImage();
    }

    //�������� ���������� imageCounter, ������� �������� �� ������� �����������
    public void LeftArrow()
    {
        if (imageCounter != 0)
            imageCounter--;

        LoadImage();
    }

    //�������� ���������� imageCounter, ������� �������� �� ������� ����������� 
    public void RightArrow()
    {
        if (imageCounter != info.Length - 1)
            imageCounter++;

        LoadImage();
    }

    //������ �������� RawImage �� ����������� �� ���� 
    private void LoadImage()
    {
        //���� � ����� ���� �����, �� ���������� ����� ��������, ���� �� ���, �� ����������� ������� � �������� ��������� null
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

    //����������� ����������� ������� (����� ������, ����� � ����� ����������� ���) 
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

    //���������� ����������, ���������� ����� �� ���� dir 
    public FileInfo[] GetImages()
    {
        info = dir.GetFiles("*.*");
        return info;
    }
}
