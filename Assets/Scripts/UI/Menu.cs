using Platformer.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class Menu : View
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button levelButton;
        [SerializeField] private Button quitButton;

        [Header("Level select buttons")]
        [SerializeField] private Button increaseLvlButton;
        [SerializeField] private Button decreaseLvlButton;

        private int sceneIndex;

        private void Start()
        {
            this.continueButton.onClick.AddListener(() =>
            {
                UIManager.instance.CloseView(ViewType.Menu);
            });
            this.restartButton.onClick.AddListener(() =>
            {
                GameManager.instance.sceneManager.RestartCurrentLevel();
                UIManager.instance.CloseView(ViewType.Menu);
            });
            this.levelButton.onClick.AddListener(() =>
            {
                GameManager.instance.sceneManager.LoadSceneAdditive(this.sceneIndex + 1);
                UIManager.instance.CloseView(ViewType.Menu);
            });
            this.quitButton.onClick.AddListener(() => Application.Quit());

            this.increaseLvlButton.onClick.AddListener(() => UpdateLvlButton(true));
            this.decreaseLvlButton.onClick.AddListener(() => UpdateLvlButton(false));

            Open();
        }

        override public void Open()
        {
            this.continueButton.gameObject.SetActive(GameManager.instance.sceneManager.sceneIsLoaded);
            this.restartButton.gameObject.SetActive(GameManager.instance.sceneManager.sceneIsLoaded);
        }

        private void UpdateLvlButton(bool increase)
        {
            TextMeshProUGUI buttonText = this.levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            // Update lvl index value
            sceneIndex = LoopMod(increase ? sceneIndex + 1 : sceneIndex - 1, SceneManager.sceneCountInBuildSettings - 1);

            if (buttonText) // Update button text
                buttonText.text = $"Level: {sceneIndex + 1}";
        }

        private int LoopMod(int value, int mod) => (value + mod) % mod;
    }
}