using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChatHandle : MonoBehaviour
{
    public GameObject message;
    public GameObject chatbox;
    public InputField chat;
    private GameObject newmessage;
    public GameObject Player;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void recieveMessage(string msg)
    {
        if(msg.StartsWith("/"))
        {
            string[] words = msg.Split('/');
            runCmd(words[1]);
        }
        else
        {
            newmessage = Instantiate(message, chatbox.transform, chatbox);
            text = newmessage.GetComponent<Text>();
            text.text = msg;
        }

       
    }
    public void sendMessage()
    {
       
    }
    public void runCmd(string cmd)
    {
        string[] words = cmd.Split(' ');

        if (words[0] == ("tp"))
        {
            newmessage = Instantiate(message, chatbox.transform, chatbox);
            text = newmessage.GetComponent<Text>();
            text.text = "Teleporting Player to " + words[1] + "," + words[2] + "," + words[3];
            float x = float.Parse(words[1]);
            float y = float.Parse(words[2]);
            float z = float.Parse(words[3]);
            Player.transform.position = new Vector3(x, y, z);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {

           // yield return new WaitForSeconds(1);
         //   chat.gameObject.SetActive(true);
          //  EventSystemManager.currentSystem.SetSelectedGameObject(chat.gameObject, null);
          //  chat.OnPointerClick(null);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            recieveMessage(chat.text);
        }
    }
}
