using System;
using UnityEngine;


namespace ShooterSunFlower3D
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        #region Fields
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _chargeSpeed = 1;
        private Light _light;
        private Transform _goFollow;
        private Vector3 _vectorOffset;
        private float _batteryChargeMax = 100;
        public float BatteryChargeCurrent { get; private set; }
        #endregion

        #region Unity Methods
        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vectorOffset = Transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }
        #endregion

        #region Methods
        public void Switch(FlashLightActiveType value)
        {
            switch (value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    Transform.position = _goFollow.position + _vectorOffset;
                    Transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void ChargeFlashLight()
        {
            if (BatteryChargeCurrent <= _batteryChargeMax)
            {
                BatteryChargeCurrent += _chargeSpeed * Time.deltaTime;
            }
        }

        public void Rotation()
        {
            Transform.position = _goFollow.position + _vectorOffset;
            Transform.rotation = Quaternion.Lerp(Transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime;
                return true;
            }
            return false;
        }

        public BatteryStatus BatteryStatus()
        {
            BatteryStatus status = ShooterSunFlower3D.BatteryStatus.High;
            if (BatteryChargeCurrent >= 66) status = ShooterSunFlower3D.BatteryStatus.High;
            if (BatteryChargeCurrent < 66 && BatteryChargeCurrent > 33) status = ShooterSunFlower3D.BatteryStatus.Medium;
            if (BatteryChargeCurrent < 33 && BatteryChargeCurrent > 0) status = ShooterSunFlower3D.BatteryStatus.Low;

            return status;
        }
        #endregion
    }
}