using UnityEngine;
using Platformer.Characters;
using Platformer.Managers;

namespace Platformer.Collectibles
{
    public enum CollectibleType
    {
        Cherry = 10,
        Cans = 20
    }

    public class Collectible : MonoBehaviour
    {
        [SerializeField] private CollectibleType type;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().AddPoints((int)this.type);
                GameManager.instance.soundManager.PlaySound(Sound.Collectible);
                Destroy(this.gameObject);
            }
        }
    }
}