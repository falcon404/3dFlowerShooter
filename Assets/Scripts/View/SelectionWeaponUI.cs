using UnityEngine;
using UnityEngine.UI;

public sealed class SelectionWeaponUI : MonoBehaviour
{
    #region Fields
    private Text _text;
    #endregion
    
    #region Properties
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
    public void SetColor(Color value)
    {
        _text.color = value;
    }
    #endregion
}
