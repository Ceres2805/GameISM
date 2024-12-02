using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;


// public class ConnectToServer : MonoBehaviourPunCallbacks
// {
//     public GameObject usernameInput;
//     public TextMeshProUGUI buttonText;

//     public void OnClickConnect(){

//         if(usernameInput.GetComponent<TMP_InputField>().text.Length>=1){
//             PhotonNetwork.NickName = usernameInput.GetComponent<TMP_InputField>().text;
//             buttonText.text = "Connecting..." ;
//             PhotonNetwork.ConnectUsingSettings();
//         }
//     }

//     public override void OnConnectedToMaster()
//     {
//         SceneManager.LoadScene("prem_multi_lobby");
//     }



// }


public class ConnectToServer : MonoBehaviourPunCallbacks{
    private void Start(){
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("prem_multi_lobby");
    }
}