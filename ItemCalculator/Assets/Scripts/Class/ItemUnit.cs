using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemCalculator
{
    /// <summary>
    /// Managemant item unit.
    /// </summary>
    public class ItemUnit : MonoBehaviour
    {
        /// <summary>
        /// Item unit.
        /// </summary>
        public string Unit
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
