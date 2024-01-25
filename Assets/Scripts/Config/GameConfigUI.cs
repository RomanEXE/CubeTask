using TMPro;
using UnityEngine;

namespace Config
{
    public class GameConfigUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private ConfigValueType _changeableValueType;

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(ChangeConfig);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(ChangeConfig);
        }

        private void Start()
        {
            _inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
            _inputField.text = GameConfig.GetValue(_changeableValueType).ToString();
        }

        private void ChangeConfig(string value)
        {
            GameConfig.ChangeValue(_changeableValueType, int.Parse(_inputField.text));
        }
    }
}