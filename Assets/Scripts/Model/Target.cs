using System;
using UnityEngine;

namespace ShooterSunFlower3D
{
    public sealed class Target : MonoBehaviour, ICollision, ISelectObj
    {
        public event Action OnPointChange = delegate { };

        public float Hp = 100;
        private float _maxHp;
        private bool _isDead;
        private float _timeToDestroy = 5.0f;
        //todo дописать поглащение урона

        private void Awake()
        {
            _maxHp = Hp;
        }

        public void CollisionEnter(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, _timeToDestroy);

                OnPointChange.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }

        public float GetHp()
        {
            var procentHp = Hp / _maxHp;
            return procentHp;
        }
    }
}