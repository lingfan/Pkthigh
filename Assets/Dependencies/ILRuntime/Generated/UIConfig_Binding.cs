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
    unsafe class UIConfig_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(global::UIConfig);

            field = type.GetField("uiLayer", flag);
            app.RegisterCLRFieldGetter(field, get_uiLayer_0);
            app.RegisterCLRFieldSetter(field, set_uiLayer_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_uiLayer_0, AssignFromStack_uiLayer_0);
            field = type.GetField("uiType", flag);
            app.RegisterCLRFieldGetter(field, get_uiType_1);
            app.RegisterCLRFieldSetter(field, set_uiType_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_uiType_1, AssignFromStack_uiType_1);
            field = type.GetField("isHotUpdateResources", flag);
            app.RegisterCLRFieldGetter(field, get_isHotUpdateResources_2);
            app.RegisterCLRFieldSetter(field, set_isHotUpdateResources_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_isHotUpdateResources_2, AssignFromStack_isHotUpdateResources_2);
            field = type.GetField("loadPath", flag);
            app.RegisterCLRFieldGetter(field, get_loadPath_3);
            app.RegisterCLRFieldSetter(field, set_loadPath_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_loadPath_3, AssignFromStack_loadPath_3);


        }



        static object get_uiLayer_0(ref object o)
        {
            return ((global::UIConfig)o).uiLayer;
        }

        static StackObject* CopyToStack_uiLayer_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::UIConfig)o).uiLayer;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_uiLayer_0(ref object o, object v)
        {
            ((global::UIConfig)o).uiLayer = (global::UIConfig.Layer)v;
        }

        static StackObject* AssignFromStack_uiLayer_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::UIConfig.Layer @uiLayer = (global::UIConfig.Layer)typeof(global::UIConfig.Layer).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            ((global::UIConfig)o).uiLayer = @uiLayer;
            return ptr_of_this_method;
        }

        static object get_uiType_1(ref object o)
        {
            return ((global::UIConfig)o).uiType;
        }

        static StackObject* CopyToStack_uiType_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::UIConfig)o).uiType;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_uiType_1(ref object o, object v)
        {
            ((global::UIConfig)o).uiType = (global::UIConfig.UIType)v;
        }

        static StackObject* AssignFromStack_uiType_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::UIConfig.UIType @uiType = (global::UIConfig.UIType)typeof(global::UIConfig.UIType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)20);
            ((global::UIConfig)o).uiType = @uiType;
            return ptr_of_this_method;
        }

        static object get_isHotUpdateResources_2(ref object o)
        {
            return ((global::UIConfig)o).isHotUpdateResources;
        }

        static StackObject* CopyToStack_isHotUpdateResources_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::UIConfig)o).isHotUpdateResources;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_isHotUpdateResources_2(ref object o, object v)
        {
            ((global::UIConfig)o).isHotUpdateResources = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_isHotUpdateResources_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @isHotUpdateResources = ptr_of_this_method->Value == 1;
            ((global::UIConfig)o).isHotUpdateResources = @isHotUpdateResources;
            return ptr_of_this_method;
        }

        static object get_loadPath_3(ref object o)
        {
            return ((global::UIConfig)o).loadPath;
        }

        static StackObject* CopyToStack_loadPath_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::UIConfig)o).loadPath;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_loadPath_3(ref object o, object v)
        {
            ((global::UIConfig)o).loadPath = (System.String)v;
        }

        static StackObject* AssignFromStack_loadPath_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @loadPath = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ((global::UIConfig)o).loadPath = @loadPath;
            return ptr_of_this_method;
        }



    }
}
