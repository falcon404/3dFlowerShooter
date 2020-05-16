using UnityEngine;
using UnityEngine.UI;


namespace ShooterSunFlower3D
{
    public sealed class FlashLightUi : MonoBehaviour
    {
        #region Fields
        private Text _text;
        #endregion

        #region Properties
        public float Text
        {
            set => _text.text = $"{value:###}%";
        }

        public Color Color
        {
            set => _text.color = value;
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            _text = GetComponent<Text>();
        }
        #endregion

        #region Methods
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }

        public void SetColor(Color value)
        {
            _text.color = value;
        }
        #endregion
    }
}