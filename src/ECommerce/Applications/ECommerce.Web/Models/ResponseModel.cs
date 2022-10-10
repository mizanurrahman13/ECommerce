using ECommerce.Web.Enums;
using System.Globalization;

namespace ECommerce.Web.Models
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
        public string TypeCssClass { get; set; }
        public string SignCssClass { get; set; }
        public string HeaderText { get; set; }
        public string Area { get; set; }

        public ResponseModel() : this(string.Empty, ResponseTypes.Error, string.Empty)
        {
        }

        public ResponseModel(string message, ResponseTypes type, string area)
        {
            Area = area;
            TypeCssClass = type == ResponseTypes.Info ? "info"
                : type == ResponseTypes.Warning ? "warning"
                : type == ResponseTypes.Success ? "success" : type == ResponseTypes.Error ? "danger" : "";

            switch (Area)
            {
                case "admin":
                    SignCssClass = type == ResponseTypes.Success ? "bi bi-check-circle-fill"
                        : type == ResponseTypes.Error ? "bi bi-exclamation-circle"
                        : type == ResponseTypes.Warning ? "bi bi-exclamation-triangle" : "bi bi-info-circle-fill";
                    break;

                default:
                    SignCssClass = type == ResponseTypes.Success ? "fas fa-check-circle"
                        : type == ResponseTypes.Error ? "fas fa-exclamation-circle"
                        : type == ResponseTypes.Warning ? "fas fa-exclamation-triangle" : "fas fa-info-circle";
                    break;
            }

            Message = message;
            HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GetHeaderText(type).ToLower());
        }

        public string GetHeaderText(ResponseTypes type)
        {
            return type == ResponseTypes.Info ? "Info"
                : type == ResponseTypes.Warning ? "Warning"
                : type == ResponseTypes.Success ? "Success" : "Error";
        }
    }
}
