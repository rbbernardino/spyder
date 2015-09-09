package com.plava.spiderspy;
 
 import android.content.Context;
 import android.os.Bundle;
 import android.telephony.PhoneStateListener;
 import android.telephony.TelephonyManager;
 import android.util.Log;
 import com.unity3d.player.UnityPlayerActivity;
 import com.unity3d.player.UnityPlayer;
 
 public class CallStatusBridge extends UnityPlayerActivity
 {    
     private static int currentState = 0;
     private static String gameObject = "callstate";
     private static String callBackName = "OnCallStateChange";
     
     protected void onCreate(Bundle savedInstanceState) 
     {
         Log.d("Unity", "CallStatus created");
         
         super.onCreate(savedInstanceState);        
         TelephonyManager telephonyManager = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
         
         PhoneStateListener phoneStateListener = new PhoneStateListener()
         {    
             @Override
             public void onCallStateChanged(int state, String incomingNumber)
             {    
                 switch (state)
                 {
                     case TelephonyManager.CALL_STATE_IDLE:
                         currentState = 0;
                         break;
                     case TelephonyManager.CALL_STATE_RINGING:
                         currentState = 1;
                         break;
                     case TelephonyManager.CALL_STATE_OFFHOOK:  
                         currentState = 2;
                         break;
                     default:
                         currentState = 0;
                         break;
                 }
                 
                 Log.d("Unity", "CurrentState:" + currentState);
                 sendCallStateToUnity(currentState);
             }
         };
         telephonyManager.listen(phoneStateListener, PhoneStateListener.LISTEN_CALL_STATE);
      }
 
     public static int getCallStatus()
     {
         return currentState;
     }
     
     public static void setCallBack(String gameObject, String callBackName)
     {
         Log.d("Unity", "setCallBack");
         CallStatusBridge.gameObject = gameObject;
         CallStatusBridge.callBackName = callBackName;
     }
 
     public static void sendCallStateToUnity(int state){
         Log.d("Unity", "sendCallState");
         UnityPlayer.UnitySendMessage(gameObject, callBackName, "" + state);
     }
 }