using UnityEngine;
using UnityEngine.UI;

namespace ShooterSunFlower3D
{
    public sealed class TargetUiText : MonoBehaviour
    {
        private Target[] _targets;
        private Text _text;
        private int _countPoint;
        private void Awake()
        {
            _targets = FindObjectsOfType<Target>();
            _text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            foreach (var target in _targets)
            {
                target.OnPointChange += UpdatePoint;
            }
        }

        private void OnDisable()
        {
            foreach (var target in _targets)
            {
                target.OnPointChange -= UpdatePoint;
            }
        }

        private void UpdatePoint()
        {
            ++_countPoint;
            _text.text = $"{_countPoint}";

            //todo отписаться удалить и списка
        }
    }
}