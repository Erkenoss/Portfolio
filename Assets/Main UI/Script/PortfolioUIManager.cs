using Crimson.Audio;
using Crimson.UI.Pagination;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crimson.Portfolio
{
    public enum EPanel
    {
        None,
        Start,
        VR,
        AR,
        Game,
        Others
    }

    public enum VideoName
    {
        None,
        carrist_sound_fork_movement,
        vice_project_first_video,
        home_helper_door_drawer_bathroom,
        home_helper_shader_glass,
        home_helper_get_pill,
        home_helper_door_drawer_kitchen,
        psychotonomia_filter_by_name,
        guardian_creation,
        guardian_movement,
        All_VR_Videos
    }

    /// <summary>
    /// Structure to design every panel of the portfolio
    /// </summary>
    [Serializable]
    public struct SectorStruct
    {
        #region Public

        public EPanel Pan { get { return pan; } }
        public List<PortfolioModel> ModelList { get { return modelList; } }
        public GameObject Panel {  get { return panel; } }

        #endregion

        #region Private

        [Tooltip("EPanel to defined what panel is it")]
        [SerializeField]
        private EPanel pan;

        [Tooltip("List of all model to navigate in the panel")]
        [SerializeField]
        private List<PortfolioModel> modelList;

        [Tooltip("GameObject of the panel")]
        [SerializeField]
        private GameObject panel;
        
        #endregion
    }

    public class PortfolioUIManager: UIManager<PortfolioModel>
    {
        #region Public Fields

        public EPanel Panel {  get { return panel; } }

        #endregion

        #region Private Fields

        [Tooltip("Ref to the view of the panel")]
        [SerializeField]
        private PageView view = null;

        [Tooltip("Basic Alpha we want for the image we will use wwhen PageModel need to be apply")]
        [SerializeField]
        private float baseAlpha = 0f;

        [Tooltip("Alpha after modificiation")]
        [SerializeField]
        private float modifyAlpha = 0f;

        [Tooltip("Raw image use to display the video")]
        [SerializeField]
        private RawImage videoImage = null;

        [Tooltip("Structure to defined all component of every panels")]
        [SerializeField]
        private List<SectorStruct> sectorList = new List<SectorStruct>();

        /// <summary>
        /// Panel currently choose by the player
        /// </summary>
        private EPanel panel = EPanel.None;

        /// <summary>
        /// Panel currently open
        /// </summary>
        private GameObject currentPanel = null;

        /// <summary>
        /// Container of all differents view panel
        /// </summary>
        Dictionary<EPanel, SectorStruct> panelDictionary = new Dictionary<EPanel, SectorStruct>();

        /// <summary>
        /// Current clip of the page
        /// </summary>
        private AudioClip currentClip = null;

        /// <summary>
        /// Index to manage the navigation in the different panel
        /// </summary>
        private int subIndex = 0;

        #endregion

        #region Events
        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();

            Add();
        }

        private void Start()
        {
            if (view == null)
            {
                return;
            }
            
            ChangePanel();
            panel = EPanel.VR;

            if (containerList == null || containerList.Count == 0)
            {
                return;
            }

            AlphaModifier();

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.EnableMusic();
            }
        }

        #endregion

        #region Public Methods

        public override void Next()
        {
            if (view == null || containerList == null || containerList.Count == 0)
            {
                return;
            }

            base.Next();

            view.UpdateView(containerList[index]);
            panel = containerList[index].Panel;
        }

        public override void Prev()
        {
            if (view == null || containerList == null || containerList.Count == 0)
            {
                return;
            }

            base.Prev();
            
            view.UpdateView(containerList[index]);
            panel = containerList[index].Panel;
        }

        /// <summary>
        /// Use to return at the start panel
        /// </summary>
        public override void Back()
        {
            panel = EPanel.Start;
            ChangePanel();
            panel = EPanel.VR;
        }

        /// <summary>
        /// Use to notify the event OnChangedPanel regardless the panel
        /// </summary>
        /// <param name="pan"></param>
        public override void SetPanel()
        {
            ChangePanel();
        }

        /// <summary>
        /// Open break panel and close the current panel 
        /// </summary>
        /// <param name="pausePanel"></param>
        public override void OpenCloseBreakMenu(GameObject breakPanel)
        {
            if (currentPanel == null)
            {
                return;
            }

            currentPanel.SetActive(!currentPanel.activeSelf);
            breakPanel.SetActive(!breakPanel.activeSelf);

            if (view != null)
            {
                if (breakPanel.activeSelf)
                {
                    view.UpdateView(null);
                }
                else
                {
                    view.UpdateView(containerList[index]);
                }
            }
        }

        /// <summary>
        /// Change the view base on the panel
        /// </summary>
        /// <param name="next"></param>
        /// <param name="panel"></param>
        public override void SubPanelNavigation(bool prev, EPanel panel)
        {
            if (panelDictionary.TryGetValue(panel, out var sector))
            {
                if (prev)
                {
                    subIndex--;
                }
                else
                {
                    subIndex++;
                }

                List<PortfolioModel> list = sector.ModelList;

                if (subIndex < 0)
                {
                    subIndex = list.Count - 1;
                }
                if (subIndex >= list.Count)
                {
                    subIndex = 0;
                }

                if (view != null)
                {
                    view.UpdateView(list[subIndex]);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Use to add all panel in panelDictionary
        /// </summary>
        /// <param name="pan"></param>
        /// <param name="_panel"></param>
        private void Add()
        {
            if (sectorList == null || sectorList.Count == 0)
            {
                return;
            }

            foreach (SectorStruct sector in sectorList)
            {
                if (!panelDictionary.ContainsKey(sector.Pan))
                {
                    panelDictionary[sector.Pan] = sector;
                }
            }

            panel = sectorList[0].Pan;
            currentPanel = sectorList[0].Panel;
        }

        /// <summary>
        /// Change panel base on panel enum
        /// </summary>
        private void ChangePanel()
        {
            if (panelDictionary.TryGetValue(panel, out var nextSector))
            {
                if (currentPanel != null)
                {
                    currentPanel.SetActive(false);
                }

                nextSector.Panel.SetActive(true);
                currentPanel = nextSector.Panel;

                if (nextSector.ModelList != null && nextSector.ModelList.Count > 0)
                {
                    containerList = nextSector.ModelList;
                }

                index = 0;

                if (view == null || containerList == null || containerList.Count == 0)
                {
                    return;
                }

                view.UpdateView(containerList[index]);
                AlphaModifier();

                currentClip = containerList[index].Audio;
                subIndex = 0;
            }
        }

        /// <summary>
        /// Use to mmomdify the value of the alpha of the raw image
        /// </summary>
        private void AlphaModifier()
        {
            if (videoImage != null)
            {
                Color color = videoImage.color;

                if (panel == EPanel.Start)
                {
                    if (color.a == baseAlpha)
                    {
                        return;
                    }

                    color.a = baseAlpha / modifyAlpha;
                    videoImage.color = color;
                }
                else
                {
                    if (color.a == modifyAlpha)
                    {
                        return;
                    }

                    color.a = 1f;
                    videoImage.color = color;
                }
            }
        }

        #endregion
    }
}