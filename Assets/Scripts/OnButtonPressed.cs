using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OnButtonPressed : MonoBehaviour
{
    public InputAction input;
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    // Start is called before the first frame update
    private void Awake()
    {
        input.started += Press; //把动作的开始与Press关联
        input.canceled += Release; //把动作的结束与Release关联
    }

    private void OnDestroy()
    {
        input.started -= Press;//把动作的开始与Press取消关联
        input.canceled -= Release; //把动作的结束与Release取消关联
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Press(InputAction.CallbackContext context) //InputAction.CallbackContext context相当于监听InputAction的动作，不写的话就无法关联
    {
        onPressed.Invoke(); //动作的开始与Press关联，Press内容是执行onPressed事件的内容
        Debug.Log("Pressed");
    }
    void Release(InputAction.CallbackContext context)
    {
        onReleased.Invoke();
    }
}
