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
        #endregion

        #region Private Methods
        #endregion
    }
}