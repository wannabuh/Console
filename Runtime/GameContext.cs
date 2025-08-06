using UnityEngine;

namespace Wannabuh.Console
{
    public class GameContext : MonoBehaviour
    {
        public static GameContext Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Instance = this;
            }
        }
    }
}
