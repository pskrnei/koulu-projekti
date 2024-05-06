using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button submitButton;

    private void Start()
    {
        // Assign event listeners to the button
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    private void OnSubmitButtonClick()
    {
        // Retrieve the name entered in the input field
        string playerName = nameInputField.text;

        // Now you can do something with playerName, like passing it to the GameManager
        GameManagerScript.instance.setPlayerName(playerName);
    }
}
