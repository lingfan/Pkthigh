using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {

//will auto register in unity
#if UNITY_5_3_OR_NEWER
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
#endif
        static private void RegisterBindingAction()
        {
            ILRuntime.Runtime.CLRBinding.CLRBindingUtils.RegisterBindingAction(Initialize);
        }


        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            System_Collections_Generic_Dictionary_2_String_List_1_Delegate_Binding.Register(app);
            System_Collections_Generic_List_1_Delegate_Binding.Register(app);
            System_Collections_Generic_List_1_Delegate_Binding_Enumerator_Binding.Register(app);
            System_Object_Binding.Register(app);
            System_String_Binding.Register(app);
            JEngine_Core_Log_Binding.Register(app);
            System_Array_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            System_Action_3_ILTypeInstance_Object_Object_Binding.Register(app);
            System_Action_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_UIBehaviour_Binding.Register(app);
            JEngine_Net_SocketIOComponent_Binding.Register(app);
            JEngine_Net_JSocketConfig_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            System_Action_1_SocketIOEvent_Binding.Register(app);
            System_Action_Binding.Register(app);
            System_Linq_Enumerable_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Object_List_1_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Object_List_1_ValueTuple_2_String_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Object_List_1_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_List_1_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_List_1_Object_Binding.Register(app);
            System_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            JEngine_Core_Loom_Binding.Register(app);
            System_Type_Binding.Register(app);
            UnityEngine_PlayerPrefs_Binding.Register(app);
            System_Char_Binding.Register(app);
            System_Collections_Generic_List_1_String_Binding.Register(app);
            System_Text_StringBuilder_Binding.Register(app);
            System_Exception_Binding.Register(app);
            System_Collections_IDictionary_Binding.Register(app);
            JEngine_Core_CryptoHelper_Binding.Register(app);
            System_Int32_Binding.Register(app);
            System_Int16_Binding.Register(app);
            System_Int64_Binding.Register(app);
            System_Decimal_Binding.Register(app);
            System_Double_Binding.Register(app);
            System_Single_Binding.Register(app);
            System_Boolean_Binding.Register(app);
            InitJEngine_Binding.Register(app);
            UnityEngine_Component_Binding.Register(app);
            System_Collections_Generic_List_1_GameObject_Binding.Register(app);
            UnityEngine_Application_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Activator_Binding.Register(app);
            JEngine_Core_ClassData_Binding.Register(app);
            JEngine_Core_ClassBind_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            JEngine_Core_Tools_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncVoidMethodBuilder_Binding.Register(app);
            System_Threading_CancellationTokenSource_Binding.Register(app);
            System_Guid_Binding.Register(app);
            UnityEngine_MonoBehaviour_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_String_ILTypeInstance_Binding.Register(app);
            System_NotSupportedException_Binding.Register(app);
            System_Threading_Tasks_Task_Binding.Register(app);
            System_Runtime_CompilerServices_TaskAwaiter_Binding.Register(app);
            System_Diagnostics_Stopwatch_Binding.Register(app);
            JEngine_Core_GameStats_Binding.Register(app);
            JEngine_Core_AssetMgr_Binding.Register(app);
            System_Collections_Generic_List_1_Action_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Single_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Func_1_Boolean_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Action_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncTaskMethodBuilder_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_List_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_GC_Binding.Register(app);
            System_Func_1_Boolean_Binding.Register(app);
            System_Threading_Tasks_Task_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Runtime_CompilerServices_TaskAwaiter_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_TimeoutException_Binding.Register(app);
            libx_AssetRequest_Binding.Register(app);
            libx_Reference_Binding.Register(app);
            libx_Assets_Binding.Register(app);
            System_Action_2_Boolean_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            pbcmd_PBReqAccountMobileSecret_Binding.Register(app);
            Module_Network_PBSocket_PBPacket_1_PBRespAccountMobileSecret_Binding.Register(app);
            pbcmd_PBRespAccountMobileSecret_Binding.Register(app);
            pbcmd_PBCommResult_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding.Register(app);
            PbcmdHelper_Binding.Register(app);
            pbcmd_PBReqAccountMobileAuth_Binding.Register(app);
            Module_Network_PBSocket_PBPacket_1_PBRespAccountMobileAuth_Binding.Register(app);
            pbcmd_PBRespAccountMobileAuth_Binding.Register(app);
            pbcmd_PBReqAccountLogin_Binding.Register(app);
            Module_Network_PBSocket_PBPacket_1_PBRespAccountLogin_Binding.Register(app);
            pbcmd_PBRespAccountLogin_Binding.Register(app);
            pbcmd_PBReqAccountMobileCode_Binding.Register(app);
            Module_Network_PBSocket_PBPacket_1_PBRespAccountMobileCode_Binding.Register(app);
            pbcmd_PBRespAccountMobileCode_Binding.Register(app);
            UnityEngine_UI_Text_Binding.Register(app);
            JEngine_Core_Localization_Binding.Register(app);
            UnityEngine_LayerMask_Binding.Register(app);
            UnityEngine_Transform_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_MonoBehaviourAdapter_Binding_Adaptor_Binding.Register(app);
            UIConfig_Binding.Register(app);
            System_Collections_Generic_Stack_1_MonoBehaviourAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_MonoBehaviourAdapter_Binding_Adaptor_Binding_ValueCollection_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_MonoBehaviourAdapter_Binding_Adaptor_Binding_ValueCollection_Binding_Enumerator_Binding.Register(app);
            UnityEngine_Resources_Binding.Register(app);
            System_Action_1_GameObject_Binding.Register(app);
            System_Action_1_MonoBehaviourAdapter_Binding_Adaptor_Binding.Register(app);
            System_Byte_Binding.Register(app);
            System_Security_Cryptography_RSAParameters_Binding.Register(app);
            WebSocketSharp_MessageEventArgs_Binding.Register(app);
            StringifyHelper_Binding.Register(app);
            pbcmd_PBHeader_Binding.Register(app);
            System_Enum_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
        }
    }
}
