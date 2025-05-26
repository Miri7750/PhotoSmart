using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PhotoSmart.Core.IServices
{
    public interface IFaceRecognitionService
    {


        /// <summary>
        /// מעלה תמונה לשירות הפייתון לצורך זיהוי אורחים.
        /// </summary>
        /// <param name="filePath">נתיב לקובץ התמונה</param>
        /// <returns>תשובת ה-API מהשירות הפייתון</returns>
        Task<string> UploadImageAsync(IFormFile file);

        /// <summary>
        /// מעדכן את שם האורח (Guest) אצל שירות הפייתון.
        /// </summary>
        /// <param name="guestId">המזהה של האורח</param>
        /// <param name="newName">השם החדש</param>
        /// <returns>תשובת ה-API מהשירות הפייתון</returns>
        Task<string> UpdateGuestNameAsync(int guestId, string newName);
    }
}

