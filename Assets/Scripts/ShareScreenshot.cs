using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareScreenshot : MonoBehaviour {

	public void CaptureAndShareScreenshot () {
		CaptureScreenshot ();
		NativeShareScreenshot ();
	}

	public void CaptureScreenshot() {
		Texture2D tex = new Texture2D (Screen.width, Screen.height);
		tex.ReadPixels (new Rect(0,0,Screen.width,Screen.height),0,0);
		byte[] bytes = tex.EncodeToJPG ();

	}

	public void NativeShareScreenshot() {
		AndroidJavaClass jc = new AndroidJavaClass ("br.barros.jeferson.flappybird.NativeScreenshot");
		jc.CallStatic ("ShareScreenshot", GetCurrentActivity ());
	}

	public AndroidJavaObject GetCurrentActivity() {
		AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		return jc.CallStatic<AndroidJavaObject> ("currentActivity");
	}

	public string getAndroidExternalStoragePath() {
		string path = " ";

		AndroidJavaClass jc = new AndroidJavaClass ("Environment");

		path = jc.CallStatic<AndroidJavaObject> ("getExternalStorageDirectory").Call<String> ("getAbsolutePath");

		return path;
	}
}
