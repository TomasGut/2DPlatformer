using Platformer.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<View> viewsList;

        private Dictionary<ViewType, View> views;

        private void Start()
        {
            this.views = new Dictionary<ViewType, View>();

            // Register all views
            for (int i = 0; i < this.viewsList.Count; i++)
                this.views.Add(this.viewsList[i].type, this.viewsList[i]);

            GameManager.instance.sceneManager.onLoadingStarted += OpenLoading;
            GameManager.instance.sceneManager.onLoadingEnded += CloseLoading;
        }

        public void OpenView(ViewType view)
        {
            this.views[view].gameObject.SetActive(true);
            this.views[view].Open();
        }

        public void CloseView(ViewType view)
        {
            this.views[view].gameObject.SetActive(false);
            this.views[view].Close();
        }

        private void OpenLoading() => OpenView(ViewType.Loading);

        private void CloseLoading() => CloseView(ViewType.Loading);
    }
}