using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityFileName
{
    /// <summary>
    /// Invalid File Name Exception
    /// </summary>
    public class InvalidFileNameException : Exception
    {
        /// <summary>
        /// Invalid File Name Exception
        /// </summary>
        /// <param name="invalidFileNameWord">
        /// Invalid file name word.
        /// </param>
        public InvalidFileNameException(string invalidFileNameWord)
        {
            this.InvalidFileNameWord = invalidFileNameWord;
        }

        /// <summary>
        /// Invalid file name word.
        /// </summary>
        public string InvalidFileNameWord
        {
            get; private set;
        }

        /// <summary>
        /// Error message.
        /// </summary>
        public override string Message
        {
            get
            {
                return $"\"{InvalidFileNameWord}\" cannot use in filename";
            }
        }
    }
}