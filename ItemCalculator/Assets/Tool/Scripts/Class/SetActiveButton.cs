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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        go.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        isActive = !isActive;
        go.SetActive(isActive);
    }
}
