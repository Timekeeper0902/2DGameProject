using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// PlayerPrefs数据管理类
/// </summary>
public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataMgr()
    {

    }

    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据对象的唯一Key</param>
    public void SaveData(object data,string keyName)
    {
        //就是要通过 Type得到传入数据对象的所有的字段
        //然后结合PlayerPrefs来进行存储

        #region 获取传入数据对象的所有字段
        Type dataType = data.GetType();
        //得到所有字段
        
        FieldInfo[] infos = dataType.GetFields();

        #endregion

        #region 自己定义一个Key的规则 进行数据存储
        //我们存储都是通过PlayerPrefs来进行存储的
        //保证Key的唯一性 我们需要自己定一个Key的规则

        //定义一个规则：
        //keyname_数据类型_字段类型_字段名
        #endregion

        #region 遍历这些字段 进行数据存储
        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //对每一个字段进行数据存储
            //得到具体的字段信息
            info = infos[i];
            //通过FieldInfo可以直接获取到字段的类型和字段的名字
            //字段 的类型 ： info.FieldType.Name;
            //字段的名字： info.Name
            //Player1_PlayerInfo
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //如何获取值
            //info.GetValue(data);
            //封装一个方法用来存储值
            SaveValue(info.GetValue(data), saveKeyName);
        }

        PlayerPrefs.Save();
        #endregion
    }

    private void SaveValue(object value, string keyName)
    {
        //直接通过PlayerPrefs存储了
        //就是根据数据类型的不同来决定根据哪一个Api进行存储
        //判断是什么类型
        Type fieldType = value.GetType();

        //类型判断
        if(fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if(fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if(fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //如何判断 泛型类的类型
        //判断父子关系：
        //判断字段是不是IList的子类
        else if(typeof(IList).IsAssignableFrom(fieldType))
        {
            //父类装子类
            IList list = value as IList;
            //先存储数量
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                //存储具体的值
                SaveValue(obj, keyName + index);
                ++index;
            }
        }

        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            //父类装子类
            IDictionary dic = value as IDictionary;
            //先存字典长度
            PlayerPrefs.SetInt(keyName, dic.Count);
            //遍历存储DIc里面的具体值
            int index = 0;
            foreach(object key in dic.Keys)
            {
                //存key
                SaveValue(key, keyName + "_key_" + index);
                //存值
                SaveValue(dic[key], keyName + "_value_" + index);
                ++index;
            }
        }
        //如果基础类型都不是，那就是自定义类型
        else
        {
            SaveData(value, keyName);
        }
    }


    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的数据类型</param>
    /// <param name="keyName">数据对象的唯一Key</param>
    /// <returns></returns>
    public object LoadData(Type type,string keyName)
    {
        //不用object传入而改用Type,是为了节约一行代码
        //假设现在你要读取一个Player类型的数据 如果是object 你就必须在外部new一个对象传入
        //现在有Type的你只用传入一个Type typeof(Player）然后我在内部动态创建一个对象给你返回出来
        //达到了 让你在外部 少写一行代码的作用

        //根据你传入的类型和keyName
        //依据你存储数据时key的拼接规则来进行数据的获取赋值返回出去

        //根据传入的Type创建一个对象用于存储数据
        //快速实例化对象
        object data = Activator.CreateInstance(type);
        //要往new出来的对象中存储数据 填充数据
        //得到所有字段
        FieldInfo[] infos = type.GetFields();
        //用于拼接Key的字符串
        string loadKeyName = "";
        //用于存储单个字段信息的对象
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            info = infos[i];
            loadKeyName = keyName + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //有key就可以结合PlayerPrefs来读取数据
            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }


        return data;
    }

    /// <summary>
    /// 得到单个数据的方法
    /// </summary>
    /// <param name="fieldType">字段类型 用于判断使用哪个api</param>
    /// <param name="keyName">数据对象的唯一Key 自己控制</param>
    /// <returns></returns>
    private object LoadValue(Type fieldType, string keyName)
    {
        //根据字段类型来判断用哪个Api
        if(fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName,0);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName, 0);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName, "");
        }
        else if (fieldType == typeof(bool))
        {
            //根据自定义bool的规则来读取bool值
            return PlayerPrefs.GetInt(keyName, 0) == 1 ? true : false;
        }

        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            //得到长度
            int count = PlayerPrefs.GetInt(keyName, 0);
            //实例化list对象进行赋值
            IList list = Activator.CreateInstance(fieldType) as IList;

            for (int i = 0; i < count; i++)
            {
                //fieldType.GetGenericArguments()[0]得到泛型类型
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }

        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int count = PlayerPrefs.GetInt(keyName, 0);
            IDictionary dictionary = Activator.CreateInstance(fieldType) as IDictionary;
            Type[] kvType = fieldType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dictionary.Add(LoadValue(kvType[0], keyName + "_key_" + i),
                    LoadValue(kvType[1], keyName + "_value_" + i));
            }
            return dictionary;
        }

        else
        {
            return LoadData(fieldType, keyName);
        }

    }
}
