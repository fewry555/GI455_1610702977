using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystem : MonoBehaviour
{

    public string username;
    public int maxMessaages = 25;

    public GameObject chatpanel, textdisplay;
    public InputField chatBox;

    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();
  
    void Start()
    {
        
    }


    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                SendMessageToChat(username + ": " + chatBox.text,Message.MessageType.playerMessage);
                chatBox.text = "";

            }
        }
        else
        {

            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();

        }

        if (chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //SendMessageToChat("You pressed the space bar!",Message.MessageType.info);
                Debug.Log("Space");
            }


        }    
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessaages)
        {
            Destroy(messageList[0].textdisplay.gameObject);
            messageList.Remove(messageList[0]);

        }
        

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textdisplay, chatpanel.transform);

        newMessage.textdisplay = newText.GetComponent<Text>();

        newMessage.textdisplay.text = newMessage.text;
        newMessage.textdisplay.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);

    }

    Color MessageTypeColor(Message.MessageType messageType)
    {

        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
         
        }


            return color;

    }


    [System.Serializable]
    public class Message
    {

        public string text;
        public Text textdisplay;

        public enum MessageType
        {

            playerMessage,info

        }

    }
}
