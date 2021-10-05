// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/ActionInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c7190b72-3794-46bf-bd8d-d0f9e0c721d7"",
            ""actions"": [
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5330bab7-9bcd-47ce-9961-2429b6eb3add"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""858570b7-2dce-485e-b206-81ca27a5b3ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""8159cb26-9fe1-4d77-8492-2332771cb33c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""15884b06-7e00-46e3-a5a7-5707f2009081"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""dce3b04b-c6e0-4135-931a-c3723efca522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ad1fc981-676d-418e-9e2d-991fc2687033"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""Button"",
                    ""id"": ""280e1553-d83c-418e-8764-62a7789e9c65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""6cde51a9-75d1-4d32-ba38-578c987b0470"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""98bd0927-fb48-4026-b45a-ea8c5e520ef8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c0b88dd2-eb29-43b0-a00a-51895e910f38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick1"",
                    ""type"": ""Button"",
                    ""id"": ""483aff5f-ccd9-4b85-b111-cf5934a44e75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick2"",
                    ""type"": ""Button"",
                    ""id"": ""c0e68ff6-f1cb-4192-b82d-5a8da60e8ab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick3"",
                    ""type"": ""Button"",
                    ""id"": ""5506d9ca-285e-4fc3-94d9-5b91e3b3f3aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick4"",
                    ""type"": ""Button"",
                    ""id"": ""ea4bc287-87e8-4e56-8c13-64ca5a4224e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ba2d8ca8-6cdf-47a1-856b-86a04eaa2cf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TEST"",
                    ""type"": ""Button"",
                    ""id"": ""5befc741-2d19-4e49-98fc-21bb0b282bac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2102a6c5-edf8-45ee-a884-13ec652c0d3d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""264051b3-491f-452f-bb12-42549756c10a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ece3c2d-d38f-4c28-9b12-cc0746fca693"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fcf9ddc-5b04-47c2-9802-a738e0bbd39a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5699dc23-6429-42b2-9cf5-d51b4cd1abfe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""458d3bf5-df4e-4767-b9e0-58cdd869b2c3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9ceaa6-7734-436e-8425-df77e36dbda0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcfd7e4b-ee07-4b20-a330-d430e559d98e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e28540a0-dfc1-418d-8490-4cdd6b44771b"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""TEST"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d4314f0-b97c-4ae5-86d5-af013cdee5b9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebf32fcb-0d81-47fa-8ab9-f0c8d861c259"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a6e97b1-31f6-4fd5-bb93-43d65274dbd6"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dda5347d-c4da-4f8d-8e99-65c4feb823d6"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f43f39a-083d-4f3d-a0a6-99b221a52981"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7c169ea-8807-48c0-8ec3-b4dd4312fbd9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcddf0ee-27ce-4cbe-8acd-51b4b4aac0e5"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Quick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""870de4e6-56a1-4819-81b8-2c172795657a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Quick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a6cad82-7a40-4da8-a2ff-8798a180c0aa"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Quick3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea2ab250-b960-47d7-9230-9e05403ce949"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Quick4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""644075d9-8694-43df-8ffb-4d85e05b23fd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Slide = m_Player.FindAction("Slide", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_LeftMouse = m_Player.FindAction("LeftMouse", throwIfNotFound: true);
        m_Player_RightMouse = m_Player.FindAction("RightMouse", throwIfNotFound: true);
        m_Player_Kick = m_Player.FindAction("Kick", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Quick1 = m_Player.FindAction("Quick1", throwIfNotFound: true);
        m_Player_Quick2 = m_Player.FindAction("Quick2", throwIfNotFound: true);
        m_Player_Quick3 = m_Player.FindAction("Quick3", throwIfNotFound: true);
        m_Player_Quick4 = m_Player.FindAction("Quick4", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_TEST = m_Player.FindAction("TEST", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Slide;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_LeftMouse;
    private readonly InputAction m_Player_RightMouse;
    private readonly InputAction m_Player_Kick;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Quick1;
    private readonly InputAction m_Player_Quick2;
    private readonly InputAction m_Player_Quick3;
    private readonly InputAction m_Player_Quick4;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_TEST;
    public struct PlayerActions
    {
        private @ActionInput m_Wrapper;
        public PlayerActions(@ActionInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Slide => m_Wrapper.m_Player_Slide;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @LeftMouse => m_Wrapper.m_Player_LeftMouse;
        public InputAction @RightMouse => m_Wrapper.m_Player_RightMouse;
        public InputAction @Kick => m_Wrapper.m_Player_Kick;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Quick1 => m_Wrapper.m_Player_Quick1;
        public InputAction @Quick2 => m_Wrapper.m_Player_Quick2;
        public InputAction @Quick3 => m_Wrapper.m_Player_Quick3;
        public InputAction @Quick4 => m_Wrapper.m_Player_Quick4;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @TEST => m_Wrapper.m_Player_TEST;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Slide.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @LeftMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMouse;
                @LeftMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMouse;
                @RightMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @Kick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Quick1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick1;
                @Quick1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick1;
                @Quick1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick1;
                @Quick2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick2;
                @Quick2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick2;
                @Quick2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick2;
                @Quick3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick3;
                @Quick3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick3;
                @Quick3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick3;
                @Quick4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick4;
                @Quick4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick4;
                @Quick4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuick4;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @TEST.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTEST;
                @TEST.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTEST;
                @TEST.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTEST;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LeftMouse.started += instance.OnLeftMouse;
                @LeftMouse.performed += instance.OnLeftMouse;
                @LeftMouse.canceled += instance.OnLeftMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Quick1.started += instance.OnQuick1;
                @Quick1.performed += instance.OnQuick1;
                @Quick1.canceled += instance.OnQuick1;
                @Quick2.started += instance.OnQuick2;
                @Quick2.performed += instance.OnQuick2;
                @Quick2.canceled += instance.OnQuick2;
                @Quick3.started += instance.OnQuick3;
                @Quick3.performed += instance.OnQuick3;
                @Quick3.canceled += instance.OnQuick3;
                @Quick4.started += instance.OnQuick4;
                @Quick4.performed += instance.OnQuick4;
                @Quick4.canceled += instance.OnQuick4;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @TEST.started += instance.OnTEST;
                @TEST.performed += instance.OnTEST;
                @TEST.canceled += instance.OnTEST;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnCamera(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnQuick1(InputAction.CallbackContext context);
        void OnQuick2(InputAction.CallbackContext context);
        void OnQuick3(InputAction.CallbackContext context);
        void OnQuick4(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnTEST(InputAction.CallbackContext context);
    }
}
