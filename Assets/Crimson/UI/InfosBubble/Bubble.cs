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

        [Tooltip("Canvas where the bubble is")]
        [SerializeField]
        private Canvas canva = null;

        [Tooltip("Rect transform of the bubble")]
        [SerializeField]
        private RectTransform bubbleRect = null;

        [Tooltip("OffSet we want to add on the mouse to avoid image cover the mouse")]
        [SerializeField]
        private Vector2 offSet = Vector2.zero;

        /// <summary>
        /// Use to check where is the mouse on the canva
        /// </summary>
        private Vector2 mousePosition = Vector2.zero;

        /// <summary>
        /// It's the position of the anchored of the moouse on the canva
        /// </summary>
        private Vector2 anchorPosition = Vector2.zero;

        #endregion

        #region MonoBehaviour Callbacks

        private void LateUpdate()
        {
            if (canva == null || bubbleRect == null)
            {
                return;
            }

            mousePosition = Mouse.current.position.ReadValue();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canva.transform as RectTransform,
                mousePosition,
                canva.renderMode == RenderMode.ScreenSpaceOverlay ? null : canva.worldCamera,
                out anchorPosition);

            anchorPosition += offSet;
            bubbleRect.anchoredPosition = anchorPosition;
        }

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

            if (!bubble.activeSelf)
            {
                bubble.SetActive(true);
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
