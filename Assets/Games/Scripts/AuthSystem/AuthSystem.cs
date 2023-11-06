using Baruah.Service;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace Baruah
{
    public class AuthSystem : Service.IService
    {
        public delegate void OnLoginEventDelegate(bool success);
        private OnLoginEventDelegate onLoginEventDelegate;

        public AuthSystem(OnLoginEventDelegate onLoginEventDelegate)
        {
            Initialize();
            this.onLoginEventDelegate = onLoginEventDelegate;
        }

        ~AuthSystem()
        {
            UnRegisterEvents();
            onLoginEventDelegate = null;
        }

        private async void Initialize()
        {
            try
            {
                await UnityServices.InitializeAsync();
                RegisterEvents();
                await SignInCachedUserAsync();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RegisterEvents()
        {
            AuthenticationService.Instance.SignedIn += SignedIn;
            AuthenticationService.Instance.SignInFailed += SignInFailed;
            AuthenticationService.Instance.SignedOut += SignedOut;
            AuthenticationService.Instance.Expired += Expired;
        }

        public void UnRegisterEvents()
        {
            AuthenticationService.Instance.SignedIn -= SignedIn;
            AuthenticationService.Instance.SignInFailed -= SignInFailed;
            AuthenticationService.Instance.SignedOut -= SignedOut;
            AuthenticationService.Instance.Expired -= Expired;
        }

        public async Task<string> GetPlayerName()
        {
            return await AuthenticationService.Instance.GetPlayerNameAsync();
        }

        public async Task SignInAnonymouslyAsync()
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Sign in anonymously succeeded!");

                // Shows how to get the playerID
                Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        public async Task SignInWithUsernamePasswordAsync(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
                Debug.Log("SignIn is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        public async Task SignUp(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
                Debug.Log("Username and password Singup.");
                await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        public async Task SignInCachedUserAsync()
        {
            // Check if a cached player already exists by checking if the session token exists
            if (!AuthenticationService.Instance.SessionTokenExists)
            {
                // if not, then do nothing
                return;
            }

            // Sign in Anonymously
            // This call will sign in the cached player.
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Sign in anonymously succeeded!");

                // Shows how to get the playerID
                Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
            }
        }

        private void SignedIn()
        {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
            onLoginEventDelegate?.Invoke(true);
        }

        private void SignInFailed(RequestFailedException err)
        {
            Debug.LogError(err);
            onLoginEventDelegate?.Invoke(false);
        }

        private void SignedOut()
        {
            Debug.Log("Player signed out.");
        }

        private void Expired()
        {
            Debug.Log("Player session could not be refreshed and expired.");
            onLoginEventDelegate?.Invoke(false);
        }
    }
}
