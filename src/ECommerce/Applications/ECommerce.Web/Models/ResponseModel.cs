using System.Globalization;

namespace ECommerce.Web.Models
{
    public class ResponseModel
    {
        public string TypeCssClass { get; set; }
        public string SignCssClass { get; set; }
        public string Message { get; set; }
        public string HeaderText { get; set; }
        public string Area { get; set; }

        public ResponseModel() : this(string.Empty, ResponseType.Error, string.Empty)
        {
        }

        public ResponseModel(string message, ResponseType type, string area)
        {
            Area = area;
            TypeCssClass = type == ResponseType.Info ? "info"
                : type == ResponseType.Warning ? "warning"
                : type == ResponseType.Success ? "success" : type == ResponseType.Error ? "danger" : "";

            switch (Area)
            {
                case "admin":
                    SignCssClass = type == ResponseType.Success ? "bi bi-check-circle-fill"
                        : type == ResponseType.Error ? "bi bi-exclamation-circle"
                        : type == ResponseType.Warning ? "bi bi-exclamation-triangle" : "bi bi-info-circle-fill";
                    break;

                default:
                    SignCssClass = type == ResponseType.Success ? "fas fa-check-circle"
                        : type == ResponseType.Error ? "fas fa-exclamation-circle"
                        : type == ResponseType.Warning ? "fas fa-exclamation-triangle" : "fas fa-info-circle";
                    break;
            }

            Message = message;
            HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GetHeaderText(type).ToLower());
        }

        public enum ResponseType
        {
            Info,
            Error,
            Success,
            Warning
        }

        public string GetHeaderText(ResponseType type)
        {
            return type == ResponseType.Info ? "Info"
                : type == ResponseType.Warning ? "Warning"
                : type == ResponseType.Success ? "Success" : "Error";
        }
    }
}
