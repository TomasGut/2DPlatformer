using Platformer.Collectibles;
using Platformer.Managers;
using System;
using UnityEngine;

namespace Platformer.Characters
{
    public partial class Player : MonoBehaviour
    {
        public Action<int> onPointsUpdated;

        public int points {  get; private set; }

        private GameManager gameManager;

        private void Awake()
        {
            this.gameManager = GameManager.instance;

            StartMovement();
        }

        private void Update()
        {
            UpdateMovement();
        }

        private void FixedUpdate()
        {
            FixedUpdateMovement();
        }

        public void ResetPlayer()
        {
            this.points = 0;
            this.onPointsUpdated?.Invoke(this.points);
        }

        public void AddPoints(int newPoints)
        {
            this.points += newPoints;
            this.onPointsUpdated?.Invoke(this.points);
        }

        public void SetActive(bool isActive)
        {
            this.rigidBody.simulated = isActive;
        }
    }
}