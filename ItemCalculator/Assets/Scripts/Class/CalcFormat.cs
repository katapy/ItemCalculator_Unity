using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityFileName;

namespace ItemCalculator
{
    /// <summary>
    /// Calclation format.
    /// </summary>
    [Serializable]
    public class CalcFormat
    {
        public CalcFormat()
        {
            this.ItemList = new List<Item>();
            this.Title = "";
            this.Result = new Item();
        }

        public CalcFormat(string titleName)
        {
            this.Title = titleName;
            string formatJson = File.ReadAllText(GetFullPath());
            CalcFormat format = JsonConvert.DeserializeObject<CalcFormat>(formatJson);
            this.ItemList = format.ItemList;
            this.Title = format.Title;
            this.Result = format.Result;
        }

        /// <summary>
        /// Item name.
        /// </summary>
        [JsonProperty]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Item List
        /// </summary>
        [JsonProperty]
        public List<Item> ItemList
        {
            get;
        }

        public Item Result
        {
            get;
            set;
        }

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            return Application.persistentDataPath + "/ItemCalculator/CalcFormat/";
        }

        /// <summary>
        /// Get full path include file name.
        /// </summary>
        /// <returns></returns>
        private string GetFullPath()
        {
            if (string.IsNullOrEmpty(Title))
            {
                throw new ArgumentNullException(nameof(Title));
            }
            FileNameChecker.CheckInvalidFileName(Title);
            if (!Directory.Exists(GetPath()))
            {
                Directory.CreateDirectory(GetPath());
            }

            return GetPath() + Title + ".json";
        }

        /// <summary>
        /// Save this by json file.
        /// </summary>
        public void Save()
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            File.WriteAllText(GetFullPath(), JsonConvert.SerializeObject(this, settings));
        }
    }
}
