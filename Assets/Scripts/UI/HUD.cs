using Platformer.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class HUD : View
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button menuButton;

        private void Start()
        {
            GameManager.instance.player.onPointsUpdated += UpdateScore;

            this.menuButton.onClick.AddListener(() => UIManager.instance.OpenView(ViewType.Menu));
        }

        private void UpdateScore(int score) => this.scoreText.text = $"Score: {score}";
    }
}