using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ItemCalculator
{
    /// <summary>
    /// Delete item when click button.
    /// </summary>
    public class DeleteItem : MonoBehaviour
    {
        [SerializeField]
        private Button deleteButton;

        /// <summary>
        /// Delete file path.
        /// </summary>
        public string FilePath { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Awake()
        {
            deleteButton.onClick.AddListener(Delete);
        }

        /// <summary>
        /// Delete file and go to agenda scene.
        /// </summary>
        public void Delete()
        {
            File.Delete(FilePath);
            SceneManager.LoadScene("Agenda");
        }
    }
}