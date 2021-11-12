using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JEngine.Core;
using libx;
using LitJson;
using pbcmd;
using UnityEngine;

/// <summary>
/// protobuf helper
/// </summary>
public class StringifyHelper
{
    #region Protobuf

    /// <summary>
    /// 序列化并返回二进制
    /// Serialize an Object and return byte[]
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static byte[] ProtoSerialize<T>(T obj) where T : class
    {
        try
        {
            using (var stream = new System.IO.MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return null;
        }
    }

    public static PBHeader GetHeader(byte[] bytesArray)
    {
        try
        {
            int headSize = Convert.ToInt32(bytesArray[0]);
            byte[] headBytes = bytesArray.Skip(1).Take(headSize).ToArray();
            return ProtoDeSerialize<PBHeader>(headBytes);
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 获取PBHeader错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return null;
        }

    }

    /// <summary>
    /// 获取文件来反序列化（只能是可热更资源）
    /// Use file to deserialize (only hot update resources)
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T ProtoDeSerializeFromFile<T>(string path) where T : class
    {
        try
        {
            var res = Assets.LoadAsset(path, typeof(TextAsset));
            return ProtoBuf.Serializer.Deserialize(typeof(T), new System.IO.MemoryStream(res.bytes)) as T;
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return null;
        }
    }

    /// <summary>
    /// 通过二进制反序列化
    /// Deserialize with byte[]
    /// </summary>
    /// <param name="msg"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T ProtoDeSerialize<T>(byte[] msg) where T : class
    {
        try
        {
            return ProtoBuf.Serializer.Deserialize(typeof(T), new System.IO.MemoryStream(msg)) as T;
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return null;
        }
    }

    #endregion

    #region JSON

    /// <summary>
    /// 将类转换至JSON字符串
    /// Convert object to JSON string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string JSONSerliaze(object value)
    {
        try
        {
            var json = JsonMapper.ToJson(value);
            return json;
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return null;
        }
    }

    /// <summary>
    /// 将JSON字符串转类
    /// Convert JSON string to Class
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T JSONDeSerliaze<T>(string value)
    {
        try
        {
            var jsonObj = JsonMapper.ToObject<T>(value);
            return jsonObj;
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return default(T);
        }
    }

    /// <summary>
    /// 将文件中的JSON字符串转类（仅限热更资源）
    /// Convert JSON string from file to class (only hot update files)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T JSONDeSerliazeFromFile<T>(string path)
    {
        try
        {
            var res = Assets.LoadAsset(path, typeof(TextAsset));
            TextAsset textAsset = (TextAsset) res.asset;

            if (textAsset == null)
            {
                Log.PrintError("cant load TextAsset: " + path);
                return default(T);
            }

            var jsonObj = JsonMapper.ToObject<T>(textAsset.text);
            res.Release();
            return jsonObj;
        }
        catch (IOException ex)
        {
            Log.PrintError($"[StringifyHelper] 错误：{ex.Message}, {ex.Data["StackTrace"]}");
            return default(T);
        }
    }

    #endregion
}