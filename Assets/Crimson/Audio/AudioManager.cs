using Crimson.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum EAudio
{
    None,
    Effect,
    Music,
    UI,
    Ambiance
}

namespace Crimson.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("Audio Mixer of the project")]
        [SerializeField]
        private AudioMixer mixer = null;

        /// <summary>
        /// Dictionary of auddio source
        /// </summary>
        private Dictionary<EAudio, List<AudioSourceContainer>> audioSourceContainerDictionary = new Dictionary<EAudio, List<AudioSourceContainer>>();

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods

        /// <summary>
        /// Add an audio source in a audioSourceDictionary
        /// </summary>
        /// <param name="audioSource"></param>
        public void AddAudioSource(AudioSourceContainer container)
        {
            if (!audioSourceContainerDictionary.ContainsKey(container.Type))
            {
                audioSourceContainerDictionary[container.Type] = new List<AudioSourceContainer>();
            }
 
            audioSourceContainerDictionary[container.Type].Add(container);
        }

        /// <summary>
        /// Init the different container volume of audio source regardless the AudioMixer setup
        /// </summary>
        public void InitVolume(AudioSourceContainer container)
        {
            if (mixer == null)
            {
                return;
            }

            if (mixer.GetFloat(container.Type.ToString(), out float dbValue))
            {
                dbValue = DbToLinear(dbValue);
                container.Source.volume = dbValue;
            }
        }

        /// <summary>
        /// Play an AudioClip on a source base on it's type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="clip"></param>
        public void Play(EAudio type, AudioClip clip, bool loop = false)
        {
            if (!audioSourceContainerDictionary.TryGetValue(type, out List<AudioSourceContainer> containers))
            {
                return;
            }

            AudioSourceContainer container = null;

            if (type == EAudio.Effect)
            {
                container = containers.Find(x => !x.Source.isPlaying);

                if (container == null)
                {
                    GameObject go = new GameObject("Temp Audio Source Container");
                    AudioSource source = go.AddComponent<AudioSource>();
                    AudioSourceContainer tempContainer = go.AddComponent<AudioSourceContainer>();
                    tempContainer.Source = source;
                    go.transform.parent = transform;
                    containers.Add(tempContainer);
                }

                container.Source.PlayOneShot(clip, GetVolume(type));
            }
            else
            {
                container = containers[0];
                container.Source.clip = clip;
                container.Source.loop = loop;
                
                if (container.Source.volume != GetVolume(type))
                {
                    container.Source.volume = GetVolume(type);
                }

                container.Source.Play();
            }
        }

        /// <summary>
        /// Stop the sound of the source base on it's type
        /// </summary>
        /// <param name="type"></param>
        public void Stop(EAudio type)
        {
            if( type == EAudio.None || type == EAudio.Effect)
            {
                return;
            }

            if (!audioSourceContainerDictionary.TryGetValue(type, out List<AudioSourceContainer> containers))
            {
                return;
            }

            AudioSourceContainer container = containers[0];
            container.Source.Stop();
        }

        /// <summary>
        /// Set the volume of a sound setting in mixer
        /// </summary>
        /// <param name="type"></param>
        /// <param name="volume"></param>
        public void SetVolume(EAudio type, float volume, bool linear = false)
        {
            if (mixer == null)
            {
                return;
            }

            if (linear)
            {
                volume = LinearToDb(volume);
            }

            mixer.SetFloat(type.ToString(), volume);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Return the value of a sound setting base on mixer
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private float GetVolume(EAudio type)
        {
            if (mixer == null)
            {
                return 1f;
            }

            if (!mixer.GetFloat(type.ToString(), out float dbValue))
            {
                return 1f;
            }

            return DbToLinear(dbValue);
        }

        /// <summary>
        /// Return the value Linear in decibel
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float LinearToDb(float value)
        {
            return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        }

        /// <summary>
        /// Return the value decibel in linear
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float DbToLinear(float value)
        {
            return Mathf.Pow(10f, value / 20f);
        }

        #endregion
    }
}