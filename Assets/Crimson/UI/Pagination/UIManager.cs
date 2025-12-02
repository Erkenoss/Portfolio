using Crimson.Portfolio;
using Crimson.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Crimson.UI.Pagination
{

    public abstract class UIManager<TModel> : Singleton<UIManager<TModel>> where TModel : PageModel
    {
        #region Public Fields
        #endregion

        #region Private Fields

        [Tooltip("The list of the Page")]
        [SerializeField]
        protected List<TModel> containerList = new List<TModel>();

        [Tooltip("Is this panel has a loop")]
        [SerializeField]
        protected bool isLoop = false;

        /// <summary>
        /// Index to manage the different page in the list
        /// </summary>
        protected int index = 0;

        #endregion

        #region MonoBehaviour Callbacks
        #endregion

        #region Public Methods

        /// <summary>
        /// Pass to the next of the containerList
        /// </summary>
        public virtual void Next()
        {
            if (containerList == null || containerList.Count == 0)
            {
                return;
            }

            index++;

            if (index >= containerList.Count)
            {
                if (isLoop)
                {
                    index = 0;
                }
                else
                {
                    index = containerList.Count - 1;
                }
            }
        }

        /// <summary>
        /// Back to the prev of the containerList
        /// </summary>
        public virtual void Prev()
        {
            if (containerList == null || containerList.Count == 0)
            {
                return;
            }

            index--;

            if (index < 0)
            {
                if (isLoop)
                {
                    index = containerList.Count - 1;
                }
                else
                {
                    index = 0;
                }
            }
        }

        /// <summary>
        /// Clear the list
        /// </summary>
        public virtual void ClearContainer()
        {
            if (containerList != null && containerList.Count > 0)
            {
                containerList.Clear();
            }
        }

        /// <summary>
        /// Toogle isLoop boolean
        /// </summary>
        public virtual void ToogleLoop()
        {
            isLoop = !isLoop;
        }

        /// <summary>
        /// Use to set setting on a panel
        /// </summary>
        public virtual void SetPanel()
        {

        }

        /// <summary>
        /// use to back regardless different menu
        /// </summary>
        public virtual void Back()
        {

        }

        /// <summary>
        /// Open the break panel and close the current
        /// </summary>
        /// <param name="breakPanel"></param>
        public virtual void OpenCloseBreakMenu(GameObject breakPanel)
        {

        }

        public virtual void SubPanelNavigation(bool prev, EPanel panel)
        {

        }

        #endregion

        #region Private Methods
        #endregion
    }
}