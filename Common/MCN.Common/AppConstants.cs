namespace MCN.Common
{
    public class AppConstants
    {
        public class FieldDisplay
        {
            public static string Textfield = "FDTP-0000001";
            public static string TextArea = "FDTP-0000002";
            public static string Dropdown = "FDTP-0000003";
            public static string UploadFile = "FDTP-0000004";
            public static string Checkbox = "FDTP-0000005";
            public static string RadioButton = "FDTP-0000006";
            public static string StaticField = "FDTP-0000007";
            public static string Label = "FDTP-0000008";
            public static string MultiSelectDropdown = "FDTP-0000009";
            public static string DateTimePicker = "FDTP-0000010";
            public static string DatePicker = "FDTP-0000011";
            public static string TimePicker = "FDTP-0000012";
            public static string HorizontalLine = "FDTP-0000013";
            public static string Heading = "FDTP-0000014";
            public static string SystemField = "FDTP-0000015";
            public static string ShadowField = "FDTP-0000016";
            public static string URL = "FDTP-0000017";
            public static string Autocomplete = "FDTP-0000018";
            public static string GroupField = "FDTP-0000019";
            public static string PDFSignature = "FDTP-0000020";
        }

        public class FieldData
        {
            public static string Integer = "FDDT-0000001";
            public static string Date = "FDDT-0000002";
            public static string Decimal = "FDDT-0000003";
            public static string Email = "FDDT-0000004";
            public static string SSN = "FDDT-0000005";
            public static string PhoneNumber = "FDDT-0000006";
            public static string ZipCode = "FDDT-0000007";
            public static string Text = "FDDT-0000008";
            public static string LargeTextArea = "FDDT-0000009";
        }

        public class ProductModule
        {
            public static string Leads = "PRDM-0000001";
            public static string Prospects = "PRDM-0000002";
            public static string Applications = "PRDM-0000003";
            public static string Events = "PRDM-0000004";
            public static string Interviews = "PRDM-0000005";
            public static string Configurator = "PRDM-0000006";
            public static string Reviews = "PRDM-0000007";
            public static string Recommenders = "PRDM-0000008";
        }

        public class SecurityEntityType
        {
            public static int Category = 1;
            public static int Action = 2;
        }

        public class UserEntityType
        {
            public static int AdminOffice = 2;
            public static int Applicant = 3;
        }

        public class GlobalSettings
        {
            public static string AuthKey = "Authorization";
            public static string TokenPrefix = "Bearer";
        }

        public class ApplicationStatuses
        {
            public static int INPROGRESS = 1;
            public static int RECEIVE = 2;
            public static int MANAGE = 3;
            public static int ARCHIVE = 4;
        }
    }
}
