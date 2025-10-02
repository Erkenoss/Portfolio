using I2.Loc;
using UnityEngine;
using UnityEngine.Video;

namespace Crimson.UI.Pagination
{
    [CreateAssetMenu(fileName = "Model", menuName = "UI/Page/Model")]
    public class PageModel : ScriptableObject
    {
        #region Public Fields

        public bool IsGif { get {  return isGif; } }
        public bool IsVideo { get {  return isVideo; } }
        public LocalizedString Key { get { return key; } }
        public Sprite[] GifSprites { get { return gifSprites; } }
        public Sprite Img { get { return img; } }
        public VideoClip Clip { get { return clip; } }
        public AudioClip Audio { get { return audio; } }

        #endregion

            #region Private Fields

        [Tooltip("Is this model contains a gif?")]
        [SerializeField]
        private bool isGif = false;

        [Tooltip("Is this model contains a video?")]
        [SerializeField]
        private bool isVideo = false;

        [Tooltip("Use to defined the title of the rubric")]
        [SerializeField]
        private LocalizedString key = null;

        [Tooltip("Use to set a gif")]
        [SerializeField]
        private Sprite[] gifSprites = null;

        [Tooltip("Use to set an image")]
        [SerializeField]
        private Sprite img = null;

        [Tooltip("Video of the model is there is one")]
        [SerializeField]
        private VideoClip clip = null;

        [Tooltip("Audio of the panel")]
        [SerializeField]
        private AudioClip audio = null;

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}