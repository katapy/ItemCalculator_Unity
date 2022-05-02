using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemCalculator
{
    /// <summary>
    /// Calculator item.
    /// </summary>
    public class Item
    {
        public Item()
        {
            this.Operators = ItemOperator.Operators.plus;
            this.ItemName = "";
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
        /// Unit.
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
    }
}