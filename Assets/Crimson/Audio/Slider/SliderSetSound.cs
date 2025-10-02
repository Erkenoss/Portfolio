using Crimson.UI;
using UnityEngine;

namespace Crimson.Audio
{
    [CreateAssetMenu(fileName = "Sound Slider", menuName = "Crimson/Audio/Sound Slider")]
    public class SliderSetSound : BaseSilder
    {
        [Tooltip("Sound type of the slider in the Audio Mixer")]
        [SerializeField]
        private EAudio type = EAudio.None;

        [Tooltip("true, if the slider send a value between 0 and 1 else false")]
        [SerializeField]
        private bool isLinearSlider = false;

        public override void Execute(float sliderValue)
        {
            if (AudioManager.Instance == null)
            {
                return;
            }

            AudioManager.Instance.SetVolume(type, sliderValue, isLinearSlider);
        }
    }
}