using UnityEngine;
using UnityEditor;
using System.IO;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject mainWindow;
    [SerializeField] GameObject directory;
    [SerializeField] ImageManager imageManager;
    [SerializeField] FileManager fileManager;

    private bool listIsChanged = false;

    //��������� ������� � �����������
    public void DirectoryEnter()
    {
        mainWindow.SetActive(false);
        directory.SetActive(true);
    }

    //�������� ������� � �����������
    public void DirectoryExit()
    {
        directory.SetActive(false);
        mainWindow.SetActive(true);

        if (listIsChanged)
        {
            fileManager.SetImageRow();
            listIsChanged = false;
        }
    }

    //�������� ����������� �� ��������� �����
    public void AddImage()
    {
        listIsChanged = true;

        string sourcePath = EditorUtility.OpenFilePanel("Add File", "", "png");
        FileInfo info = new FileInfo(sourcePath);
        string destPath = "C:/Users/ilnur/OneDrive/���������/project images/" + info.Name;
        FileUtil.CopyFileOrDirectory(sourcePath, destPath);

        imageManager.InstTextField();
    }

    //�������� ������� ��� �������� �����������
    public void DeleteButton()
    {
        listIsChanged = true;
        imageManager.DeleteImage();
    }
}
