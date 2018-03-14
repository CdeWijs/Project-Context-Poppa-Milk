﻿using UnityEngine;

public abstract class InputSystem
{
    public static InputSystem GetInputSystem()
    {
        #if UNITY_IPHONE || UNITY_ANDROID
            return new InputMobile();
        #elif UNITY_STANDALONE || UNITY_EDITOR
            return new InputPC();
        #endif
    }

    public abstract float GetAxis(GameAction action);
    public abstract bool GetColliderInteraction(Collider2D collision, LayerMask layerMask, string name);
    public abstract void CheckInput();
}

