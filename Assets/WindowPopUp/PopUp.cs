using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WindowPopUp
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] private RectTransform _buttonContainer;
        [SerializeField] private TextMeshProUGUI _textHeader;
        [SerializeField] private TextMeshProUGUI _textDescription;
        [SerializeField] private ButtonView _buttonPrefab;

        private List<ButtonView> _buttonsInstance = new List<ButtonView>();

        public void SetHeader(string header)
        {
            _textHeader.text = header;
        }

        public void SetDescription(string description)
        {
            _textDescription.text = description;
        }

        public void Initialize(List<ButtonAction> buttonActions)
        {
            foreach (var buttonAction in buttonActions)
            {
                var buttonInstance = Instantiate(_buttonPrefab, _buttonContainer);
                buttonInstance.SetData(buttonAction.ButtonText, () => buttonAction.Callback?.Invoke());
                _buttonsInstance.Add(buttonInstance);
            }

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            foreach (var button in _buttonsInstance)
            {
                button.DisableView();
            }

            gameObject.SetActive(false);
        }
    }
}