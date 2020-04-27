using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character {

    EnemyAction enemyActionEvent = new EnemyAction();
    EnemySelect enemySelectEvent = new EnemySelect();

    [SerializeField]
    GameObject playerPosition;

    Actions actualAction;

    bool moveAction = false;

    CharacterName enemyName;

    /// <summary>
    /// Initialize players
    /// </summary>
    protected override void Awake() {
        base.Awake();
        EventManager.AddEnemyActionInvoker(this);
        EventManager.AddEnemySelectInvoker(this);

        EnemyConfigUtils.Initialize();

        HP = EnemyConfigUtils.EnemyHP;
        MAXHP = HP;
        MP = EnemyConfigUtils.EnemyMP;
        STR = EnemyConfigUtils.EnemySTR;
        INT = EnemyConfigUtils.EnemyINT;
        DEF = EnemyConfigUtils.EnemyDEF;
        MDEF = EnemyConfigUtils.EnemyMDEF;
        SPD = EnemyConfigUtils.EnemySPD;
    }

    /// <summary>
    /// Update Override
    /// </summary>
    protected override void Update() {
        base.Update();

        // Movement
        if (gameObject.transform.position != destination) {
            moveAction = true;
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
        else if (moveAction) {
            moveAction = false;
            if (destination == initialPosition) {
                ChangeAnimation(Animations.Idle);
                nextTurn.Invoke();
            }
            else {
                // Action
                if (actualAction == Actions.Attack)
                    ChangeAnimation(Animations.Attack);
                else
                    ChangeAnimation(Animations.Magic);

                // Player
                enemySelectEvent.Invoke(CharacterName.Player);
            }
        }
    }
    public override void ChooseOption() {

        if (gameObject.tag == "Enemy1")
            enemyName = CharacterName.Enemy1;
        else if (gameObject.tag == "Enemy2")
            enemyName = CharacterName.Enemy2;
        else
            enemyName = CharacterName.Enemy3;

        int validAction = -1;
        while (validAction < 0) {
            int option = Random.Range(0, 3);
            switch (option) {
                case 0:
                    validAction = Attack();
                    if (validAction >= 0) {
                        enemyActionEvent.Invoke(validAction, Actions.Attack, enemyName);
                        actualAction = Actions.Attack;
                        destination = playerPosition.transform.position;
                        ChangeAnimation(Animations.MoveIn);
                    }
                    break;
                case 1:
                    validAction = Magic();
                    if (validAction >= 0) { 
                        enemyActionEvent.Invoke(validAction, Actions.Magic, enemyName);
                        actualAction = Actions.Magic;
                        destination = playerPosition.transform.position;
                        ChangeAnimation(Animations.MoveIn);
                    }
            break;
                case 2:
                    validAction = Heal();
                    if (validAction >= 0)
                        ChangeAnimation(Animations.Cure);
                    break;
            }
        }
    }

    /// <summary>
    /// Listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddEnemyActionListener(UnityAction<int, Actions, CharacterName> listener) {
        enemyActionEvent.AddListener(listener);
    }

    public void AddEnemySelectListener(UnityAction<CharacterName> listener) {
        enemySelectEvent.AddListener(listener);
    }

    /// <summary>
    /// Function after heal animation
    /// </summary>
    public void ExecuteHeal() {
        enemyActionEvent.Invoke(Heal(), Actions.Cure, enemyName);
        ChangeAnimation(Animations.Idle);
        nextTurn.Invoke();
    }

    /// <summary>
    /// Attack Sound
    /// </summary>
    public override void AttackSound() {
        AudioManager.Play(AudioName.AttackEnemy);
    }

}

