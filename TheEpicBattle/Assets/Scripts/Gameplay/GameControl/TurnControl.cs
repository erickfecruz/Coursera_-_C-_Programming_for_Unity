using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TurnControl : MonoBehaviour {

    Character player;
    Character enemy1;
    Character enemy2;
    Character enemy3;

    [SerializeField]
    GameObject enemy2Player;

    [SerializeField]
    GameObject enemy2Text;

    [SerializeField]
    GameObject enemy3Player;

    [SerializeField]
    GameObject enemy3Text;

    [SerializeField]
    Text winnerMessage;

    List<Character> turnOrder;

    int index = 0;

    float actualTime = 0;
    float timeToWait = 0.5f;
    bool waiting = false;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake() {
        turnOrder = new List<Character>();

        if (Options.PlayerDifficult == Difficult.Hard) {
            enemy2 = GameObject.FindWithTag("Enemy2").GetComponent<Enemy>();
            enemy3 = GameObject.FindWithTag("Enemy3").GetComponent<Enemy>();
            // = new Character[4];
        } else if (Options.PlayerDifficult == Difficult.Normal) {
            enemy3Player.SetActive(false);
            enemy3Text.SetActive(false);
            enemy2 = GameObject.FindWithTag("Enemy2").GetComponent<Enemy>();
            //turnOrder = new Character[3];
        } else {
            enemy2Player.SetActive(false);
            enemy2Text.SetActive(false);
            enemy3Player.SetActive(false);
            enemy3Text.SetActive(false);
            //turnOrder = new Character[2];
        }

        // retrieve player and enemies references
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy1 = GameObject.FindWithTag("Enemy1").GetComponent<Enemy>();

        EventManager.AddFirstTurnListener(NewTurn);
        EventManager.AddNextTurnListener(NextTurn);
    }

    /// <summary>
    /// Start a new turn
    /// </summary>
    public void NewTurn() {
        DefineOrder();
        NextTurn();
    }

/// <summary>
/// Define who attack first
/// </summary>
    private void DefineOrder() {
        index = 0;
        turnOrder.Clear();

        turnOrder.Add(player);
        player.AttackSpeed();

        if (enemy1.HP != 0) {
            turnOrder.Add(enemy1);
            enemy1.AttackSpeed();
        }

        if (Options.PlayerDifficult == Difficult.Normal) {
            if (enemy2.HP != 0) {
                turnOrder.Add(enemy2);
                enemy2.AttackSpeed();
            }
        }
        else if (Options.PlayerDifficult == Difficult.Hard) {
            if (enemy2.HP != 0) {
                turnOrder.Add(enemy2);
                enemy2.AttackSpeed();
            }
            if (enemy3.HP != 0) {
                turnOrder.Add(enemy3);
                enemy3.AttackSpeed();
            }
        }
        turnOrder.Sort();
    }

    /// <summary>
    /// Select an option
    /// </summary>
    public void NextTurn() {
        waiting = true;
    }

    private void NextTurnAction() {
        if (player.HP == 0) {
            winnerMessage.text = "GAME OVER\nYOU LOSE";
            AudioManager.Play(AudioName.Gameover);
            return;
        }
        else if (Options.PlayerDifficult == Difficult.Easy) {
            if (enemy1.HP == 0) {
                winnerMessage.text = "YOU WIN";
                AudioManager.Play(AudioName.Victory);
                return;
            }
        }
        else if (Options.PlayerDifficult == Difficult.Normal) {
            if (enemy1.HP == 0 && enemy2.HP == 0) {
                winnerMessage.text = "YOU WIN";
                AudioManager.Play(AudioName.Victory);
                return;
            }
        }
        else if (Options.PlayerDifficult == Difficult.Hard) {
            if (enemy1.HP == 0 && enemy2.HP == 0 && enemy3.HP == 0) {
                winnerMessage.text = "YOU WIN";
                AudioManager.Play(AudioName.Victory);
                return;
            }
        }

        if (index == turnOrder.Count)
            NewTurn();

        else {
            Character nextCharacter = turnOrder[index];
            index++;
            if (nextCharacter.HP == 0)
                NextTurn();
            else
                nextCharacter.ChooseOption();
        }
    }

    void Update() {
        if (waiting) {
            actualTime += Time.deltaTime;
            if (timeToWait <= actualTime) {
                waiting = false;
                actualTime = 0;
                NextTurnAction();
            }
        }
    }
}