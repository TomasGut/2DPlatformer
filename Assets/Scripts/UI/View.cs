using UnityEngine;

namespace Platformer.UI
{
    public enum ViewType
    {
        None,
        Menu,
        HUD,
        Loading
    }

    public class View : MonoBehaviour
    {
        [SerializeField] private ViewType view;

        public ViewType type { get { return this.view; } }

        public virtual void Open() { }

        public virtual void Close() { }
    }
}