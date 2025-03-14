using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Managers
{
    public enum Sound
    {
        Collectible,
        Click
    }

    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        [Header("Sounds")]
        [SerializeField] private AudioClip collectibleSound;
        [SerializeField] private AudioClip clickSound;

        private void Start()
        {

        }

        public void PlaySound(Sound sound)
        {
            this.audioSource.clip = sound switch
            {
                Sound.Collectible => this.collectibleSound,
                Sound.Click => this.clickSound,
                _ => null,
            };

            this.audioSource.Play();
        }
    }
}