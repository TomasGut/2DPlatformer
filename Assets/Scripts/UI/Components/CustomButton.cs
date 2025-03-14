using Platformer.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class CustomButton : Button
    {
        protected override void Start()
        {
            base.onClick.AddListener(() => GameManager.instance.soundManager.PlaySound(Sound.Click));
        }
    }
}