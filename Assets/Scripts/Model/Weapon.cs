using System.Collections.Generic;
using UnityEngine;

namespace ShooterSunFlower3D
{
    public abstract class Weapon : BaseObjectScene
    {
        [SerializeField] private int _maxCountAmmunition = 40;
        private int _countClip = 5;
        public Ammunition Ammunition;
        public Clip Clip;

        public AmmunitionType[] AmmunitionTypes = { AmmunitionType.SunBullet };

        [SerializeField] public Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechergeTime = 0.2f;
        private Queue<Clip> _clips = new Queue<Clip>();

        protected bool _isReady = true;
        protected ITimeRemaining _timeRemaining;

        public int CountClip => _clips.Count;

        private void Start()
        {
            _timeRemaining = new TimeRemaining(ReadyShoot, _rechergeTime);
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = _maxCountAmmunition});
            }

            ReloadClip();
            _timeRemaining.AddTimeRemaining();
        }

        public abstract void Fire();

        protected void ReadyShoot()
        {
            _isReady = true;
        }

        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }
    }
}