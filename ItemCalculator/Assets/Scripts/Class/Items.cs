using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace ItemCalculator
{
    /// <summary>
    /// Items
    /// </summary>
    [Serializable]
    public class Items
    {
        public Items()
        {
            this.ItemList = new List<Item>();
            this.Title = "";
        }

        public Items(string itemListName)
        {
            this.Title = itemListName;
            string itemsJson = File.ReadAllText(GetFullPath());
            Items items = JsonConvert.DeserializeObject<Items>(itemsJson);
            this.ItemList = items.ItemList;
            this.Title = items.Title;
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

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            return Application.persistentDataPath + "/ItemCalculator/items/";
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