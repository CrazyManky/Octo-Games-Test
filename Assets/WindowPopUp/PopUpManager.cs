using System;
using System.Collections.Generic;
using UnityEngine;

namespace WindowPopUp
{
    public class PopUpManager : MonoBehaviour
    {
        [SerializeField] private PopUp _defaultPrefab;

        private PopUp _activePopUp;

        private void Start()
        {
            var actions = new List<ButtonAction>()
            {
                new ButtonAction
                {
                    ButtonText = "Close",
                    Callback = () =>
                    {
                        if (_activePopUp != null)
                            _activePopUp.Hide();
                    },
                },
            };
            PopUpShow("Заголовок", "описание", actions);
        }

        public void PopUpShow(string Hader, string description, List<ButtonAction> buttonActions)
        {
            _activePopUp = Instantiate(_defaultPrefab,transform);
            _activePopUp.SetHeader(Hader);
            _activePopUp.SetDescription(description);
            _activePopUp.Initialize(buttonActions);
        }
    }


    public class ButtonAction
    {
        public string ButtonText;
        public Action Callback;
    }
}