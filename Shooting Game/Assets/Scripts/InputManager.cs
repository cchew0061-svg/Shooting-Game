using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    //contains actions within the OnFoot action map within unity

    private PlayerMotor motor;
    private PlayerLook look;
    private Weapons weapons;

    public PlayerInput.DeadActions dead;
    //contains actions within the Dead action map within unity

    private PlayerDead playerDead;

    public PlayerInput.StartGameActions startGame;
    private GameStart gameStart;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        dead = playerInput.Dead;
        startGame = playerInput.StartGame;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        playerDead = GetComponent<PlayerDead>();
        weapons = GameObject.Find("Weapons").GetComponent<Weapons>();
        gameStart = GameObject.Find("player").GetComponent<GameStart>();

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.CrouchChange();
        onFoot.Shoot.performed += ctx => weapons.Shoot();
        onFoot.SwapGun1.performed += ctx => weapons.SwapGun1();
        onFoot.SwapGun2.performed += ctx => weapons.SwapGun2();
        onFoot.SwapKnife.performed += ctx => weapons.SwapKnife();
        
        startGame.StartGameFunction.performed += ctx => gameStart.StartGame();

        dead.Restart.performed += ctx => playerDead.Restart();

        StartGameOnEnable();
        OnFootOnDisable();
        DeadOnDisable();
    }

    // Update is called once per frame
    //tells PlayerMotor to move using the value from the movement action
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    //tells PlayerMotor to look using the value from the look action
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    //enables onFoot action map
    public void OnFootOnEnable()
    {
        onFoot.Enable();
    }

    //disables onFoot action map
    public void OnFootOnDisable()
    {
        onFoot.Disable();
    }

    //enables dead action map
    public void DeadOnEnable()
    {
        dead.Enable();
    }

    //disables dead action map
    private void DeadOnDisable()
    {
        dead.Disable();
    }

    //enables startgame action map
    public void StartGameOnEnable()
    {
        startGame.Enable();
    }

    //disables startgame action map
    public void StartGameOnDisable()
    {
        startGame.Disable();
    }
}


