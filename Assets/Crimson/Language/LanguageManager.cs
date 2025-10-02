using Crimson.Singleton;
using I2.Loc;
using UnityEngine;

namespace Crimson.Language
{
    public enum Languages
    {
        None,
        French,
        English
    }

    public class LanguageManager : Singleton<LanguageManager>
    {

        #region Public Fields
        #endregion

        #region Private Fields

        /// <summary>
        /// Current language
        /// </summary>
        private Languages currentLang = Languages.None;

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods

        /// <summary>
        /// Apply language when load a scene
        /// </summary>
        public void OnSceneLoad()
        {
            SetLanguages(currentLang);
        }

        /// <summary>
        /// Change the current language by enum
        /// </summary>
        /// <param name="languages"></param>
        public void SetLanguages(Languages language)
        {
            if (language == Languages.None)
            {
                return;
            }

            if (currentLang != language)
            {
                currentLang = language;
            }

            LocalizationManager.CurrentLanguage = currentLang.ToString();
            LocalizationManager.LocalizeAll();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}