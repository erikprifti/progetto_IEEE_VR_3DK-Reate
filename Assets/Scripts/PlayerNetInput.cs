using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyboardUpdateEvent : UnityEvent<KeyCode, bool> { }

public class PlayerNetInput : NetworkBehaviour
{
    public Dictionary<KeyCode, KeyboardUpdateEvent> keyboardNet = new Dictionary<KeyCode, KeyboardUpdateEvent>();


    public SyncDictionary<KeyCode, bool> callSyncDict = new SyncDictionary<KeyCode, bool>();

    public override void OnStartClient()
    {
        callSyncDict.Callback += OnDictoryUpdate;
        foreach (var qualcosa in callSyncDict)
        {
            OnDictoryUpdate(SyncIDictionary<KeyCode, bool>.Operation.OP_ADD, qualcosa.Key, qualcosa.Value);
        }
    }

    private void Awake()
    {
        keyboardNet[KeyCode.G] = new KeyboardUpdateEvent();
        keyboardNet[KeyCode.R] = new KeyboardUpdateEvent();
        keyboardNet[KeyCode.LeftShift] = new KeyboardUpdateEvent();
        keyboardNet[KeyCode.Space] = new KeyboardUpdateEvent();

    }
    private void Update()
    {
        if (isLocalPlayer)
        {
            if (isServer)
            {
                callSyncDict[KeyCode.G] = Input.GetKey(KeyCode.G);
                callSyncDict[KeyCode.R] = Input.GetKey(KeyCode.R);
                callSyncDict[KeyCode.LeftShift] = Input.GetKey(KeyCode.LeftShift);
                callSyncDict[KeyCode.Space] = Input.GetKey(KeyCode.Space);
            }
            else
            {
                if (callSyncDict[KeyCode.G] != Input.GetKey(KeyCode.G))
                {
                    CmdUpdateKey(KeyCode.G, Input.GetKey(KeyCode.G));
                }
                if (callSyncDict[KeyCode.R] != Input.GetKey(KeyCode.R))
                {
                    CmdUpdateKey(KeyCode.R, Input.GetKey(KeyCode.R));

                }
                if (callSyncDict[KeyCode.LeftShift] != Input.GetKey(KeyCode.LeftShift))
                {
                    CmdUpdateKey(KeyCode.LeftShift, Input.GetKey(KeyCode.LeftShift));
                }
                if (callSyncDict[KeyCode.Space] != Input.GetKey(KeyCode.Space))
                {
                    CmdUpdateKey(KeyCode.Space, Input.GetKey(KeyCode.Space));
                }
            }
        }
    }

    private void OnDictoryUpdate(SyncIDictionary<KeyCode, bool>.Operation op, KeyCode key, bool item)
    {
        switch (op)
        {
            case SyncIDictionary<KeyCode, bool>.Operation.OP_SET:
                keyboardNet[key]?.Invoke(key,item);
                break;
        }
    }

    [Command]
    public void CmdUpdateKey(KeyCode key, bool value)
    {
        callSyncDict[key] = value;
    }
}
