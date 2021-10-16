//
// AutoBindDemo.cs
//
// Author:
//       JasonXuDeveloper（傑） <jasonxudeveloper@gmail.com>
//
// Copyright (c) 2020 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using JEngine.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JEngine.Examples
{
    public class AutoBindDemo1 : JBehaviour
    {
        public int IntField1;

        public string StringField1;

        public EventSystem EventSystemField1;

        public GameObject GameObjectField1;

        public bool BoolProperty
        {
            get => BoolPropertyInstance;
            set => BoolPropertyInstance = value;
        }

        [SerializeField] private bool BoolPropertyInstance;

        private AutoBindDemo2[] a2 = null;


        public override void Init()
        {
            Log.Print("[Autobind] AutoBindDemo1::Inited");
            GameObjectField1.SetActive(!GameObjectField1.activeSelf);
            Log.Print($"[Autobind] a2[0] is null? {a2[0] is null}");
        }
    }

    public class AutoBindDemo2 : MonoBehaviour
    {
        public TextAsset txtFile;

        AutoBindDemo1 a1 = null;

        [HideInInspector]public float floatField;

        public List<DataClass> objList;

        public List<GameObject> goList;

        public Transform[] tranList;

        public DataClass[] hotDataList;

        public string[] vs;
        public List<int> vss;

        public void Awake()
        {
            Log.Print("[Autobind] AutoBindDemo2::Awake");
            Log.Print($"[Autobind] txtFile value is: {txtFile.text}");
            Log.Print($"[Autobind] a1 is null? {a1 is null}");
            Log.Print($"[Autobind] floatField: {floatField}");
            Log.Print($"[Autobind] objList.Count: {objList.Count}");
            Log.Print($"[Autobind] objList[1] should be null, is it? {objList[1] == null}");
            Log.Print($"[Autobind] goList.Count: {goList.Count}");
            Log.Print($"[Autobind] tranList.Length: {tranList.Length}");
            Log.Print($"[Autobind] hotDataList.Length: {hotDataList.Length}");
            Log.Print($"[Autobind] vs: {string.Join(", ",vs)}");
            Log.Print($"[Autobind] vss: {string.Join(", ",vss)}");
        }
    }
}
