using Baruah.Service;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace Baruah.UserState
{
    public class UserAuthenticationService : IService
    {
        public UserAuthenticationService()
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        public void SetupEvent()
        {
            AuthenticationService.Instance.SignedIn += () =>
            {

            };
        }
    }
}
