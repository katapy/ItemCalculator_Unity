using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ItemCalculator;
using SceneTool;

public class GameManager : MonoBehaviour, ILoadScene
{
    [SerializeField]
    private GameObject itemPanels;

    [SerializeField]
    private GameObject sampleItemPanel;

    [SerializeField]
    private GameObject resultItemPanel;

    [SerializeField]
    private InputField itemNameInputField;

    [SerializeField]
    private Button appendRowButton = null;

    [SerializeField]
    private Button resetButton = null;

    [SerializeField]
    private Button enterButton = null;

    [SerializeField]
    private Button saveButton = null;

    [SerializeField]
    private Button customButton = null;

    // Start is called before the first frame update
    void Start()
    {
        if (appendRowButton != null)
        {
            appendRowButton.onClick.AddListener(OnClickAppnedRowButton);
        }
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(Reset);
        }
        if (enterButton != null)
        {
            enterButton.onClick.AddListener(Calc);
        }
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(Save);
        }
        if (customButton != null)
        {
            customButton.GetComponent<LoadSceneButton>().SceneObj
                = new object[] { false };
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnClickAppnedRowButton()
    {
        AppendRow(itemPanels.transform.childCount - 1);
        AdjustPanelSize();
    }

    /// <summary>
    /// Append row.
    /// </summary>
    /// <param name="rowIndex"></param>
    private void AppendRow(int rowIndex)
    {
        var clone = Instantiate(sampleItemPanel, itemPanels.transform);
        clone.name = "ItemPanel";
        clone.SetActive(true);
        if (rowIndex == 0)
        {
            clone.GetComponentInChildren<Dropdown>().
                gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Adjust panel size.
    /// </summary>
    private void AdjustPanelSize()
    {
        itemPanels.GetComponent<RectTransform>().sizeDelta
            = new Vector2(0, 100 * (itemPanels.transform.childCount - 1));
        itemPanels.transform.localPosition
            = new Vector2(0, Screen.height / 2 - 50 * itemPanels.transform.childCount - 80);
        resultItemPanel.transform.SetAsLastSibling();
    }

    /// <summary>
    /// Reset item.
    /// </summary>
    private void Reset()
    {
        StartCoroutine(ResetItem());
    }

    /// <summary>
    /// Reset item.
    /// </summary>
    private IEnumerator ResetItem()
    {
        for (var i = 0; i < itemPanels.transform.childCount; i++)
        {
            if (itemPanels.transform.GetChild(i).name == "ItemPanel")
            {
                Destroy(itemPanels.transform.GetChild(i).gameObject);
            }
        }

        yield return null;

        for (var i = 0; i < 2; i++)
        {
            AppendRow(i);
        }
        AdjustPanelSize();

        // resetItemPanel.
        resultItemPanel.GetComponentInChildren<ItemNumber>().Number = null;
    }

    /// <summary>
    /// Calculation.
    /// </summary>
    private void Calc()
    {
        float result = 0.0f;
        int count = 0;
        for (var i = 0; i < itemPanels.transform.childCount; i++)
        {
            if (itemPanels.transform.GetChild(i).name != "ItemPanel")
            {
                continue;
            }
            if (itemPanels.transform.GetChild(i).
                    GetComponentInChildren<ItemNumber>().Number == null)
            {
                continue;
            }

            count++;

            float value = itemPanels.transform.GetChild(i).
                    GetComponentInChildren<ItemNumber>().Number.Value;

            if (count == 1)
            {
                result = value;
            }
            else
            {
                switch (itemPanels.transform.GetChild(i).
                    GetComponentInChildren<ItemOperator>().Operator)
                {
                    case ItemOperator.Operators.plus:
                        result += value;
                        break;
                    case ItemOperator.Operators.minus:
                        result -= value;
                        break;
                    case ItemOperator.Operators.multiplication:
                        result *= value;
                        break;

                }
            }
        }

        resultItemPanel.GetComponentInChildren<ItemNumber>().Number = result;
    }

    /// <summary>
    /// Save items info.
    /// </summary>
    private void Save()
    {
        try
        {
            int count = 0;
            Items items = new Items();
            items.Title = itemNameInputField.text;
            for (var i = 0; i < itemPanels.transform.childCount; i++)
            {
                if (itemPanels.transform.GetChild(i).name != "ItemPanel")
                {
                    continue;
                }

                count++;

                Item item = new Item();
                if (itemPanels.transform.GetChild(i).
                        GetComponentInChildren<ItemOperator>() != null)
                {
                    item.Operators = itemPanels.transform.GetChild(i).
                        GetComponentInChildren<ItemOperator>().Operator;
                }
                item.ItemName = itemPanels.transform.GetChild(i).
                        GetComponentInChildren<ItemName>().Name;
                item.Unit = itemPanels.transform.GetChild(i).
                        GetComponentInChildren<ItemUnit>().Unit;
                items.ItemList.Add(item);
            }
            items.Save();

            SceneManager.LoadScene("Agenda");
        }
        catch (System.ArgumentNullException e)
        {
            string message = $"{e.ParamName} is not input.";
            GetComponent<PopupMessage>().ShowPopup(message, PopupMessage.MessageType.error);
            Debug.LogError(e);
        }
        catch (System.Exception e)
        {
            string message = "unexpected error.";
            GetComponent<PopupMessage>().ShowPopup(message, PopupMessage.MessageType.error);
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    public void SceneLoaded(object[] obj)
    {
        try
        {
            bool isCustom = (bool)obj[0];
            Items items = null;
            if (isCustom)
            {
                items = new Items(obj?[1] as string);
            }
            StartCoroutine(SetInitial(items));
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// Set initial item panel.
    /// </summary>
    /// <param name="items"> Initial items. </param>
    /// <returns></returns>
    public IEnumerator SetInitial(Items items)
    {
        for (var i = 0; i < itemPanels.transform.childCount; i++)
        {
            if (itemPanels.transform.GetChild(i).name == "ItemPanel")
            {
                Destroy(itemPanels.transform.GetChild(i).gameObject);
            }
        }

        yield return null;
        int rowIndex = 0;
        if (items != null)
        {
            foreach (Item item in items.ItemList)
            {
                var clone = Instantiate(sampleItemPanel, itemPanels.transform);
                clone.name = "ItemPanel";
                clone.SetActive(true);
                if (rowIndex == 0)
                {
                    clone.GetComponentInChildren<Dropdown>().
                        gameObject.SetActive(false);
                }
                else
                {
                    clone.GetComponentInChildren<ItemOperator>().Operator
                        = item.Operators;
                }
                clone.GetComponentInChildren<ItemName>().Name = item.ItemName;
                clone.GetComponentInChildren<ItemUnit>().Unit
                        = item.Unit;

                rowIndex++;
            }
        }
        else
        {
            for (var i = 0; i < 2; i++)
            {
                AppendRow(i);
            }
        }

        AdjustPanelSize();
    }
}