using UnityEngine;

public abstract class BaseButton : ScriptableObject
{
    /// <summary>
    /// The method use when the button is pushed
    /// </summary>
    public virtual void Execute() { }
}
