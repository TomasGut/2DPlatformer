using Platformer.Characters;
using UnityEngine;

namespace Platformer.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private Player playerPrefab;

        public SoundManager soundManager { get; private set; }
        public SceneLoadManager sceneManager { get; private set; }
        public Player player { get; private set; }

        private void Awake()
        {
            this.soundManager = GetComponent<SoundManager>();
            this.sceneManager = GetComponent<SceneLoadManager>();

            this.player = Instantiate(this.playerPrefab);
            this.player.SetActive(false);            
        }

        public void RespawnPlayer()
        {
            this.player.transform.position = Vector3.zero;
            this.player.SetActive(true);
            this.player.ResetPlayer();
        }
    }
}