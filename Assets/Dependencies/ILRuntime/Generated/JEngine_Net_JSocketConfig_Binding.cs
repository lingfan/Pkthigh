using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class JEngine_Net_JSocketConfig_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(JEngine.Net.JSocketConfig);

            field = type.GetField("eventOpenName", flag);
            app.RegisterCLRFieldGetter(field, get_eventOpenName_0);
            app.RegisterCLRFieldSetter(field, set_eventOpenName_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventOpenName_0, AssignFromStack_eventOpenName_0);
            field = type.GetField("eventConnectName", flag);
            app.RegisterCLRFieldGetter(field, get_eventConnectName_1);
            app.RegisterCLRFieldSetter(field, set_eventConnectName_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventConnectName_1, AssignFromStack_eventConnectName_1);
            field = type.GetField("eventDisconnectName", flag);
            app.RegisterCLRFieldGetter(field, get_eventDisconnectName_2);
            app.RegisterCLRFieldSetter(field, set_eventDisconnectName_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventDisconnectName_2, AssignFromStack_eventDisconnectName_2);
            field = type.GetField("eventCloseName", flag);
            app.RegisterCLRFieldGetter(field, get_eventCloseName_3);
            app.RegisterCLRFieldSetter(field, set_eventCloseName_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventCloseName_3, AssignFromStack_eventCloseName_3);
            field = type.GetField("eventErrorName", flag);
            app.RegisterCLRFieldGetter(field, get_eventErrorName_4);
            app.RegisterCLRFieldSetter(field, set_eventErrorName_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventErrorName_4, AssignFromStack_eventErrorName_4);
            field = type.GetField("eventHeartBeatTimeoutName", flag);
            app.RegisterCLRFieldGetter(field, get_eventHeartBeatTimeoutName_5);
            app.RegisterCLRFieldSetter(field, set_eventHeartBeatTimeoutName_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_eventHeartBeatTimeoutName_5, AssignFromStack_eventHeartBeatTimeoutName_5);
            field = type.GetField("pingInterval", flag);
            app.RegisterCLRFieldGetter(field, get_pingInterval_6);
            app.RegisterCLRFieldSetter(field, set_pingInterval_6);
            app.RegisterCLRFieldBinding(field, CopyToStack_pingInterval_6, AssignFromStack_pingInterval_6);
            field = type.GetField("pingTimeout", flag);
            app.RegisterCLRFieldGetter(field, get_pingTimeout_7);
            app.RegisterCLRFieldSetter(field, set_pingTimeout_7);
            app.RegisterCLRFieldBinding(field, CopyToStack_pingTimeout_7, AssignFromStack_pingTimeout_7);
            field = type.GetField("ackExpirationTime", flag);
            app.RegisterCLRFieldGetter(field, get_ackExpirationTime_8);
            app.RegisterCLRFieldSetter(field, set_ackExpirationTime_8);
            app.RegisterCLRFieldBinding(field, CopyToStack_ackExpirationTime_8, AssignFromStack_ackExpirationTime_8);
            field = type.GetField("reconnectDelay", flag);
            app.RegisterCLRFieldGetter(field, get_reconnectDelay_9);
            app.RegisterCLRFieldSetter(field, set_reconnectDelay_9);
            app.RegisterCLRFieldBinding(field, CopyToStack_reconnectDelay_9, AssignFromStack_reconnectDelay_9);
            field = type.GetField("encrypt", flag);
            app.RegisterCLRFieldGetter(field, get_encrypt_10);
            app.RegisterCLRFieldSetter(field, set_encrypt_10);
            app.RegisterCLRFieldBinding(field, CopyToStack_encrypt_10, AssignFromStack_encrypt_10);
            field = type.GetField("debug", flag);
            app.RegisterCLRFieldGetter(field, get_debug_11);
            app.RegisterCLRFieldSetter(field, set_debug_11);
            app.RegisterCLRFieldBinding(field, CopyToStack_debug_11, AssignFromStack_debug_11);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }



        static object get_eventOpenName_0(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventOpenName;
        }

        static StackObject* CopyToStack_eventOpenName_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventOpenName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventOpenName_0(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventOpenName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventOpenName_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventOpenName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventOpenName = @eventOpenName;
            return ptr_of_this_method;
        }

        static object get_eventConnectName_1(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventConnectName;
        }

        static StackObject* CopyToStack_eventConnectName_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventConnectName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventConnectName_1(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventConnectName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventConnectName_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventConnectName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventConnectName = @eventConnectName;
            return ptr_of_this_method;
        }

        static object get_eventDisconnectName_2(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventDisconnectName;
        }

        static StackObject* CopyToStack_eventDisconnectName_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventDisconnectName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventDisconnectName_2(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventDisconnectName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventDisconnectName_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventDisconnectName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventDisconnectName = @eventDisconnectName;
            return ptr_of_this_method;
        }

        static object get_eventCloseName_3(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventCloseName;
        }

        static StackObject* CopyToStack_eventCloseName_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventCloseName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventCloseName_3(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventCloseName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventCloseName_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventCloseName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventCloseName = @eventCloseName;
            return ptr_of_this_method;
        }

        static object get_eventErrorName_4(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventErrorName;
        }

        static StackObject* CopyToStack_eventErrorName_4(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventErrorName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventErrorName_4(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventErrorName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventErrorName_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventErrorName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventErrorName = @eventErrorName;
            return ptr_of_this_method;
        }

        static object get_eventHeartBeatTimeoutName_5(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).eventHeartBeatTimeoutName;
        }

        static StackObject* CopyToStack_eventHeartBeatTimeoutName_5(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).eventHeartBeatTimeoutName;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_eventHeartBeatTimeoutName_5(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).eventHeartBeatTimeoutName = (System.String)v;
        }

        static StackObject* AssignFromStack_eventHeartBeatTimeoutName_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @eventHeartBeatTimeoutName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.JSocketConfig)o).eventHeartBeatTimeoutName = @eventHeartBeatTimeoutName;
            return ptr_of_this_method;
        }

        static object get_pingInterval_6(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).pingInterval;
        }

        static StackObject* CopyToStack_pingInterval_6(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).pingInterval;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_pingInterval_6(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).pingInterval = (System.Single)v;
        }

        static StackObject* AssignFromStack_pingInterval_6(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @pingInterval = *(float*)&ptr_of_this_method->Value;
            ((JEngine.Net.JSocketConfig)o).pingInterval = @pingInterval;
            return ptr_of_this_method;
        }

        static object get_pingTimeout_7(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).pingTimeout;
        }

        static StackObject* CopyToStack_pingTimeout_7(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).pingTimeout;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_pingTimeout_7(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).pingTimeout = (System.Single)v;
        }

        static StackObject* AssignFromStack_pingTimeout_7(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @pingTimeout = *(float*)&ptr_of_this_method->Value;
            ((JEngine.Net.JSocketConfig)o).pingTimeout = @pingTimeout;
            return ptr_of_this_method;
        }

        static object get_ackExpirationTime_8(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).ackExpirationTime;
        }

        static StackObject* CopyToStack_ackExpirationTime_8(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).ackExpirationTime;
            __ret->ObjectType = ObjectTypes.Float;
            *(float*)&__ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_ackExpirationTime_8(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).ackExpirationTime = (System.Single)v;
        }

        static StackObject* AssignFromStack_ackExpirationTime_8(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Single @ackExpirationTime = *(float*)&ptr_of_this_method->Value;
            ((JEngine.Net.JSocketConfig)o).ackExpirationTime = @ackExpirationTime;
            return ptr_of_this_method;
        }

        static object get_reconnectDelay_9(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).reconnectDelay;
        }

        static StackObject* CopyToStack_reconnectDelay_9(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).reconnectDelay;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_reconnectDelay_9(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).reconnectDelay = (System.Int32)v;
        }

        static StackObject* AssignFromStack_reconnectDelay_9(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @reconnectDelay = ptr_of_this_method->Value;
            ((JEngine.Net.JSocketConfig)o).reconnectDelay = @reconnectDelay;
            return ptr_of_this_method;
        }

        static object get_encrypt_10(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).encrypt;
        }

        static StackObject* CopyToStack_encrypt_10(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).encrypt;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = (int)result_of_this_method;
            return __ret + 1;
        }

        static void set_encrypt_10(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).encrypt = (System.UInt32)v;
        }

        static StackObject* AssignFromStack_encrypt_10(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.UInt32 @encrypt = (uint)ptr_of_this_method->Value;
            ((JEngine.Net.JSocketConfig)o).encrypt = @encrypt;
            return ptr_of_this_method;
        }

        static object get_debug_11(ref object o)
        {
            return ((JEngine.Net.JSocketConfig)o).debug;
        }

        static StackObject* CopyToStack_debug_11(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.JSocketConfig)o).debug;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_debug_11(ref object o, object v)
        {
            ((JEngine.Net.JSocketConfig)o).debug = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_debug_11(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @debug = ptr_of_this_method->Value == 1;
            ((JEngine.Net.JSocketConfig)o).debug = @debug;
            return ptr_of_this_method;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new JEngine.Net.JSocketConfig();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
