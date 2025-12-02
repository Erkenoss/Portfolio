using UnityEngine;

namespace Crimson.Audio
{
    [CreateAssetMenu(fileName = "Play Clip", menuName = "Crimson/Audio/Play Clip")]
    public abstract class PlayClip : ScriptableObject
    {
        /// <summary>
        /// Usefull for a button in general
        /// </summary>
        /// <param name="type"></param>
        /// <param name="clip"></param>
        public virtual void Execute(EAudio type, AudioClip clip)
        {
            if (AudioManager.Instance == null)
            {
                return;
            }

            AudioManager.Instance.Play(type, clip);
        }

        /// <summary>
        /// Usefull for a slider for example
        /// </summary>
        /// <param name="type"></param>
        /// <param name="clip"></param>
        /// <param name="value"></param>
        public virtual void Execute(EAudio type, AudioClip clip, float value)
        {

        }
    }
}