using PhotoSmart.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static PhotoSmart.Service.Services.FaceRecognitionService;
using PhotoSmart.Core.IServices;
using Microsoft.AspNetCore.Http;

namespace PhotoSmart.Service.Services
{
    public class FaceRecognitionService : IFaceRecognitionService
    {



        /// <summary>
        /// מימוש שירות שמתקשר עם שרת הפייתון לזיהוי פנים (Guest Recognition).
        /// </summary>

        private readonly HttpClient _httpClient;

        public FaceRecognitionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // יש לשנות את כתובת הבסיס לכתובת בה שירות הפייתון (FastAPI) מופעל, לדוגמה:
            _httpClient.BaseAddress = new Uri("http://localhost:8004/");
        }
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or not provided.");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            using var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType); // Use the ContentType of the uploaded file
            form.Add(fileContent, "file", file.FileName); // The key 'file' matches the API expectation

            // Send the request to the API
            HttpResponseMessage response = await _httpClient.PostAsync("images/", form);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception($"Error uploading image: {response.ReasonPhrase}");
        }
        //public async Task<string> UploadImageAsync(string filePath)
        //{
        //    // קריאת התמונה כקובץ בייטים
        //    byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
        //    var fileContent = new ByteArrayContent(fileBytes);
        //    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // או פורמט התמונה המתאים

        //    using var form = new MultipartFormDataContent();
        //    form.Add(fileContent, "file", Path.GetFileName(filePath)); // המפתח 'file' תואם את השם ב-API

        //    // שליחת הבקשה ל-API
        //    HttpResponseMessage response = await _httpClient.PostAsync("images/", form);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    throw new Exception($"Error uploading image: {response.ReasonPhrase}");
        //}
        //public async Task<string> UploadImageAsync(string filePath)
        //{
        //    // קריאת התמונה כקובץ בייטים
        //    byte[] fileBytes = await File.ReadAllBytesAsync(filePath);

        //    // המרת הבייטים לבייס64
        //    string base64Image = Convert.ToBase64String(fileBytes);

        //    // יצירת אובייקט JSON עם התמונה בבייס64
        //    var jsonContent = new
        //    {
        //        ImageData = base64Image,
        //        FileName = Path.GetFileName(filePath)
        //    };

        //    // המרת האובייקט ל-JSON
        //    var json = System.Text.Json.JsonSerializer.Serialize(jsonContent);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    // שליחת הבקשה ל-API
        //    HttpResponseMessage response = await _httpClient.PostAsync("images/upload", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    throw new Exception($"Error uploading image: {response.ReasonPhrase}");
        //}

        //public async Task<string> UploadImageAsync(string filePath)
        //{
        //    using var form = new MultipartFormDataContent();
        //    byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
        //    var fileContent = new ByteArrayContent(fileBytes);
        //    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    form.Add(fileContent, "file", Path.GetFileName(filePath));

        //    HttpResponseMessage response = await _httpClient.PostAsync("images/", form);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //    throw new Exception($"Error uploading image: {response.ReasonPhrase}");
        //}

        public async Task<string> UpdateGuestNameAsync(int guestId, string newName)
        {
            using var form = new MultipartFormDataContent();
            form.Add(new StringContent(newName), "new_name");

            // חשוב: הנתיב כאן תואם ל-endpoint המעודכן בשרת הפייתון, לדוגמה: /guests/{guestId}/name
            HttpResponseMessage response = await _httpClient.PutAsync($"guests/{guestId}/name", form);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            throw new Exception($"Error updating guest name: {response.ReasonPhrase}");
        }
    }
}
