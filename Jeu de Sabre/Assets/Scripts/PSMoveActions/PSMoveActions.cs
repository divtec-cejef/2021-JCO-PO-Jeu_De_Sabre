// // GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PSMoveActions/PSMoveActions.inputactions'
//
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Utilities;
//
// public class @PSMoveActions : IInputActionCollection, IDisposable
// {
//     public InputActionAsset asset { get; }
//     public @PSMoveActions()
//     {
//         asset = InputActionAsset.FromJson(@"{
//     ""name"": ""PSMoveActions"",
//     ""maps"": [
//         {
//             ""name"": ""Buttons"",
//             ""id"": ""0edbfaf2-e0c3-47b5-811f-1fe6ea50643e"",
//             ""actions"": [
//                 {
//                     ""name"": ""Trigger"",
//                     ""type"": ""Button"",
//                     ""id"": ""ec66f6cb-3411-4310-96d0-9cdab3fcf8ce"",
//                     ""expectedControlType"": ""Button"",
//                     ""processors"": """",
//                     ""interactions"": """"
//                 },
//                 {
//                     ""name"": ""Move"",
//                     ""type"": ""Button"",
//                     ""id"": ""9e2cf744-48c5-482f-8057-b9d919dd266c"",
//                     ""expectedControlType"": ""Button"",
//                     ""processors"": """",
//                     ""interactions"": """"
//                 },
//                 {
//                     ""name"": ""attak"",
//                     ""type"": ""Button"",
//                     ""id"": ""cc74512d-07b4-4804-a238-4f53216eef34"",
//                     ""expectedControlType"": ""Button"",
//                     ""processors"": """",
//                     ""interactions"": """"
//                 },
//                 {
//                     ""name"": ""recul"",
//                     ""type"": ""Button"",
//                     ""id"": ""181d4c2a-43dc-4935-949b-5904137cfc16"",
//                     ""expectedControlType"": ""Button"",
//                     ""processors"": """",
//                     ""interactions"": """"
//                 }
//             ],
//             ""bindings"": [
//                 {
//                     ""name"": """",
//                     ""id"": ""3a1e1f6c-180b-4172-a061-6444da62380f"",
//                     ""path"": ""<HID::Sony Computer Entertainment Motion Controller>/button21"",
//                     ""interactions"": """",
//                     ""processors"": """",
//                     ""groups"": """",
//                     ""action"": ""Trigger"",
//                     ""isComposite"": false,
//                     ""isPartOfComposite"": false
//                 },
//                 {
//                     ""name"": """",
//                     ""id"": ""37ed2e36-dcf4-4600-95ef-46015b8d6b38"",
//                     ""path"": ""<HID::Sony Computer Entertainment Motion Controller>/button20"",
//                     ""interactions"": """",
//                     ""processors"": """",
//                     ""groups"": """",
//                     ""action"": ""Move"",
//                     ""isComposite"": false,
//                     ""isPartOfComposite"": false
//                 },
//                 {
//                     ""name"": """",
//                     ""id"": ""41aa84b4-0a37-4f9f-85f7-42074a048e8e"",
//                     ""path"": ""<Keyboard>/w"",
//                     ""interactions"": """",
//                     ""processors"": """",
//                     ""groups"": """",
//                     ""action"": ""attak"",
//                     ""isComposite"": false,
//                     ""isPartOfComposite"": false
//                 },
//                 {
//                     ""name"": """",
//                     ""id"": ""9f3e14e4-bdff-49a2-86e3-bfa0dd9a23cd"",
//                     ""path"": ""<Keyboard>/s"",
//                     ""interactions"": """",
//                     ""processors"": """",
//                     ""groups"": """",
//                     ""action"": ""recul"",
//                     ""isComposite"": false,
//                     ""isPartOfComposite"": false
//                 }
//             ]
//         }
//     ],
//     ""controlSchemes"": []
// }");
//         // Buttons
//         m_Buttons = asset.FindActionMap("Buttons", throwIfNotFound: true);
//         m_Buttons_Trigger = m_Buttons.FindAction("Trigger", throwIfNotFound: true);
//         m_Buttons_Move = m_Buttons.FindAction("Move", throwIfNotFound: true);
//         m_Buttons_attak = m_Buttons.FindAction("attak", throwIfNotFound: true);
//         m_Buttons_recul = m_Buttons.FindAction("recul", throwIfNotFound: true);
//     }
//
//     public void Dispose()
//     {
//         UnityEngine.Object.Destroy(asset);
//     }
//
//     public InputBinding? bindingMask
//     {
//         get => asset.bindingMask;
//         set => asset.bindingMask = value;
//     }
//
//     public ReadOnlyArray<InputDevice>? devices
//     {
//         get => asset.devices;
//         set => asset.devices = value;
//     }
//
//     public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;
//
//     public bool Contains(InputAction action)
//     {
//         return asset.Contains(action);
//     }
//
//     public IEnumerator<InputAction> GetEnumerator()
//     {
//         return asset.GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
//
//     public void Enable()
//     {
//         asset.Enable();
//     }
//
//     public void Disable()
//     {
//         asset.Disable();
//     }
//
//     // Buttons
//     private readonly InputActionMap m_Buttons;
//     private IButtonsActions m_ButtonsActionsCallbackInterface;
//     private readonly InputAction m_Buttons_Trigger;
//     private readonly InputAction m_Buttons_Move;
//     private readonly InputAction m_Buttons_attak;
//     private readonly InputAction m_Buttons_recul;
//     public struct ButtonsActions
//     {
//         private @PSMoveActions m_Wrapper;
//         public ButtonsActions(@PSMoveActions wrapper) { m_Wrapper = wrapper; }
//         public InputAction @Trigger => m_Wrapper.m_Buttons_Trigger;
//         public InputAction @Move => m_Wrapper.m_Buttons_Move;
//         public InputAction @attak => m_Wrapper.m_Buttons_attak;
//         public InputAction @recul => m_Wrapper.m_Buttons_recul;
//         public InputActionMap Get() { return m_Wrapper.m_Buttons; }
//         public void Enable() { Get().Enable(); }
//         public void Disable() { Get().Disable(); }
//         public bool enabled => Get().enabled;
//         public static implicit operator InputActionMap(ButtonsActions set) { return set.Get(); }
//         public void SetCallbacks(IButtonsActions instance)
//         {
//             if (m_Wrapper.m_ButtonsActionsCallbackInterface != null)
//             {
//                 @Trigger.started -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnTrigger;
//                 @Trigger.performed -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnTrigger;
//                 @Trigger.canceled -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnTrigger;
//                 @Move.started -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnMove;
//                 @Move.performed -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnMove;
//                 @Move.canceled -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnMove;
//                 @attak.started -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnAttak;
//                 @attak.performed -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnAttak;
//                 @attak.canceled -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnAttak;
//                 @recul.started -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnRecul;
//                 @recul.performed -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnRecul;
//                 @recul.canceled -= m_Wrapper.m_ButtonsActionsCallbackInterface.OnRecul;
//             }
//             m_Wrapper.m_ButtonsActionsCallbackInterface = instance;
//             if (instance != null)
//             {
//                 @Trigger.started += instance.OnTrigger;
//                 @Trigger.performed += instance.OnTrigger;
//                 @Trigger.canceled += instance.OnTrigger;
//                 @Move.started += instance.OnMove;
//                 @Move.performed += instance.OnMove;
//                 @Move.canceled += instance.OnMove;
//                 @attak.started += instance.OnAttak;
//                 @attak.performed += instance.OnAttak;
//                 @attak.canceled += instance.OnAttak;
//                 @recul.started += instance.OnRecul;
//                 @recul.performed += instance.OnRecul;
//                 @recul.canceled += instance.OnRecul;
//             }
//         }
//     }
//     public ButtonsActions @Buttons => new ButtonsActions(this);
//     public interface IButtonsActions
//     {
//         void OnTrigger(InputAction.CallbackContext context);
//         void OnMove(InputAction.CallbackContext context);
//         void OnAttak(InputAction.CallbackContext context);
//         void OnRecul(InputAction.CallbackContext context);
//     }
// }
