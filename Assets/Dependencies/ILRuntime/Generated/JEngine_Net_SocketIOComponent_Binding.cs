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
    unsafe class JEngine_Net_SocketIOComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(JEngine.Net.SocketIOComponent);
            args = new Type[]{};
            method = type.GetMethod("get_IsConnected", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsConnected_0);
            args = new Type[]{};
            method = type.GetMethod("Connect", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Connect_1);
            args = new Type[]{typeof(System.String), typeof(System.Action<JEngine.Net.SocketIOEvent>)};
            method = type.GetMethod("On", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, On_2);
            Dictionary<string, List<MethodInfo>> genericMethods = new Dictionary<string, List<MethodInfo>>();
            List<MethodInfo> lst = null;                    
            foreach(var m in type.GetMethods())
            {
                if(m.IsGenericMethodDefinition)
                {
                    if (!genericMethods.TryGetValue(m.Name, out lst))
                    {
                        lst = new List<MethodInfo>();
                        genericMethods[m.Name] = lst;
                    }
                    lst.Add(m);
                }
            }
            args = new Type[]{typeof(pbcmd.PBReqAccountMobileSecret), typeof(pbcmd.PBRespAccountMobileSecret)};
            if (genericMethods.TryGetValue("Emit", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(void), typeof(pbcmd.PBMainCmd), typeof(System.Enum), typeof(pbcmd.PBReqAccountMobileSecret), typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileSecret>>), typeof(System.Action<global::PbcmdHelper.PbSocketEvent>), typeof(pbcmd.PBMatchIndex)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, Emit_3);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(pbcmd.PBReqAccountMobileAuth), typeof(pbcmd.PBRespAccountMobileAuth)};
            if (genericMethods.TryGetValue("Emit", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(void), typeof(pbcmd.PBMainCmd), typeof(System.Enum), typeof(pbcmd.PBReqAccountMobileAuth), typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileAuth>>), typeof(System.Action<global::PbcmdHelper.PbSocketEvent>), typeof(pbcmd.PBMatchIndex)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, Emit_4);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(pbcmd.PBReqAccountLogin), typeof(pbcmd.PBRespAccountLogin)};
            if (genericMethods.TryGetValue("Emit", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(void), typeof(pbcmd.PBMainCmd), typeof(System.Enum), typeof(pbcmd.PBReqAccountLogin), typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountLogin>>), typeof(System.Action<global::PbcmdHelper.PbSocketEvent>), typeof(pbcmd.PBMatchIndex)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, Emit_5);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(pbcmd.PBReqAccountMobileCode), typeof(pbcmd.PBRespAccountMobileCode)};
            if (genericMethods.TryGetValue("EmitAsync", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(void), typeof(pbcmd.PBMainCmd), typeof(System.Enum), typeof(pbcmd.PBReqAccountMobileCode), typeof(System.Action<System.Boolean>), typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileCode>>), typeof(System.Action<global::PbcmdHelper.PbSocketEvent>), typeof(pbcmd.PBMatchIndex)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, EmitAsync_6);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(System.String), typeof(JEngine.Net.JSocketConfig), typeof(System.Action<System.Object, WebSocketSharp.MessageEventArgs>)};
            method = type.GetMethod("Init", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Init_7);

            field = type.GetField("config", flag);
            app.RegisterCLRFieldGetter(field, get_config_0);
            app.RegisterCLRFieldSetter(field, set_config_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_config_0, AssignFromStack_config_0);


        }


        static StackObject* get_IsConnected_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsConnected;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* Connect_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Connect();

            return __ret;
        }

        static StackObject* On_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<JEngine.Net.SocketIOEvent> @callback = (System.Action<JEngine.Net.SocketIOEvent>)typeof(System.Action<JEngine.Net.SocketIOEvent>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @ev = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.On(@ev, @callback);

            return __ret;
        }

        static StackObject* Emit_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 7);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            pbcmd.PBMatchIndex @idx = (pbcmd.PBMatchIndex)typeof(pbcmd.PBMatchIndex).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Action<global::PbcmdHelper.PbSocketEvent> @onError = (System.Action<global::PbcmdHelper.PbSocketEvent>)typeof(System.Action<global::PbcmdHelper.PbSocketEvent>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileSecret>> @action = (System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileSecret>>)typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileSecret>>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            pbcmd.PBReqAccountMobileSecret @pbBody = (pbcmd.PBReqAccountMobileSecret)typeof(pbcmd.PBReqAccountMobileSecret).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            System.Enum @subCmd = (System.Enum)typeof(System.Enum).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 6);
            pbcmd.PBMainCmd @mainCmd = (pbcmd.PBMainCmd)typeof(pbcmd.PBMainCmd).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 7);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Emit<pbcmd.PBReqAccountMobileSecret, pbcmd.PBRespAccountMobileSecret>(@mainCmd, @subCmd, @pbBody, @action, @onError, @idx);

            return __ret;
        }

        static StackObject* Emit_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 7);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            pbcmd.PBMatchIndex @idx = (pbcmd.PBMatchIndex)typeof(pbcmd.PBMatchIndex).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Action<global::PbcmdHelper.PbSocketEvent> @onError = (System.Action<global::PbcmdHelper.PbSocketEvent>)typeof(System.Action<global::PbcmdHelper.PbSocketEvent>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileAuth>> @action = (System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileAuth>>)typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileAuth>>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            pbcmd.PBReqAccountMobileAuth @pbBody = (pbcmd.PBReqAccountMobileAuth)typeof(pbcmd.PBReqAccountMobileAuth).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            System.Enum @subCmd = (System.Enum)typeof(System.Enum).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 6);
            pbcmd.PBMainCmd @mainCmd = (pbcmd.PBMainCmd)typeof(pbcmd.PBMainCmd).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 7);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Emit<pbcmd.PBReqAccountMobileAuth, pbcmd.PBRespAccountMobileAuth>(@mainCmd, @subCmd, @pbBody, @action, @onError, @idx);

            return __ret;
        }

        static StackObject* Emit_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 7);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            pbcmd.PBMatchIndex @idx = (pbcmd.PBMatchIndex)typeof(pbcmd.PBMatchIndex).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Action<global::PbcmdHelper.PbSocketEvent> @onError = (System.Action<global::PbcmdHelper.PbSocketEvent>)typeof(System.Action<global::PbcmdHelper.PbSocketEvent>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountLogin>> @action = (System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountLogin>>)typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountLogin>>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            pbcmd.PBReqAccountLogin @pbBody = (pbcmd.PBReqAccountLogin)typeof(pbcmd.PBReqAccountLogin).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            System.Enum @subCmd = (System.Enum)typeof(System.Enum).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 6);
            pbcmd.PBMainCmd @mainCmd = (pbcmd.PBMainCmd)typeof(pbcmd.PBMainCmd).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 7);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Emit<pbcmd.PBReqAccountLogin, pbcmd.PBRespAccountLogin>(@mainCmd, @subCmd, @pbBody, @action, @onError, @idx);

            return __ret;
        }

        static StackObject* EmitAsync_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 8);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            pbcmd.PBMatchIndex @idx = (pbcmd.PBMatchIndex)typeof(pbcmd.PBMatchIndex).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Action<global::PbcmdHelper.PbSocketEvent> @onError = (System.Action<global::PbcmdHelper.PbSocketEvent>)typeof(System.Action<global::PbcmdHelper.PbSocketEvent>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileCode>> @action = (System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileCode>>)typeof(System.Action<Module.Network.PBSocket.PBPacket<pbcmd.PBRespAccountMobileCode>>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.Action<System.Boolean> @onComplete = (System.Action<System.Boolean>)typeof(System.Action<System.Boolean>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            pbcmd.PBReqAccountMobileCode @pbBody = (pbcmd.PBReqAccountMobileCode)typeof(pbcmd.PBReqAccountMobileCode).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 6);
            System.Enum @subCmd = (System.Enum)typeof(System.Enum).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 7);
            pbcmd.PBMainCmd @mainCmd = (pbcmd.PBMainCmd)typeof(pbcmd.PBMainCmd).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 8);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.EmitAsync<pbcmd.PBReqAccountMobileCode, pbcmd.PBRespAccountMobileCode>(@mainCmd, @subCmd, @pbBody, @onComplete, @action, @onError, @idx);

            return __ret;
        }

        static StackObject* Init_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<System.Object, WebSocketSharp.MessageEventArgs> @onMessage = (System.Action<System.Object, WebSocketSharp.MessageEventArgs>)typeof(System.Action<System.Object, WebSocketSharp.MessageEventArgs>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            JEngine.Net.JSocketConfig @config = (JEngine.Net.JSocketConfig)typeof(JEngine.Net.JSocketConfig).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @url = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            JEngine.Net.SocketIOComponent instance_of_this_method = (JEngine.Net.SocketIOComponent)typeof(JEngine.Net.SocketIOComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Init(@url, @config, @onMessage);

            return __ret;
        }


        static object get_config_0(ref object o)
        {
            return ((JEngine.Net.SocketIOComponent)o).config;
        }

        static StackObject* CopyToStack_config_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((JEngine.Net.SocketIOComponent)o).config;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_config_0(ref object o, object v)
        {
            ((JEngine.Net.SocketIOComponent)o).config = (JEngine.Net.JSocketConfig)v;
        }

        static StackObject* AssignFromStack_config_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            JEngine.Net.JSocketConfig @config = (JEngine.Net.JSocketConfig)typeof(JEngine.Net.JSocketConfig).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((JEngine.Net.SocketIOComponent)o).config = @config;
            return ptr_of_this_method;
        }



    }
}
