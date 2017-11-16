using Car_Service.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static Car_Service.BLL.DTO.ReservationDTO;

namespace Car_Service.Providers
{
    class CustomMultipartFileStreamProvider : MultipartMemoryStreamProvider
    {
        public ReservationDTO Reservation { get;}

        public CustomMultipartFileStreamProvider()
        {
            Reservation = new ReservationDTO();
            Reservation.File = new List<ImageDTO>();
        }

        public override async Task ExecutePostProcessingAsync()
        {

            foreach (var file in Contents)
            {
                switch (file.Headers.ContentDisposition.Name.Trim('\"'))
                {
                    case "file":
                        {
                            var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                            var fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                            var image = await file.ReadAsByteArrayAsync();
                            Reservation.File.Add(new ImageDTO { ImageBytes = image, Extension = fileExtension });
                            break;
                        }
                    case "date":
                        {
                            Reservation.Date = await file.ReadAsStringAsync();
                            break;
                        }
                    case "timeStart":
                        {
                            Reservation.TimeStart = await file.ReadAsStringAsync();
                            break;
                        }
                    case "timeEnd":
                        {
                            Reservation.TimeEnd = await file.ReadAsStringAsync();
                            break;
                        }
                    case "purpose":
                        {
                            Reservation.Purpose = await file.ReadAsStringAsync();
                            break;
                        }
                    case "breakdownDetails":
                        {
                            Reservation.BreakdownDetails = await file.ReadAsStringAsync();
                            break;
                        }
                    case "desiredDiagnosis":
                        {
                            Reservation.DesiredDiagnosis = await file.ReadAsStringAsync();
                            break;
                        }
                    case "captcha":
                        {
                            Reservation.Captcha = await file.ReadAsStringAsync();
                            break;
                        }
                    case "workerId":
                        {
                            Reservation.WorkerId = int.Parse(await file.ReadAsStringAsync());
                            break;
                        }
                }
            }
        }
    }
}