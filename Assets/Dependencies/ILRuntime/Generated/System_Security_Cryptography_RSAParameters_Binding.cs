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
    unsafe class System_Security_Cryptography_RSAParameters_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(System.Security.Cryptography.RSAParameters);

            field = type.GetField("Exponent", flag);
            app.RegisterCLRFieldGetter(field, get_Exponent_0);
            app.RegisterCLRFieldSetter(field, set_Exponent_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Exponent_0, AssignFromStack_Exponent_0);
            field = type.GetField("Modulus", flag);
            app.RegisterCLRFieldGetter(field, get_Modulus_1);
            app.RegisterCLRFieldSetter(field, set_Modulus_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Modulus_1, AssignFromStack_Modulus_1);

            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new System.Security.Cryptography.RSAParameters());


        }

        static void WriteBackInstance(ILRuntime.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref System.Security.Cryptography.RSAParameters instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as System.Security.Cryptography.RSAParameters[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Exponent_0(ref object o)
        {
            return ((System.Security.Cryptography.RSAParameters)o).Exponent;
        }

        static StackObject* CopyToStack_Exponent_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.Security.Cryptography.RSAParameters)o).Exponent;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Exponent_0(ref object o, object v)
        {
            System.Security.Cryptography.RSAParameters ins =(System.Security.Cryptography.RSAParameters)o;
            ins.Exponent = (System.Byte[])v;
            o = ins;
        }

        static StackObject* AssignFromStack_Exponent_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Byte[] @Exponent = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            System.Security.Cryptography.RSAParameters ins =(System.Security.Cryptography.RSAParameters)o;
            ins.Exponent = @Exponent;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Modulus_1(ref object o)
        {
            return ((System.Security.Cryptography.RSAParameters)o).Modulus;
        }

        static StackObject* CopyToStack_Modulus_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.Security.Cryptography.RSAParameters)o).Modulus;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Modulus_1(ref object o, object v)
        {
            System.Security.Cryptography.RSAParameters ins =(System.Security.Cryptography.RSAParameters)o;
            ins.Modulus = (System.Byte[])v;
            o = ins;
        }

        static StackObject* AssignFromStack_Modulus_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Byte[] @Modulus = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            System.Security.Cryptography.RSAParameters ins =(System.Security.Cryptography.RSAParameters)o;
            ins.Modulus = @Modulus;
            o = ins;
            return ptr_of_this_method;
        }


        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new System.Security.Cryptography.RSAParameters();
            ins = (System.Security.Cryptography.RSAParameters)o;
            return ins;
        }


    }
}
