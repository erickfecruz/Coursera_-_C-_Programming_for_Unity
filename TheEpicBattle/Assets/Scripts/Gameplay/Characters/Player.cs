using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character {

    [SerializeField]
    GameObject optionHUD;

    [SerializeField]
    GameObject enemyHUD;

    [SerializeField]
    GameObject[] enemyPosition;

    PlayerAction playerActionEvent = new PlayerAction();
    PlayerSelect playerSelectEvent = new PlayerSelect();

    [SerializeField]
    RuntimeAnimatorController maleAnimator;

    [SerializeField]
    RuntimeAnimatorController femaleAnimator;

    Actions actualAction;
    CharacterName actualCharacterName;

    bool moveAction = false;

    /// <summary>
    /// Initialize players
    /// </summary>
    protected override void Awake() {
        base.Awake();

        if (Options.PlayerGender == Gender.Male)
            GetComponent<Animator>().runtimeAnimatorController = maleAnimator;
        else
            GetComponent<Animator>().runtimeAnimatorController = femaleAnimator;

        EventManager.AddPlayerActionInvoker(this);
        EventManager.AddPlayerSelectInvoker(this);

        if (Options.PlayerClass == Class.Warrior) {
            HP = PlayerConfigUtils.PlayerWarriorHP;
            MP = PlayerConfigUtils.PlayerWarriorMP;
            STR = PlayerConfigUtils.PlayerWarriorSTR;
            INT = PlayerConfigUtils.PlayerWarriorINT;
            DEF = PlayerConfigUtils.PlayerWarriorDEF;
            MDEF = PlayerConfigUtils.PlayerWarriorMDEF;
            SPD = PlayerConfigUtils.PlayerWarriorSPD;
        }
        else if (Options.PlayerClass == Class.Mage) {
            HP = PlayerConfigUtils.PlayerMageHP;
            MP = PlayerConfigUtils.PlayerMageMP;
            STR = PlayerConfigUtils.PlayerMageSTR;
            INT = PlayerConfigUtils.PlayerMageINT;
            DEF = PlayerConfigUtils.PlayerMageDEF;
            MDEF = PlayerConfigUtils.PlayerMageMDEF;
            SPD = PlayerConfigUtils.PlayerMageSPD;
        }
        else if (Options.PlayerClass == Class.Neutral) {
            HP = PlayerConfigUtils.PlayerNeutralHP;
            MP = PlayerConfigUtils.PlayerNeutralMP;
            STR = PlayerConfigUtils.PlayerNeutralSTR;
            INT = PlayerConfigUtils.PlayerNeutralINT;
            DEF = PlayerConfigUtils.PlayerNeutralDEF;
            MDEF = PlayerConfigUtils.PlayerNeutralMDEF;
            SPD = PlayerConfigUtils.PlayerNeutralSPD;
        }
        MAXHP = HP;

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
        } else if (moveAction) {
            moveAction = false;
            if (destination == initialPosition) {
                ChangeAnimation(Animations.Idle);
                nextTurn.Invoke();
            } else {
                // Action
                if (actualAction == Actions.Attack)
                    ChangeAnimation(Animations.Attack);
                else 
                    ChangeAnimation(Animations.Magic);
               
                // Enemy
                if (actualCharacterName == CharacterName.Enemy1)
                    playerSelectEvent.Invoke(CharacterName.Enemy1);
                else if (actualCharacterName == CharacterName.Enemy2)
                    playerSelectEvent.Invoke(CharacterName.Enemy2);
                else if (actualCharacterName == CharacterName.Enemy3)
                    playerSelectEvent.Invoke(CharacterName.Enemy3);
            }
        }
    }

    public void AttackEnemy() {
        int value = Attack();
        if (value < 0)
            return;

        optionHUD.SetActive(false);
        enemyHUD.SetActive(true);
        actualAction = Actions.Attack;
        playerActionEvent.Invoke(value, Actions.Attack);
    }

    public void MagicEnemy() {
        int value = Magic();
        if (value < 0)
            return;

        optionHUD.SetActive(false);
        enemyHUD.SetActive(true);
        actualAction = Actions.Magic;
        playerActionEvent.Invoke(value, Actions.Magic);
    }

    public void SelfHeal() {
        int value = Heal();
        if (value < 0)
            return;

        optionHUD.SetActive(false);
        ChangeAnimation(Animations.Cure);
    }

    /// <summary>
    /// Enemy 1 Options 
    /// </summary>
    public void Enemy1() {
        enemyHUD.SetActive(false);
        actualCharacterName = CharacterName.Enemy1;
        ChangeAnimation(Animations.MoveIn);
        destination = enemyPosition[0].transform.position;
    }

    /// <summary>
    /// Enemy 2 Options 
    /// </summary>
    public void Enemy2() {
        enemyHUD.SetActive(false);
        actualCharacterName = CharacterName.Enemy2;
        ChangeAnimation(Animations.MoveIn);
        destination = enemyPosition[1].transform.position;
    }


    /// <summary>
    /// Enemy 3 Options 
    /// </summary>
    public void Enemy3() {
        enemyHUD.SetActive(false);
        actualCharacterName = CharacterName.Enemy3;
        ChangeAnimation(Animations.MoveIn);
        destination = enemyPosition[2].transform.position;
    }

    /// <summary>
    /// Function after heal animation
    /// </summary>
    public void ExecuteHeal() {
        playerActionEvent.Invoke(Heal(), Actions.Cure);
        ChangeAnimation(Animations.Idle);
        nextTurn.Invoke();
    }

    public override void ChooseOption() {
        optionHUD.SetActive(true);
    }

    /// <summary>
    /// Listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddPlayerActionListener(UnityAction<int, Actions> listener) {
        playerActionEvent.AddListener(listener);
    }

    public void AddPlayerSelectListener(UnityAction<CharacterName> listener) {
        playerSelectEvent.AddListener(listener);
    }

    /// <summary>
    /// Attack Sound
    /// </summary>
    public override void AttackSound() {
        AudioManager.Play(AudioName.AttackPlayer);
    }
}