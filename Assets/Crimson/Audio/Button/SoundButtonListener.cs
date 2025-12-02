using Crimson.UI.But;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Crimson.Audio
{
    public class SoundButtonListener : ButtonListener
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("Action to play a sound")]
        [SerializeField]
        private PlayClip playClip = null;

        [Tooltip("Sound play by the button when onClick")]
        [SerializeField]
        private AudioClip clip = null;

        [Tooltip("Audio Type of this button, in general Effect or UI")]
        [SerializeField]
        private EAudio type = EAudio.None;

        /// <summary>
        /// Action to set sound on the onClick listener
        /// </summary>
        private UnityAction sound = null;

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Start()
        {
            base.Start();

            if (playClip != null && clip != null)
            {
                sound = () => playClip.Execute(type, clip);
                button.onClick.AddListener(sound);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (playClip != null && clip != null)
            {
                button.onClick.RemoveListener(sound);
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}