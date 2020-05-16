using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


namespace ShooterSunFlower3D
{
    public sealed class InputController : BaseController, IExecute
    {
        #region Fields
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private int _mouseButton = (int) MouseButton.LeftButton;

        #endregion

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        #region Methods
        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch(ServiceLocator.Resolve<Inventory>().FlashLight);
            }
            //ServiceLocator.Resolve<Inventory>().FlashLight
            //todo реализовать выбор оружия по колесику мыши
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
                UiInterface.SelectionWeaponUI.Color = Color.white;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1);
                //UiInterface.SelectionWeaponUI.Color = Color.white;
            }
            
            if (Input.GetMouseButton(_mouseButton))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().Fire();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<FlashLightController>().Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().ReloadClip();
                }
            }


            /// <summary>
            /// Выбор оружия
            /// </summary>
            /// <param name="i">Номер оружия</param>
            void SelectWeapon(int i)
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
                if (tempWeapon != null)
                {
                    ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
                }
            }
        }
        #endregion
    }
}