using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

#if UNITY_IPHONE
public class FlurryAgentIOS : FlurryAgent
{

    [DllImport("__Internal")]
    private static extern void flurryStartSession(string appKey);

    [DllImport("__Internal")]
    private static extern int flurryLogEvent(string eventName);

    [DllImport("__Internal")]
    private static extern int flurryLogEventWithParameter(string eventName, string[] keys, string[] value, int size);

    [DllImport("__Internal")]
    private static extern void flurrySetUserID(string userId);

    [DllImport("__Internal")]
    private static extern void flurrySetAge(int age);

    [DllImport("__Internal")]
    private static extern void flurrySetGender(string gender);

    [DllImport("__Internal")]
    private static extern void flurryLogPageView();

    [DllImport("__Internal")]
    private static extern void flurryLogError(string errorId, string message);

    [DllImport("__Internal")]
    private static extern void flurrySetCrashReporting(bool enabled);
    
    [DllImport("__Internal")]
	  private static extern void flurrySetDebugLog(bool enabled);

    public override void onStartSession(string apiKey)
    {
        flurryStartSession(apiKey);
    }

    public override void onEndSession()
    {
        // Do Nothing
    }

    public override int logEvent(string eventId)
    {
        return flurryLogEvent(eventId);
    }

    public override int logEvent(string eventId, Hashtable parameters)
    {
        string[] keys = new string[parameters.Count];
        string[] values = new string[parameters.Count];

        int i = 0;
        foreach (DictionaryEntry kvp in parameters)
        {
            keys[i] = kvp.Key + "";
            values[i] = kvp.Value + "";
            i++;
        }
        return flurryLogEventWithParameter(eventId, keys, values, parameters.Count);
    }

    public override void onError(string errorId, string message, string errorClass)
    {
        flurryLogError(errorId, message + " \n\n " + errorClass);
    }

    public override void onPageView()
    {
        flurryLogPageView();
    }

    public override void setUserID(string userId)
    {
        flurrySetUserID(userId);
    }

    public override void setAge(int age)
    {
        flurrySetAge(age);
    }

    public override void setGender(Gender gender)
    {
        if (gender == FlurryAgent.Gender.Male)
        {
            flurrySetGender("m");
        }
        else if (gender == FlurryAgent.Gender.Female)
        {
            flurrySetGender("f");
        }
    }

    public override void setReportLocation(bool reportLocation)
    {
        Debug.Log("pending");
    }

    public override void setCrashReporting(bool enabled)
    {
        flurrySetCrashReporting(enabled);
    }
    
    public override void setDebugLog(bool enabled)
	  {
	  		flurrySetDebugLog(enabled);
	  }

    public override void Dispose() {}
};
#endif
