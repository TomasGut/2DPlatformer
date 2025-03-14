using Platformer.Managers;
using UnityEngine;

namespace Platformer.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Transform player;
        private Vector3 playerPos;
        private Vector3 velocity;

        private void Start()
        {
            this.player = GameManager.instance.player.transform;
        }

        private void LateUpdate()
        {
            this.playerPos = this.player.position;
            this.playerPos.z = this.transform.position.z;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, this.playerPos, ref this.velocity, this.speed * Time.deltaTime);
        }
    }
}