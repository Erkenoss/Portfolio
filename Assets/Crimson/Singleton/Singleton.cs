using UnityEngine;

namespace Crimson.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Public Fields

        public static T Instance { get { return instance; } }

        #endregion

        #region Private Fields

        /// <summary>
        /// Instance for this script
        /// </summary>
        private static T instance = null;

        [Tooltip("Is this singleton persistant?")]
        [SerializeField]
        private bool isPersistent = false;

        #endregion

        #region MonoBehaviour Callbacks

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;

                if (isPersistent)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}