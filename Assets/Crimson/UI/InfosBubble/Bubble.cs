using Crimson.Portfolio;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Crimson.UI
{
    public class Bubble : MonoBehaviour
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("TMP use for the dialogue bubble")]
        [SerializeField]
        private TextMeshProUGUI bubbleText = null;

        [Tooltip("GameObject parent which containt bubble text and the image of the bubble")]
        [SerializeField]
        private GameObject bubble = null;

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods

        /// <summary>
        /// Update the view of the bubble
        /// </summary>
        /// <param name="model"></param>
        public void UpdateBubble(PortfolioModel model)
        {
            if (model == null || bubbleText == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                bubble.SetActive(false);
            }

            bubbleText.text = model.Description;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
