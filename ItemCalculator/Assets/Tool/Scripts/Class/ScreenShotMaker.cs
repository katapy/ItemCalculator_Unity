using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShotMaker : MonoBehaviour
{
    private const bool isDebeg =
#if DEBUG
    true;
#else
   false;
#endif

    // string path = "/Users/kataokaryou/projects/Unity/ItemCalculator_Unity/Docs/ScreenShots";
    // string path = Directory.GetParent(Directory.GetParent(Application.dataPath).FullName).FullName + "/Docs/ScreenShots";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebeg && Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            string path = GetScreenShotFilePath();
            Debug.Log(path);
            StartCoroutine(GetScreenShot(path));
        }
    }

    /// <summary>
    /// Get screen shot.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetScreenShot(string path)
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        File.WriteAllBytes(path, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);
    }

    /// <summary>
    /// Create unique filename(Debug only).
    /// </summary>
    /// <returns> Screen shot file name. </returns>
    private string GetScreenShotFilePath()
    {
        if (!isDebeg)
        {
            throw new System.Exception("This function cannot use release mode.");
        }

        int i = 1;
        string dirPath = Directory.GetParent(Directory.GetParent(Application.dataPath).FullName).FullName
                + "/Docs/ScreenShots/";
        string fileName = string.Empty;
        while (true)
        {
            fileName = string.Format("ScreenShot{0:D3}.png", i);

            if (!File.Exists(dirPath + fileName))
            {
                break;
            }
            i++;
        }

        return dirPath + fileName;
    }
}
