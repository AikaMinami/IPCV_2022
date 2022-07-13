using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SetPlayerName : MonoBehaviour
{
        const string playerNamePrefKey = "PlayerName";
        public Text playerName;
        public InputField playerNameInput;

        void Start()
        {
            if(string.IsNullOrEmpty(PlayerPrefs.GetString(playerNamePrefKey)))
            {
                playerName.text = "Input Your Name";
            } else {
                playerName.text = "Hello, " + PlayerPrefs.GetString(playerNamePrefKey);  
            }
        }
        public void SetPlayerNames()
        {
            // #Important
            if (string.IsNullOrEmpty(playerNameInput.text))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = playerNameInput.text;

            PlayerPrefs.SetString(playerNamePrefKey,playerNameInput.text);
            playerName.text = "Hello, " + PlayerPrefs.GetString(playerNamePrefKey); 
        }
}
