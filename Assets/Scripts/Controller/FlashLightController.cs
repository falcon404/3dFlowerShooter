using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ShooterSunFlower3D
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        #region Fields
        private FlashLightModel _flashLightModel;
        private FlashLightUi _flashLightUi;
        #endregion

        #region Methods
        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
            _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
            UiInterface.FlashLightUi.SetActive(false);
        }

        public override void On(params BaseObjectScene[] flashLight)
        {
            if (IsActive) return;
            if (flashLight.Length > 0) _flashLightModel = flashLight[0] as FlashLightModel;
            if (_flashLightModel == null) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On(_flashLightModel);
            _flashLightModel.Switch(FlashLightActiveType.On);
            UiInterface.FlashLightUi.SetActive(true);
            UiInterface.FlashLightUi.SetColor(Color.green);
            _flashLightUi.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
        }

        public void Execute()
        {
            if (!IsActive)
            {
                _flashLightModel.ChargeFlashLight();
                _flashLightUi.Text = _flashLightModel.BatteryChargeCurrent;
                return;
            }
            
            _flashLightModel.Rotation();
            if (_flashLightModel.EditBatteryCharge())
            {
                _flashLightUi.Text = _flashLightModel.BatteryChargeCurrent;
            }
            else
            {
                Off();
            }

            
            switch (_flashLightModel.BatteryStatus())
            {
                case BatteryStatus.High:
                    UiInterface.FlashLightUi.SetColor(Color.green);
                    break;
                case BatteryStatus.Medium:
                    UiInterface.FlashLightUi.SetColor(Color.yellow);
                    break;
                case BatteryStatus.Low:
                    UiInterface.FlashLightUi.SetColor(Color.red);
                    break;
                default:
                    UiInterface.FlashLightUi.SetColor(Color.white);
                    break;
            }
        }
        #endregion
    }
}