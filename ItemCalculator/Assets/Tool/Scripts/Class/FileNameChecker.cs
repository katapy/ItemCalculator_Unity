using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

namespace UnityFileName
{
    /// <summary>
    /// Check file name is correct.
    /// </summary>
    public static class FileNameChecker
    {
        private const string invalidFileNameWord =
            "[\\x00-\\x1f<>:\"/\\\\|?*]" +
            "|^(CON|PRN|AUX|NUL|COM[0-9]|LPT[0-9]|CLOCK\\$)(\\.|$)" +
            "|[\\. ]$";

        /// <summary>
        /// Check invalid word is included in filename.
        /// </summary>
        /// <param name="fileName"></param>
        public static void CheckInvalidFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new NullReferenceException(nameof(fileName));
            }
            if (IsContainIvalidWord(fileName, out string invalidWord))
            {
                throw new InvalidFileNameException(invalidWord);
            }
        }

        /// <summary>
        /// Judge Contain Ivalid Word
        /// </summary>
        /// <param name="fileName"> file name </param>
        /// <param name="invalidWord"> Invalid word. </param>
        /// <returns> return true if coutain invalid word. </returns>
        private static bool IsContainIvalidWord(string fileName, out string invalidWord)
        {
            invalidWord = string.Empty;
            Match matche = Regex.Match(fileName, invalidFileNameWord);
            if (matche.Success)
            {
                invalidWord = matche.Value;
                return true;
            }
            return false;
        }
    }
}