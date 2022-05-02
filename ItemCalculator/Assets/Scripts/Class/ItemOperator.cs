using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemCalculator
{
    /// <summary>
    /// Management item operator
    /// </summary>
    public class ItemOperator : MonoBehaviour
    {
        public enum Operators
        {
            plus,
            minus,
            multiplication
        }

        public Operators Operator
        {
            get
            {
                switch (GetComponent<Dropdown>().value)
                {
                    case 0:
                        return Operators.plus;
                    case 1:
                        return Operators.minus;
                    case 2:
                        return Operators.multiplication;
                    default:
                        throw new System.Exception();
                }
            }
            set
            {
                GetComponent<Dropdown>().value = (int)value;
            }
        }
    }
}