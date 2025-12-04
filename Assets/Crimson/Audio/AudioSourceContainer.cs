using System.Collections;
using UnityEngine;

namespace Crimson.Audio
{
    public class AudioSourceContainer : MonoBehaviour
    {
        #region Public Fields

        public EAudio Type { get { return type; } }
        public AudioSource Source {  get { return source; } set { source = value; } }
        public float Volume { get { return  volume; } set { volume = value; } }

        #endregion

            #region Private Fields

        [Tooltip("Type of the audio source")]
        [SerializeField]
        private EAudio type = EAudio.None;

        [Tooltip("Source we want to add in the manager base on it's type")]
        [SerializeField]
        private AudioSource source = null;

        [Tooltip("Volume of this audio source")]
        [SerializeField]
        [Range(-80f, 20f)]
        private float volume = 0.0f;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (AudioManager.Instance != null)
            {
                Register();
            }
            else
            {
                StartCoroutine(WaitForManager());
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        /// <summary>
        /// Wait the initialization fo the AudioManager script
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForManager()
        {
            while (AudioManager.Instance == null)
            {
                yield return null;
            }

            Register();
        }

        /// <summary>
        /// Register the container in the manager
        /// </summary>
        private void Register()
        {
            AudioManager.Instance.AddAudioSource(this);
            AudioManager.Instance.InitVolume(this);
        }

        #endregion
    }
}