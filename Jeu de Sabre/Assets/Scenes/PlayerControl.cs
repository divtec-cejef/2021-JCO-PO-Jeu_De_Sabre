// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""AvantArriere"",
            ""id"": ""21e647d8-daa1-4844-9c52-b797ba2ca2b4"",
            ""actions"": [
                {
                    ""name"": ""Avancer"",
                    ""type"": ""Button"",
                    ""id"": ""411d551a-e823-43cf-8962-c689f6b02502"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reculer"",
                    ""type"": ""Button"",
                    ""id"": ""3f5be688-154c-4b5c-9514-6b4d01dba640"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""75f81fc9-5d1e-4ff9-8a20-112176b21488"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Avancer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ff871eb-ccb4-4ed3-a174-a9350863b1f6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reculer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AvantArriere
        m_AvantArriere = asset.FindActionMap("AvantArriere", throwIfNotFound: true);
        m_AvantArriere_Avancer = m_AvantArriere.FindAction("Avancer", throwIfNotFound: true);
        m_AvantArriere_Reculer = m_AvantArriere.FindAction("Reculer", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // AvantArriere
    private readonly InputActionMap m_AvantArriere;
    private IAvantArriereActions m_AvantArriereActionsCallbackInterface;
    private readonly InputAction m_AvantArriere_Avancer;
    private readonly InputAction m_AvantArriere_Reculer;
    public struct AvantArriereActions
    {
        private @PlayerControl m_Wrapper;
        public AvantArriereActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Avancer => m_Wrapper.m_AvantArriere_Avancer;
        public InputAction @Reculer => m_Wrapper.m_AvantArriere_Reculer;
        public InputActionMap Get() { return m_Wrapper.m_AvantArriere; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AvantArriereActions set) { return set.Get(); }
        public void SetCallbacks(IAvantArriereActions instance)
        {
            if (m_Wrapper.m_AvantArriereActionsCallbackInterface != null)
            {
                @Avancer.started -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnAvancer;
                @Avancer.performed -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnAvancer;
                @Avancer.canceled -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnAvancer;
                @Reculer.started -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnReculer;
                @Reculer.performed -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnReculer;
                @Reculer.canceled -= m_Wrapper.m_AvantArriereActionsCallbackInterface.OnReculer;
            }
            m_Wrapper.m_AvantArriereActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Avancer.started += instance.OnAvancer;
                @Avancer.performed += instance.OnAvancer;
                @Avancer.canceled += instance.OnAvancer;
                @Reculer.started += instance.OnReculer;
                @Reculer.performed += instance.OnReculer;
                @Reculer.canceled += instance.OnReculer;
            }
        }
    }
    public AvantArriereActions @AvantArriere => new AvantArriereActions(this);
    public interface IAvantArriereActions
    {
        void OnAvancer(InputAction.CallbackContext context);
        void OnReculer(InputAction.CallbackContext context);
    }
}
