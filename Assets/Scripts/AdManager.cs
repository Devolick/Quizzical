using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

//public class AdManager : MonoBehaviour {
//    static AdManager instance;
//    public Action<ShowResult> callback;
//    [SerializeField]
//    string zone = "";

//    void Awake() {
//        instance = this;
//    }
//    public static AdManager Ad {
//        get { return instance; }
//    }
//    public bool ShowAd(Action<ShowResult> cb)
//    {
//        if (!ShowAd(cb, this.zone)) // rewardVideo not loaded or not exists
//        {
//            if (ShowAd(false))
//            {
//                return true; //default
//            }
//            return false;
//        }
//        else {
//            return true; //rewardVideo
//        }
//    }
//    bool ShowAd(Action<ShowResult> cb, string zone) {
//        ShowOptions option = new ShowOptions();
//        option.resultCallback = cb;
//        if (Advertisement.IsReady(zone))
//        {
//            Advertisement.Show(zone, option);
//            return true;
//        }

//        return false;
//    }
//    public bool ShowAd(bool zoneType) {
//        if (!zoneType)
//        {
            
//            if (ShowAd(null, null))
//            {
//                return true;
//            }
//        }
//        else {
//            if (ShowAd(null, this.zone))
//            {
//                return true;
//            }
//        }

//        return false;
//    }




//}
