using UnityEngine;

namespace ShooterSunFlower3D
{
    public sealed class UiInterface
    {
        private FlashLightUi _flashLightUi;

        public FlashLightUi FlashLightUi
        {
            get
            {
                if (!_flashLightUi)
                    _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
                return _flashLightUi;
            }
        }

        private TargetUiHPbar _targetUiHPbar;

        public TargetUiHPbar TargetUiHPbar
        {
            get
            {
                if (!_targetUiHPbar)
                    _targetUiHPbar = Object.FindObjectOfType<TargetUiHPbar>();
                return _targetUiHPbar;
            }
        }

        private WeaponUiText _weaponUiText;

        public WeaponUiText WeaponUiText
        {
            get
            {
                if (!_weaponUiText)
                    _weaponUiText = Object.FindObjectOfType<WeaponUiText>();
                return _weaponUiText;
            }
        }

        private SelectionObjMessageUi _selectionObjMessageUi;

        public SelectionObjMessageUi SelectionObjMessageUi
        {
            get
            {
                if (!_selectionObjMessageUi)
                    _selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
                return _selectionObjMessageUi;
            }
        }

        private SelectionWeaponUI _selectionWeaponUI;

        public SelectionWeaponUI SelectionWeaponUI
        {
            get
            {
                if (!_selectionWeaponUI)
                    _selectionWeaponUI = Object.FindObjectOfType<SelectionWeaponUI>();
                return _selectionWeaponUI;
            }
        }
    }
}