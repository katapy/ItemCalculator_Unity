using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemCalculator
{
    /// <summary>
    /// Calculator item.
    /// </summary>
    [Serializable]
    public class Item
    {
        public Item()
        {
            this.Operators = ItemOperator.Operators.plus;
            this.ItemName = "";
            this.Number = null;
            this.Unit = "";
        }

        /// <summary>
        /// Operator.
        /// </summary>
        public ItemOperator.Operators Operators
        {
            get;
            set;
        }

        /// <summary>
        /// Item name.
        /// </summary>
        public string ItemName
        {
            get;
            set;
        }

        /// <summary>
        /// Number.
        /// </summary>
        public float? Number
        {
            get;
            set;
        }

        /// <summary>
        /// Unit.
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
    }
}