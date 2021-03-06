using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemCalculator
{
    /// <summary>
    /// Managemant item number.
    /// </summary>
    public class ItemNumber : MonoBehaviour
    {
        /// <summary>
        /// Number in item.
        /// </summary>
        public float? Number
        {
            get
            {
                if (float.TryParse(GetComponent<InputField>().text, out float f))
                {
                    return f;
                }
                return null;
            }
            set
            {
                GetComponent<InputField>().readOnly = false;
                GetComponent<InputField>().text = value.ToString();
                GetComponent<InputField>().readOnly = true;
            }
        }
    }
}
