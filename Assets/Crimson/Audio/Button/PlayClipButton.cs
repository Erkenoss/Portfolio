using UnityEngine;

namespace Crimson.Audio
{
    [CreateAssetMenu(fileName = "Play Clip Button", menuName = "Crimson/Audio/Play Clip Button")]
    public class PlayClipButton : PlayClip
    {
        public override void Execute(EAudio type, AudioClip clip)
        {
            base.Execute(type, clip);
        }
    }
}