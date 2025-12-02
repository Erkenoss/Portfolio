using UnityEngine;
using Crimson.UI.But;

namespace Crimson.UI.Pagination
{
    [CreateAssetMenu(fileName = "Next/Prev Button", menuName = "Crimson/UI/Page/Prev_Next Button")]
    public class PrevNext : BaseButton
    {
        [Tooltip("Is this button the prev button?")]
        [SerializeField]
        protected bool isPrev = false;

        public override void Execute()
        {
            if (UIManager<PageModel>.Instance != null)
            {
                if (isPrev)
                {
                    UIManager<PageModel>.Instance.Prev();

                }
                else
                {
                    UIManager<PageModel>.Instance.Next();
                }
            }
        }
    }
}
