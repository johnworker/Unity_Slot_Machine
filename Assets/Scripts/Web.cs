using System.Net;
using System.IO;

var request = WebRequest.Create("http://twsiyuan.com");
using (var response = request.GetResponse())
{
    using (var stream = response.GetResponseStream())
    {
        using (var reader = new StreamReader(stream))
        {
            var html = reader.ReadToEnd();
            Debug.Log(html);
        }
    }
}