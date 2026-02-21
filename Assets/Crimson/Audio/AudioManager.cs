using Crimson.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public enum EAudio
{
    None,
    Master,
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

        #region Events

        /// <summary>
        /// When the current music end, it's Invoke
        /// </summary>
        public event Action OnMusicNearEnd;

        #endregion

        #region Private Fields

        [Tooltip("Audio Mixer of the project")]
        [SerializeField]
        private AudioMixer mixer = null;

        [Tooltip("Container SO for all our music")]
        [SerializeField]
        private MusicClipContainer musicContainer = null;

        [Tooltip("How many time we want to fade the music before it's end?")]
        [SerializeField]
        private float timeFader = 0f;

        /// <summary>
        /// Dictionary of auddio source
        /// </summary>
        private Dictionary<EAudio, List<AudioSourceContainer>> audioSourceContainerDictionary = new Dictionary<EAudio, List<AudioSourceContainer>>();

        /// <summary>
        /// Which music is playing currently
        /// </summary>
        private AudioClip currentMusicClip = null;

        /// <summary>
        /// Current index to get the different music in the container list
        /// </summary>
        private int currentIndexMusic = -1;

        /// <summary>
        /// Use to set if we can play the music in the container
        /// </summary>
        private bool enableMusic = true;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            OnMusicNearEnd += GetNextMusic;
            StartCoroutine(WaitForContainer());
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            OnMusicNearEnd -= GetNextMusic;
        }

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

                if (container == null || clip == null)
                {
                    return;
                }

                container.Source.PlayOneShot(clip, GetVolume(type));
            }
            else
            {
                container = containers[0];
            
                if (container.Source.isPlaying)
                {
                    container.Source.Stop();
                }

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

            if (audioSourceContainerDictionary.TryGetValue(type, out List<AudioSourceContainer> source))
            {
                if (type == EAudio.Effect || source[0].Source == null)
                {
                    return;
                }
                
                if (source[0].Source.isPlaying)
                {
                    source[0].Source.volume = DbToLinear(volume);
                }
            }
        }

        /// <summary>
        /// Use to start music
        /// </summary>
        public void EnableMusic()
        {
            if (!enableMusic)
            {
                enableMusic = true;
            }

            GetNextMusic();
        }

        /// <summary>
        /// Use to disable music
        /// </summary>
        public void DisableMusic()
        {
            if (enableMusic)
            {
                enableMusic = false;
            }

            AudioSource currentMusicSource = GetMusicSource();

            if (currentMusicSource != null)
            {
                if (currentMusicSource.isPlaying)
                {
                    currentMusicSource.Stop();
                }

                currentMusicSource.clip = null;
            }
        }

        /// <summary>
        /// Return the music source
        /// </summary>
        /// <returns></returns>
        public AudioSource GetMusicSource()
        {
            if (audioSourceContainerDictionary.TryGetValue(EAudio.Music, out List<AudioSourceContainer> source))
            {
                return source[0].Source;
            }

            return null;
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

        /// <summary>
        /// Play a music
        /// </summary>
        private void GetNextMusic()
        {
            if (musicContainer == null || musicContainer.MusicList == null || musicContainer.MusicList.Count == 0 || !enableMusic)
            {
                return;
            }

            if (musicContainer.IsRandom)
            {
                int nextIndex = 0;
                do
                {
                    nextIndex = UnityEngine.Random.Range(0, musicContainer.MusicList.Count);
                }
                while (musicContainer.MusicList.Count > 1 && nextIndex == currentIndexMusic);

                currentIndexMusic = nextIndex;
            }
            else
            {
                currentIndexMusic++;

                if (currentIndexMusic >= musicContainer.MusicList.Count)
                {
                    currentIndexMusic = 0;
                }
            }

            currentMusicClip = musicContainer.MusicList[currentIndexMusic];
            Play(EAudio.Music, currentMusicClip, false);

            float triggerTime = Mathf.Max(currentMusicClip.length - Mathf.Abs(timeFader), 0f);
            CancelInvoke(nameof(OnMusicNearEnd));
            Invoke(nameof(TriggerMusicNearEnd), triggerTime);
        }

        /// <summary>
        /// Use to invoke OnMusicNearEnd
        /// </summary>
        private void TriggerMusicNearEnd()
        {
            OnMusicNearEnd?.Invoke();
        }

        /// <summary>
        /// Use to wait the different audio source in dictionnary
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForContainer()
        {
            while (!audioSourceContainerDictionary.ContainsKey(EAudio.Music))
            {
                yield return null;
            }

            GetNextMusic();
        }

        #endregion
    }
}