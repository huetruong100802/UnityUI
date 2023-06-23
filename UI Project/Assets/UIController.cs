using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button messageButton;
    public Label messageText;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        messageButton = root.Q<Button>("message-button");
        messageText = root.Q<Label>("message-text");

        startButton.clicked += StartButtonPressed;
        messageButton.clicked += MessageButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("game");
    }
    void MessageButtonPressed()
    {
        messageText.text = "Hello world";
        messageText.style.display = DisplayStyle.Flex;
    }
}
