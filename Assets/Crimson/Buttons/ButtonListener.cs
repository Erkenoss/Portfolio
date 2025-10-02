using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Crimson.UI.But
{
    public class ButtonListener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("The button on thiss script")]
        [SerializeField]
        private Button button = null;

        [Tooltip("The action use by this button")]
        [SerializeField]
        private BaseButton action = null;

        [Tooltip("panel we want to use")]
        [SerializeField]
        private GameObject panel = null;

        [Tooltip("The color set on the text when we hover the button")]
        [SerializeField]
        private Color hoverTextColor = Color.white;

        [Tooltip("Basic color of the text")]
        [SerializeField]
        private Color baseColor = Color.white;

        [Tooltip("Text fo the button")]
        [SerializeField]
        private TextMeshProUGUI buttonText = null;
        
        /// <summary>
        /// use when we use panel 
        /// </summary>
        private UnityAction panelChanges = null;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (button == null || action == null)
            {
                return;
            }

            if (panel != null)
            {
                panelChanges = () => action.Execute(panel);
                button.onClick.AddListener(panelChanges);
            }
            else
            {
                button.onClick.AddListener(action.Execute);
            }
        }

        private void OnDisable()
        {
            if (buttonText == null)
            {
                return;
            }

            buttonText.color = baseColor;
        }

        private void OnDestroy()
        {
            if (button == null || action == null)
            {
                return;
            }

            if (panel != null)
            {
                button.onClick.RemoveListener(panelChanges);
                panelChanges = null;
            }
            else
            {
                button.onClick.RemoveListener(action.Execute);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (buttonText == null)
            {
                return;
            }

            buttonText.color = hoverTextColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (buttonText == null)
            {
                return;
            }

            buttonText.color = baseColor;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}