using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

#pragma warning disable CS8321 // 區域函式已宣告但從未使用
IEnumerator DoRequest(object data)
#pragma warning restore CS8321 // 區域函式已宣告但從未使用
{
    var json = JsonUtility.ToJson(data);
    var jsonRaw = System.Text.Encoding.UTF8.GetBytes(json);

    var uploader = new UploadHandlerRaw(jsonRaw);
    uploader.contentType = "application/json; charset=utf-8";

    var downloader = new DownloadHandlerBuffer();

    var request = new UnityWebRequest("https://pas2-game-rd-lb.sayyogames.com:61337/api/unityexam/getroll", UnityWebRequest.kHttpVerbPUT);
    request.uploadHandler = uploader;
    request.downloadHandler = downloader;
    request.SetRequestHeader("Accept", "application/json");
    request.SetRequestHeader("Accept-Charset", "utf-8");

    yield return request.Send();

    var rjson = System.Text.Encoding.UTF8.GetString(downloader.data);
    // TODO: Response Json Unmarshal
}