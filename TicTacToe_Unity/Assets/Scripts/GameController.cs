using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
 * GameController - Function that handles the flow of the game.
 * Keeps track of player's turns as well as determine if the game
 * is won or drawn
 */
public class GameController : MonoBehaviour {
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    private string playerSide;
    private int moveCount;

    /**
     * Awake - Function that signifies the start of the game
     * X always goes first
     * We also want to keep track of number of turns that has already passed
     * so we can end the game if no more turns can be made
     */
    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);    //Disables win text at the start of the game
        moveCount = 0;
        restartButton.SetActive(false);    //Disables restart text at the start of the game
    } 

    /**
     * SetGameControllerReferenceOnButtons - Function that allows the GridSpace instance to
     * use this class to set up GameController
     */
    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    /**
     * GetPlayerSide - Function that gets the player's symbol to
     * determine whose turn it is
     * Return: The player's symbol
     */
    public string GetPlayerSide ()
    {
        return playerSide;
    }

    /**
     * EndTurn - Function that checks whether a player has won by 3 consecutive marks
     * horizontally, vertically, or diagonally
     * If so, call the function GameOver to signify that the game has ended. Otherwise,
     * switch over to the next player's turn and increment turn count by 1
     */
    public void EndTurn ()
    {
        moveCount++;
        //Line check, top row
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, middle row
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, bottom row
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, left column
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, middle column
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, right column
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, top left to bottom right diagonal
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Line check, top right to bottom left diagonal
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        //If no more spots remain to place a symbol...
        if (moveCount >= 9)
        {
            GameOver("draw");
        }

        //If no line can be successfully drawn...
        ChangeSides();
    }

    /**
     * ChangeSides - Function that switches to the next player's turn
     * It's really a ternary operator check to determine if it is X's turn
     * or O's turn
     */
    void ChangeSides()
    {
        //Equivalent: if playerSide == "X", set playerSide to "O". Else, set to "X"
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    /**
     * GameOver - Function that signifies that the game is over by preventing
     * any further tiles from being marked
     * Also displays a message of the game's winner
     */
    void GameOver(string winningPlayer)
    {
        /* The following code is moved to the function SetBoardInteractable
         * and is therefore no longer needed here
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        gameOverPanel.SetActive(true); */
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    /**
     * SetGameOverText - Function that displays the game over message
     * @value: The string to be displayed upon game over
     */
    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    /**
     * RestartGame - Function that restarts the game by resetting certain variables
     */
    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    /**
     * SetBoardInteractable - Function that determines whether the board can
     * be interacted with or not
     * @toggle: The boolean that determines interactivity of the board
     */
    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
