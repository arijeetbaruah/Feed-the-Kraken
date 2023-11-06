using Baruah.Service;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Baruah.UI
{
    public class RegistryScreen : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameTxt;
        [SerializeField] private TMP_InputField passwordTxt;
        [SerializeField] private TMP_InputField cpasswordTxt;
        [SerializeField] private UIButton submitBtn;
        [SerializeField] private UIButton returnBtn;
        [SerializeField] private Transform loginScreenUI;

        private void OnEnable()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            EventSystem.current.SetSelectedGameObject(userNameTxt.gameObject);
#endif
            submitBtn.AddListener(OnSubmit);
            returnBtn.AddListener(OnReturn);
        }

        private void OnDisable()
        {
            submitBtn.RemoveListener(OnSubmit);
            returnBtn.RemoveListener(OnReturn);
        }

        private void Update()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Selectable next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                if (next != null)
                {
                    InputField inputfield = next.GetComponent<InputField>();
                    if (inputfield != null)
                    {
                        inputfield.OnPointerClick(new PointerEventData(EventSystem.current));
                    }
                    EventSystem.current.SetSelectedGameObject(next.gameObject);
                }
            }
#endif
        }

        private void OnReturn()
        {
            loginScreenUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private async void OnSubmit()
        {
            if (passwordTxt.text != cpasswordTxt.text)
            {
                return;
            }

            if (passwordTxt.text.Length == 0 || userNameTxt.text.Length == 0)
            {
                return;
            }

            await ServiceManager.Get<AuthSystem>().SignUp(userNameTxt.text, passwordTxt.text);
        }
    }
}
