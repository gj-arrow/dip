using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using demo.framework;
using Newtonsoft.Json;
using VkApi.Enumerables;

namespace VkApi.Utils
{
    public static class VkApiUtils
    {
        private static Dictionary<string, string> _responseDictionary = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();
        private const string Response = "response";
        private const string RegularFindResponse = @":\[?(\{?.+)\}\]?";
        private static string _boundary;
        private static HttpWebRequest _request;

        private static string GenerateStringParameters(Dictionary<string, string> parameters)
        {
            var result = "";
            var countItems = 0;
            foreach (var parameter in parameters)
            {
                countItems++;
                result += parameter.Key + parameter.Value;
                if (countItems != parameters.Count)
                {
                    result += "&";
                }
            }
        return result;
        }

        private static Dictionary<string, string> SendApiRequest(string methodName, Dictionary<string, string> parameters)
        {
            parameters.Add(ApiParameters.VERSION.GetStringMapping(), "5.73");
            var responseDict = new Dictionary<string, string>();
            var stringParameters = GenerateStringParameters(parameters);
            var requestString = string.Format(Configuration.GetUrlApi(), methodName, stringParameters);
            var request = (HttpWebRequest)WebRequest.Create(requestString);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var webResponse = (HttpWebResponse)request.GetResponse())
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var readResponse = reader.ReadToEnd();
                var responseString = GetMatchString(RegularFindResponse, readResponse).Trim(']');
                try
                {
                    responseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                }
                catch (JsonSerializationException)
                {
                    responseDict.Add(Response, responseString);
                }
                catch (JsonReaderException ex)
                {
                    throw new Exception(ex.Message + "\nResponse:" + responseString);
                }
                return responseDict;
            }
        }

        public static string CreateWallPost(string userId, string method, string token, string wallMessage)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.MESSAGE.GetStringMapping(), wallMessage);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
            return _responseDictionary["post_id"];
        }

        public static string AddPhotoInPostWithMessage(string method, string userId, string idPost, string token, string photoId, string wallMessage)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.MESSAGE.GetStringMapping(), wallMessage);
            Parameters.Add(ApiParameters.POST_ID.GetStringMapping(), idPost);
            Parameters.Add(ApiParameters.ATTACHMENTS.GetStringMapping(), "photo" + userId + "_" + photoId);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
            return wallMessage;
        }

        public static void ExecuteMessageActionWall(string userId, string idPost, string method, string token, string message)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.POST_ID.GetStringMapping(), idPost);
            Parameters.Add(ApiParameters.MESSAGE.GetStringMapping(), message);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
        }

        public static string GetUrlServerSite(string userId, string method, string token)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.GROUP_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
            return _responseDictionary["upload_url"];
        }

        public static Dictionary<string, string> UploadPhotoOnServer(string userId, string method, string token, string server, string photo, string hash)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.GROUP_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.PHOTO.GetStringMapping(), photo);
            Parameters.Add(ApiParameters.SERVER.GetStringMapping(), server);
            Parameters.Add(ApiParameters.HASH.GetStringMapping(), hash);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
            return _responseDictionary;
        }

        public static void DeleteWallPost(string userId, string idPost, string method, string token)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.POST_ID.GetStringMapping(), idPost);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
        }

        public static bool IsUserLikePost(string userId, string idPost, string method, string type, string token)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.USER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.OWNER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.TYPE.GetStringMapping(), type);
            Parameters.Add(ApiParameters.ITEM_ID.GetStringMapping(), idPost);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
            return Int32.Parse(_responseDictionary["liked"]) == 1;
        }

        public static Dictionary<string, string> AddPhotoWithMessage(string userId, string idPost, string method, string token, string pathToPhoto, string message)
        {
            var urlServer = GetUrlServerSite(userId, VkMethodItems.PHOTOS_GET_WALL_UPLOAD_SERVER.GetStringMapping(), token);
            var infoPhoto = new Dictionary<string, string>();
            var pathToPhotoFull = Environment.CurrentDirectory + pathToPhoto;
            var responseUploadFiles = UploadFilesToRemoteUrl(urlServer, pathToPhotoFull);
            var responseSavePhoto = UploadPhotoOnServer(userId, method, token, responseUploadFiles["server"],
                responseUploadFiles["photo"], responseUploadFiles["hash"]);
            AddPhotoInPostWithMessage("wall.edit", userId, idPost, token, responseSavePhoto["id"], message);
            infoPhoto.Add("photoAccessKey", responseSavePhoto["access_key"]);
            infoPhoto.Add("photoId", responseSavePhoto["id"]);
            return infoPhoto;
        }

        public static void DeletePhotoFromSite(string method, string userId, string photoPid, string token)
        {
            Parameters.Clear();
            Parameters.Add(ApiParameters.USER_ID.GetStringMapping(), userId);
            Parameters.Add(ApiParameters.PHOTO_ID.GetStringMapping(), photoPid);
            Parameters.Add(ApiParameters.ACCESS_TOKEN.GetStringMapping(), token);
            _responseDictionary = SendApiRequest(method, Parameters);
        }

        private static Stream CreateHeaderRequest(string url, string file, NameValueCollection formFields = null)
        {
            _boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.ContentType = "multipart/form-data; boundary=" + _boundary;
            _request.Method = "POST";
            _request.KeepAlive = true;
            Stream memStream = new MemoryStream();
            var boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + _boundary + "\r\n");
            var formdataTemplate = "\r\n--" + _boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
            if (formFields != null)
            {
                foreach (string key in formFields.Keys)
                {
                    string formitem = string.Format(formdataTemplate, key, formFields[key]);
                    byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }
            }
            var headerTemplate =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + "Content-Type: application/octet-stream\r\n\r\n";
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            var header = string.Format(headerTemplate, "photo", file);
            var headerbytes = Encoding.UTF8.GetBytes(header);
            memStream.Write(headerbytes, 0, headerbytes.Length);
            return memStream;
        }

        private static void CreateBodyRequest(Stream memStream, string file)
        {
            var endBoundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + _boundary + "--");
            using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[1024];
                var bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
            }
            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            _request.ContentLength = memStream.Length;
            using (var requestStream = _request.GetRequestStream())
            {
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            }
        }

        private static Dictionary<string,string> GetResultRequest()
        {
            using (var response = _request.GetResponse())
            {
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                return result;
            }
        }

        public static Dictionary<string, string> UploadFilesToRemoteUrl(string url, string file, NameValueCollection formFields = null)
        {
            var memStream = CreateHeaderRequest(url, file, formFields);
            CreateBodyRequest(memStream, file);
            return GetResultRequest();
        }

        private static string GetMatchString(string patternStr, string text)
        {
            var result = "";
            foreach (Match match in Regex.Matches(text, patternStr, RegexOptions.IgnoreCase))
            {
                result = match.Groups[1].Value;
            }
            return result;
        }
    }
}
