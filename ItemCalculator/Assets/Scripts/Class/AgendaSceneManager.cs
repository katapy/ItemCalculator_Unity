using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SceneTool;
using ItemCalculator;

public class AgendaSceneManager : MonoBehaviour
{
    [SerializeField]
    private Button defaultButton;

    [SerializeField]
    private GameObject customSampleButtonPanel;

    // Start is called before the first frame update
    void Start()
    {
        defaultButton.GetComponent<LoadSceneButton>().SceneObj
                    = new object[] { false };

        string[] files = Directory.GetFiles(
            Application.persistentDataPath + "/ItemCalculator/items/", "*");
        if (files.Length > 0)
        {
            foreach (var filePath in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                var clone = Instantiate(customSampleButtonPanel, customSampleButtonPanel.transform.parent);
                clone.name = fileName;
                clone.GetComponentInChildren<Text>().text = fileName;
                clone.GetComponentInChildren<LoadSceneButton>().SceneObj
                    = new object[] { true, fileName };
                clone.GetComponentInChildren<DeleteItem>().FilePath
                    = filePath;
                clone.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
