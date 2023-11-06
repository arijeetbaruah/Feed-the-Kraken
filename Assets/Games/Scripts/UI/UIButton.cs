using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Baruah.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour
    {
        private Button _button;
        protected Button _Button
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<Button>();
                }

                return _button;
            }
        }

        public bool isEnabled
        {
            get => _Button.enabled;
            set => _Button.enabled = value;
        }

        public void AddListener(UnityAction onClickAction)
        {
            _Button.onClick.AddListener(onClickAction);
        }

        public void RemoveListener(UnityAction onClickAction)
        {
            _Button.onClick.RemoveListener(onClickAction);
        }
    }
}
