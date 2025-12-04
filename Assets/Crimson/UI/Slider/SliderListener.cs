using Crimson.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Crimson.UI
{
    public class SliderListener : MonoBehaviour
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("Slider of the script")]
        [SerializeField]
        private Slider slider = null;

        [Tooltip("The action use by the slider when the value is changed")]
        [SerializeField]
        private BaseSilder action = null;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (slider == null || action == null)
            {
                return;
            }

            slider.onValueChanged.AddListener(value => action.Execute(value));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the sound base on the slider value
        /// </summary>
        public void SetSound()
        {
            if (action == null)
            {
                return;
            }

            action.Execute(slider.value);
        }

        #endregion

        #region Private Methods
        #endregion
    }
}