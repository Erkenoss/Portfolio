using System.Collections.Generic;
using UnityEngine;
using Crimson.Singleton;

namespace Portfolio.MainMenu
{
    public class MenuManager : Singleton<MenuManager>
    {
        #region Public Fields
        #endregion

        #region Private Fields

        /// <summary>
        /// Current open panel
        /// </summary>
        private GameObject currentPanel = null;

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
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

        #endregion

        #region Private Methods
        #endregion
    }
}