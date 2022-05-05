using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveButton : MonoBehaviour
{
    [SerializeField]
    private bool isActive;

    [SerializeField]
    private GameObject go;

    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        go.SetActive(isActive);
        parent = go.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// On click button action.
    /// </summary>
    private void OnClick()
    {
        isActive = !isActive;
        go.SetActive(isActive);

        // If is active, parent change root for avoid to hide object.
        if (isActive)
        {
            go.transform.parent = transform.root;
        }
        else
        {
            go.transform.parent = parent;
        }
    }
}
