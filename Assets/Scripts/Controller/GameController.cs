using UnityEngine;

namespace ShooterSunFlower3D
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields
        private Controllers _controllers;
        #endregion

        #region Unity Methods
        private void Start()
        {
            _controllers = new Controllers();
            _controllers.Initialization();
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }
        #endregion
    }
}

