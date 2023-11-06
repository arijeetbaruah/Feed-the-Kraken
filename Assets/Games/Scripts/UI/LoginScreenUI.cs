using Baruah.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Baruah.UI
{
    public class LoginScreenUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameTxt;
        [SerializeField] private TMP_InputField passwordTxt;
        [SerializeField] private UIButton loginButton;
        [SerializeField] private UIButton signupButton;

        [SerializeField] private Transform registryScreenUI;

        private void OnEnable()
        {
            loginButton.AddListener(OnLoginClick);
            signupButton.AddListener(OnSignupClick);
        }

        private void OnDisable()
        {
            loginButton.RemoveListener(OnLoginClick);
            signupButton.RemoveListener(OnSignupClick);
        }

        private void OnSignupClick()
        {
            registryScreenUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private async void OnLoginClick()
        {
            await ServiceManager.Get<AuthSystem>().SignInWithUsernamePasswordAsync(userNameTxt.text, passwordTxt.text);
        }
    }
}
