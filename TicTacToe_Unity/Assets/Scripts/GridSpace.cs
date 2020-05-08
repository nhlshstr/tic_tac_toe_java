using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
    public Button button;
    public Text buttonText;

    private GameController gameController;

    /**
     * SetGameControllerReference - Function that calls the GameController
     * and handles the flow of the TicTacToe game
     */
    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }

    /**
     * SetSpace - Function that allows the player to set their symbol
     * onto the game board, if allowed
     */
    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}
