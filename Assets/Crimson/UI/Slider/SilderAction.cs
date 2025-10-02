using UnityEngine;

namespace Crimson.UI
{
    [CreateAssetMenu(fileName = "SliderAction", menuName = "Crimson/UI/Slider")]
    public abstract class BaseSilder : ScriptableObject
    {
        public virtual void Execute(float sliderValue) { }
    }
}