using Crimson.Portfolio;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Crimson.UI.Pagination
{
    public class PageView : MonoBehaviour
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("Reference of the Bubble script")]
        [SerializeField]
        private Bubble bubble = null;

        [Tooltip("Text to set the title of this page")]
        [SerializeField]
        private TextMeshProUGUI title = null;

        [Tooltip("Renderer where display images and gifs")]
        [SerializeField]
        private Image currentImg = null;

        [Tooltip("how many img by second for our gif")]
        [SerializeField]
        private float fps = 0f;

        [Tooltip("Video player of the canvas")]
        [SerializeField]
        private VideoPlayer vp = null;

        [Tooltip("image where the video will be display")]
        [SerializeField]
        private RawImage videoImg = null;

        [Tooltip("Texture on the video will be display")]
        [SerializeField]
        private RenderTexture videoRenderTexture = null;

        /// <summary>
        /// Coroutine to manage a gif in the panel
        /// </summary>
        private Coroutine gifCorout = null;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (vp == null || videoRenderTexture == null || videoImg == null)
            {
                return;
            }

            vp.targetTexture = videoRenderTexture;
            videoImg.texture = videoRenderTexture;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Update the view of the panel
        /// </summary>
        /// <param name="page"></param>
        public void UpdateView(PortfolioModel page)
        {
            if (page == null || title == null)
            {
                return;
            }

            if (bubble != null)
            {
                bubble.UpdateBubble(page);
            }

            if (gifCorout != null)
            {
                StopCoroutine(gifCorout);
                gifCorout = null;
            }

            if (vp != null && vp.isPlaying)
            {
                vp.Stop();
                vp.clip = null;

                if (!page.IsVideo || page.Clip == null)
                {
                    videoImg.gameObject.SetActive(false);
                }
            }

            if (page.Key != null)
            {
                title.text = page.Key;
            }

            if (page.IsGif && page.GifSprites != null && page.GifSprites.Length > 0 && currentImg != null)
            {
                gifCorout = StartCoroutine(GifCoroutine(page.GifSprites));
            }
            else if (page.IsVideo && vp != null)
            {
                vp.audioOutputMode = VideoAudioOutputMode.Direct;
                
                if (currentImg != null)
                {
                    currentImg.gameObject.SetActive(false);
                }

                videoImg.gameObject.SetActive(true);

                if (page.Clip != null)
                {
                    vp.clip = page.Clip;
                    vp.isLooping = true;
                    vp.Play();
                }
                else
                {
                    videoImg.gameObject.SetActive(false);
                }
            }
            else
            {
                if (currentImg != null && page.Img != null)
                {
                    currentImg.sprite = page.Img;
                    currentImg.gameObject.SetActive(true);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Corouotine to manage the different gif in presentation
        /// </summary>
        /// <returns></returns>
        private IEnumerator GifCoroutine(Sprite[] sprites)
        {
            int index = 0;

            while (true)
            {
                currentImg.sprite = sprites[index];
                index = (index + 1) % sprites.Length;
                yield return new WaitForSeconds(1f / fps);
            }
        }

        #endregion
    }
}
