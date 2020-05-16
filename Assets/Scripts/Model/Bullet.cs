using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ShooterSunFlower3D
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision) // todo своя обработка полета и получения урона
        {
            var setDamage = collision.gameObject.GetComponent<ICollision>();

            if (setDamage != null)
            {
                switch (Type)
                {
                    case AmmunitionType.None:
                        break;
                    case AmmunitionType.Pean:
                        setDamage.CollisionEnter(new InfoCollision(_curDamage, Rigidbody.velocity));
                        AddForce(Vector3.Reflect(Vector3.back, Transform.position));
                        break;
                    case AmmunitionType.SunBullet:
                        setDamage.CollisionEnter(new InfoCollision(_curDamage, Rigidbody.velocity));
                        DestroyAmmunition();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}