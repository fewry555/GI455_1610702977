using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SearchCode : MonoBehaviour
{
    public string Guitar, Computer, Book, Fan, Money;
    public Text inputField;
    public Text textDisplay;
    
    public void resultName()
    {
        if ( inputField.text == "Guitar")
        {
            
            Guitar = inputField.GetComponent<Text>().text;
            textDisplay.GetComponent<Text>().text = "[ " + "<color=green>Guitar</color>" + " ] is found.";         
        }
        else if ( inputField.text == "Book")
        {
            
            Book = inputField.GetComponent<Text>().text;
            textDisplay.GetComponent<Text>().text = "[ " + "<color=green>Book</color>" + " ] is found.";

        }
        else if ( inputField.text == "Computer")
        {
            
            Computer = inputField.GetComponent<Text>().text;
            textDisplay.GetComponent<Text>().text = "[ " + "<color=green>Computer</color>" + " ] is found.";
            
        }
        else if ( inputField.text == "Fan" )
        {
            
            Fan = inputField.GetComponent<Text>().text;
            textDisplay.GetComponent<Text>().text = "[ " + "<color=green>Fan</color>" + " ] is found.";
            
        }
        else if ( inputField.text == "Money" )
        {
            
            Money = inputField.GetComponent<Text>().text;
            textDisplay.GetComponent<Text>().text = "[ " + "<color=green>Money</color>" + " ] is found.";
        }
        else
        {
            
            textDisplay.GetComponent<Text>().text = " [] is not found. ";
        }
    }
}
