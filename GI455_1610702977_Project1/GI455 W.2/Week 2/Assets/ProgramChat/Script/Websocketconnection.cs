using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

namespace ProgramChat
{
    public class Websocketconnection : MonoBehaviour
    {

        private WebSocket websocket;

        public InputField ip;
        public InputField port;

        public Text textDisplay1, textDisplay2,textMessage;
        public InputField chatBox;

        void Start()
        {
            
            
            
        }
        void Update()
        {

            
                
        }
        public void openSever()
        {

            if (ip.text == "127.0.0.1"||port.text == "5500")
            {

                websocket = new WebSocket("ws://127.0.0.1:5500/");

                websocket.OnMessage += OnMessage;

                websocket.Connect();

                textMessage.GetComponent<Text>().text = "Successfully connected";
            }

            else
            {

                textMessage.GetComponent<Text>().text = "Failed to connect";

            }

        }
        public void chatDisplay()
        {
            if (websocket.ReadyState == WebSocketState.Open)

            {
                websocket.OnMessage += OnMessage;
                websocket.Send(chatBox.text);
                //textDisplay1.GetComponent<Text>().text = "Malila : " + chatBox.text;
                //chatBox.text = "";
            }
          
        }
        private void OnDestroy()
        {
            if (websocket != null)
            {
                websocket.Close();
            }
        }
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Receive msg : " + messageEventArgs.Data);

            if (messageEventArgs.Data == chatBox.text)
            {

                textDisplay1.text = messageEventArgs.Data;

            }

            else
            {

                textDisplay2.text = messageEventArgs.Data;

            }                              
        }
    }    
}


