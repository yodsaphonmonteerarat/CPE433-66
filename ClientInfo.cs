using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfo : IPlugin
  {
    public ClientInfo()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      string clientInfo = request.getPropertyByKey("RemoteEndPoint");
      string[] clientInfoParts = clientInfo.Split(':');
      string clientIP = clientInfoParts[0];
      string clientPort = clientInfoParts[1];
      string browserInfo = request.getPropertyByKey("User-Agent");
      string acceptLanguage = request.getPropertyByKey("Accept-Language");
      string acceptEncoding = request.getPropertyByKey("Accept-Encoding");

      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><body><h1>ClientInfo:</h1>");
      sb.Append("Client IP:" + clientIP + "<br>");
      sb.Append("Client Port:" + clientPort + "<br>");
      sb.Append("Browser Information: " + browserInfo + "<br>");
      sb.Append("Accept Language: " + acceptLanguage + "<br>");
      sb.Append("Accept Encoding: " + acceptEncoding + "<br>");
      sb.Append("</body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}