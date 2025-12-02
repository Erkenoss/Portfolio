using UnityEngine;

namespace Crimson.UI.But
{
    public abstract class BaseButton : ScriptableObject
    {
        /// <summary>
        /// The method use when the button is pushed
        /// </summary>
        public virtual void Execute() { }

        public virtual void Execute(GameObject go) { }
    }
}