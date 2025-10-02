using UnityEngine;
using Crimson.Language;

namespace Crimson.UI.But
{
    [CreateAssetMenu(fileName = "ButtonLangauges", menuName = "UI/Button/Languages")]
    public class LanguageButton : BaseButton
    {
        [Tooltip("languages Defined by this button")]
        [SerializeField]
        private Languages lang = Languages.None;

        public override void Execute()
        {
            if (LanguageManager.Instance != null)
            {
                LanguageManager.Instance.SetLanguages(lang);
            }
        }
    }
}