using Car_Service.BLL.Interfaces;
using Car_Service.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Service.BLL.DTO;
using Car_Service.BLL.Infrastructure;
using static Car_Service.BLL.DTO.ReservationDTO;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Car_Service.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private string ReCaptchaSecretKey = "6LfTizUUAAAAAOH-_rnNKMXpi-iUzRLUjJ7adpzn";
        string ImagePath { get;}
        IUnitOfWork Database { get; set; }

        public ReservationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Create(ReservationDTO model) 
        {
            var isVerify= await verifyCaptcha(model.Captcha, ReCaptchaSecretKey);
            if(isVerify) 
            {

                return new OperationDetails(true, "", "");
            }
            else return new OperationDetails(false, "Error captcha", "");
        }
        private async Task<List<string>> UploadImage(List<ImageDTO> images, int idReservation)
        {
            List<string> urlImages = new List<string>();
            int i = 1;
            foreach (var image in images)
            {
                string fileName = string.Format("{0}_{1}{2}", idReservation);
                using (FileStream fs = new FileStream(ImagePath+fileName, FileMode.Create))
                {
                    await fs.WriteAsync(image.ImageBytes, 0, image.ImageBytes.Length);
                    urlImages.Add(fileName);
                }
                i++;
            }
            return urlImages;
        }
        private async Task<bool> verifyCaptcha(string captcha, string sekretKey)
        {
            var responce = await ReCaptcha.GetRespons(captcha, sekretKey);
            return ReCaptcha.Validate(responce); ;
        }
    }
}
