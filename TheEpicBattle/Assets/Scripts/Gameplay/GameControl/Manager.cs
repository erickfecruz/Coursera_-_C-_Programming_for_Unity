using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour {

    Player player;
    Enemy enemy1;
    Enemy enemy2;
    Enemy enemy3;

    CharacterName playerSelected;
    CharacterName enemySelected;
    CharacterName enemyActual;

    Actions playerAction;
    Actions enemyAction;

    int actualAmmount;

    FirstTurnEvent firstTurn = new FirstTurnEvent();

    /// <summary>
    /// Call before Start
    /// </summary>
    void Awake() {
        // retrieve player and enemies references
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy1 = GameObject.FindWithTag("Enemy1").GetComponent<Enemy>();
        if (Options.PlayerDifficult == Difficult.Normal || Options.PlayerDifficult == Difficult.Hard)
            enemy2 = GameObject.FindWithTag("Enemy2").GetComponent<Enemy>();
        if (Options.PlayerDifficult == Difficult.Hard) 
            enemy3 = GameObject.FindWithTag("Enemy3").GetComponent<Enemy>();
      
        EventManager.AddPlayerActionListener(PlayerAction);
        EventManager.AddPlayerSelectListener(PlayerSelect);

        EventManager.AddEnemyActionListener(EnemyAction);
        EventManager.AddEnemySelectListener(EnemySelect);

        EventManager.AddFirstTurnInvoker(this);
    }

    // Start is called before the first frame update
    void Start() {
        firstTurn.Invoke();
    }

    /// <summary>
    /// Player Action
    /// </summary>
    /// <param name="ammount"></param>
    /// <param name="action"></param>
    private void PlayerAction(int ammount, Actions action) {
        playerAction = action;
        actualAmmount = ammount;

        if (playerAction == Actions.Cure)
            PlayerCureAction();
    }

    /// <summary>
    /// Enemy Action
    /// </summary>
    /// <param name="ammount"></param>
    /// <param name="action"></param>
    /// <param name="enemy"></param>
    private void EnemyAction(int ammount, Actions action, CharacterName enemy) {
        enemyAction = action;
        enemyActual = enemy;
        actualAmmount = ammount;

        if (enemyAction == Actions.Cure)
            EnemyCureAction();
    }

    /// <summary>
    /// Player Select
    /// </summary>
    /// <param name="name"></param>
    private void PlayerSelect(CharacterName name) {
        playerSelected = name;
        if (playerAction == Actions.Attack)
            PlayerAttackAction(); 
        else if (playerAction == Actions.Magic)
            PlayerMagicAction();
    }

    /// <summary>
    /// Enemy Select
    /// </summary>
    /// <param name="name"></param>
    private void EnemySelect(CharacterName name) {
        enemySelected = name;
        if (enemyAction == Actions.Attack)
            EnemyAttackAction();
        else if (enemyAction == Actions.Magic)
            EnemyMagicAction();
    }

    /// <summary>
    /// Player Attack Action
    /// </summary>
    /// <param name="ammount"></param>
    private void PlayerAttackAction() {
        Enemy enemy = enemy1; 
        if (playerSelected == CharacterName.Enemy1) 
            enemy = enemy1;
        else if (playerSelected == CharacterName.Enemy2) 
            enemy = enemy2;
        else if (playerSelected == CharacterName.Enemy3)
            enemy = enemy3;

        int finalDamage = actualAmmount - enemy.DEF;

        if (finalDamage < 0)
            finalDamage = 0;

        enemy.TakeDamage(finalDamage);
    }

    /// <summary>
    /// Player Magic Action
    /// </summary>
    /// <param name="ammount"></param>
    private void PlayerMagicAction() {
        Enemy enemy = enemy1;
        if (playerSelected == CharacterName.Enemy1)
            enemy = enemy1;
        else if (playerSelected == CharacterName.Enemy2)
            enemy = enemy2;
        else if (playerSelected == CharacterName.Enemy3)
            enemy = enemy3;

        int finalDamage = actualAmmount - enemy.MDEF;

        if (finalDamage < 0)
            finalDamage = 0;

        player.ReduceMana(20);
        enemy.TakeDamage(finalDamage);
    }

    /// <summary>
    /// Player Cure Action
    /// </summary>
    /// <param name="ammount"></param>
    private void PlayerCureAction() {
        player.CureCharacter(actualAmmount);
        player.ReduceMana(10);
    }

    /// <summary>
    /// Enemy Attack Action
    /// </summary>
    /// <param name="ammount"></param>
    private void EnemyAttackAction() {
        int finalDamage = actualAmmount - player.DEF;

        if (finalDamage < 0)
            finalDamage = 0;

        player.TakeDamage(finalDamage);
    }

    /// <summary>
    /// Enemy Magic Action
    /// </summary>
    /// <param name="ammount"></param>
    private void EnemyMagicAction() {
        int finalDamage = actualAmmount - player.MDEF;

        if (finalDamage < 0)
            finalDamage = 0;

        if (enemyActual == CharacterName.Enemy1)
            enemy1.ReduceMana(20);
        if (enemyActual == CharacterName.Enemy2)
            enemy2.ReduceMana(20);
        if (enemyActual == CharacterName.Enemy3)
            enemy3.ReduceMana(20);
        player.TakeDamage(finalDamage);
    }

    /// <summary>
    /// Enemy Cure Action
    /// </summary>
    /// <param name="ammount"></param>
    private void EnemyCureAction() {
        if (enemyActual == CharacterName.Enemy1) {
            enemy1.CureCharacter(actualAmmount);
            enemy1.ReduceMana(10);
        }
        else if (enemyActual == CharacterName.Enemy2) {
            enemy2.CureCharacter(actualAmmount);
            enemy2.ReduceMana(10);
        }
        else if (enemyActual == CharacterName.Enemy3) {
            enemy3.CureCharacter(actualAmmount);
            enemy3.ReduceMana(10);
        }
    }

    /// <summary>
    /// Listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddFirstTurnListener(UnityAction listener) {
        firstTurn.AddListener(listener);
    }
}
