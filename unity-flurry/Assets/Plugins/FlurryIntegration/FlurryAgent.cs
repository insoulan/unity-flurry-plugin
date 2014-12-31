using System;
using System.Collections;

public abstract class FlurryAgent : IDisposable
{
    abstract public void onStartSession(string apiKey);

    abstract public void onEndSession();

    abstract public int  logEvent(string eventId);

    abstract public int  logEvent(string eventId, Hashtable parameters);

    abstract public void onError(string errorId, string message, string errorClass);

    abstract public void onPageView();

    abstract public void setUserID(string userId);

    abstract public void setAge(int age);

    public enum Gender
    {
        Male,
        Female
    }

    abstract public void setGender(Gender gender);

    abstract public void setReportLocation(bool reportLocation);

    abstract public void setCrashReporting(bool enabled);
    
    abstract public void setDebugLog(bool enabled);

    abstract public void Dispose();
};