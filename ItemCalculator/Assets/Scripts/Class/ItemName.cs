using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemCalculator
{
    /// <summary>
    /// Management item name.
    /// </summary>
    public class ItemName : MonoBehaviour
    {
        public string Name
        {
            get
            {
                return GetComponent<InputField>().text;
            }
            set
            {
                GetComponent<InputField>().text = value;
            }
        }
    }
}