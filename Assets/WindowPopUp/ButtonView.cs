using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WindowPopUp
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;

        public void SetData(string text, UnityAction callback)
        {
            _buttonText.text = text;
            _button.onClick.AddListener(callback);
        }

        public void DisableView()
        {
            _button.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}