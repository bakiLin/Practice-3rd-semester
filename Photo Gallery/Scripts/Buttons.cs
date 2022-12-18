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

    //Отключает стрелки и изображение
    public void DirectoryEnter()
    {
        mainWindow.SetActive(false);
        directory.SetActive(true);
    }

    //Включает стрелки и изображение
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

    //Копирует изображение из выбранной папки
    public void AddImage()
    {
        listIsChanged = true;

        string sourcePath = EditorUtility.OpenFilePanel("Add File", "", "png");
        FileInfo info = new FileInfo(sourcePath);
        string destPath = "C:/Users/ilnur/OneDrive/Документы/project images/" + info.Name;
        FileUtil.CopyFileOrDirectory(sourcePath, destPath);

        imageManager.InstTextField();
    }

    //Вызывает функцию для удаления изображения
    public void DeleteButton()
    {
        listIsChanged = true;
        imageManager.DeleteImage();
    }
}
