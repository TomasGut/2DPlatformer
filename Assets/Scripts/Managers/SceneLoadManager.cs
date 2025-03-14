using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Managers
{
    public class SceneLoadManager : MonoBehaviour
    {
        public Action onLoadingStarted;
        public Action onLoadingEnded;

        public bool sceneIsLoaded { get { return this.currentSceneNumber != 0; } }

        private int currentSceneNumber;

        public void LoadSceneAdditive(int levelNumber) => StartCoroutine(LoadScene(levelNumber));

        public void RestartCurrentLevel() => StartCoroutine(RestartLevel());

        private IEnumerator LoadScene(int levelNumber)
        {
            // Prohibit effecting main scene
            if (levelNumber == 0)
                yield break;

            this.onLoadingStarted?.Invoke();

            // Unload previous asynchronous scene
            AsyncOperation asyncOp;
            if  (this.currentSceneNumber != 0)
            {
                asyncOp = SceneManager.UnloadSceneAsync(this.currentSceneNumber);
                yield return new WaitUntil(() => asyncOp.isDone);
            }

            // Load new asynchronous scene
            asyncOp = SceneManager.LoadSceneAsync(levelNumber, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncOp.isDone);

            this.currentSceneNumber = levelNumber;
            GameManager.instance.RespawnPlayer();

            this.onLoadingEnded?.Invoke();
        }

        private IEnumerator RestartLevel()
        {
            // Prohibit effecting main scene
            if (this.currentSceneNumber == 0)
                yield break;

            this.onLoadingStarted?.Invoke();

            // Unload previous asynchronous scene
            AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(this.currentSceneNumber);
            yield return new WaitUntil(() => asyncOp.isDone);

            // Load new asynchronous scene
            asyncOp = SceneManager.LoadSceneAsync(this.currentSceneNumber, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncOp.isDone);

            GameManager.instance.RespawnPlayer();

            this.onLoadingEnded?.Invoke();
        }
    }
}