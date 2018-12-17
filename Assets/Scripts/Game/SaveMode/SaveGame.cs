using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveGame:Base {

    public SaveList OpenSave(int index) {
        SaveList save = new SaveList();
        List<SaveList> list = null;
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            list = new List<SaveList>();
            FileStream st = File.Create(Application.persistentDataPath + "/save.dat");
            bf.Serialize(st, list);
            st.Close();
        }
        else
        {
            FileStream st = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open, FileAccess.Read);
            list = bf.Deserialize(st) as List<SaveList>;
            st.Close();
            if (list.Count > 0)
            {
                save = list[index];
            }
        }
        return save;
    }
    public bool OpenSave(out List<SaveList> list)
    {
        list = null;
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            list = new List<SaveList>();
            FileStream st = File.Create(Application.persistentDataPath + "/save.dat");
            bf.Serialize(st, list);
            st.Close();
        }
        else
        {
            FileStream st = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open, FileAccess.Read);
            list = bf.Deserialize(st) as List<SaveList>;
            st.Close();
            return true;
        }
        return false;
    }
    public int Save(SaveList sl) {
        List<SaveList> list = null;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream st = null;
        if (!File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            list = new List<SaveList>();
            st = File.Create(Application.persistentDataPath + "/save.dat");
            bf.Serialize(st, list);
            st.Close();
        }
        st = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open, FileAccess.Read);
        list = bf.Deserialize(st) as List<SaveList>;
        st.Close();
        int index = SaveAddFilter(list, sl);
        st = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Create, FileAccess.Write);
        bf.Serialize(st, list);
        st.Close();

        return index;
    }
    void Sort(List<SaveList> list) {
        for (int i = 1; i < list.Count - 1; ++i)
        {
            for (int u = 0; u < list.Count - i; ++u)
            {
                if (list[u].Level > list[u + 1].Level)
                {
                    SaveList temp = list[u];
                    list[u] = list[u + 1];
                    list[u + 1] = temp;
                }
            }
        }
        list.Reverse();
    }
    int SaveAddFilter(List<SaveList> list, SaveList sl)
    {
        Debug.Log("SaveFilter");
        bool exist = false;
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ContainsItems(sl)) {
                list[i] = sl;
                exist = true;
                break;
            }
        }
        if (sl.PlayItems.Count > 0 && !exist)
        {
            list.Add(sl);
        }
        Sort(list);
        for (int i = 0; i < list.Count; ++i)
        {
            Debug.Log("Sort index :"+i+" level:"+list[i].Level);
        }
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].Equals(sl)) {
                return i;
            }
        }

        return list.Count-1;
    }

















}

