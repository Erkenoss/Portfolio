using UnityEngine;
using Crimson.Singleton;
using System.Collections.Generic;
using Crimson.Audio;

namespace Portfolio.MainMenu
{
    public class MenuManager : Singleton<MenuManager>
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("List of all pannel in the setting menu")]
        [SerializeField]
        private List<GameObject> settingPanels = new List<GameObject>();

        /// <summary>
        /// Current open panel
        /// </summary>
        private GameObject currentPanel = null;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (AudioManager.Instance != null)
            {
                AudioSource currentMusicSource = null;
                currentMusicSource = AudioManager.Instance.GetMusicSource();

                if (currentMusicSource == null)
                {
                    return;
                }

                if (currentMusicSource.isPlaying)
                {
                    currentMusicSource.Stop();
                }

                AudioManager.Instance.EnableMusic();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Enable and disable panel
        /// </summary>
        /// <param name="panel"></param>
        public void OpenPanel(GameObject panel)
        {
            if (panel == null)
            {
                return;
            }

            if (currentPanel == panel && currentPanel.activeSelf)
            {
                currentPanel.SetActive(false);
                return;
            }

            if (currentPanel != null)
            {
                currentPanel.SetActive(false);
            }

            currentPanel = panel;
            currentPanel.SetActive(true);
        }

        /// <summary>
        /// Use to open or close the different panel in the main setting panel
        /// </summary>
        /// <param name="settingPanel"></param>
        public void OpenCloseSettingPanel(GameObject settingPanel)
        {
            if (settingPanel == null || settingPanels == null || settingPanels.Count == 0)
            {
                return;
            }

            foreach (GameObject panel in settingPanels)
            {
                panel.SetActive(false);
            }

            settingPanel.SetActive(true);
        }

        #endregion

        #region Private Methods
        #endregion
    }
}