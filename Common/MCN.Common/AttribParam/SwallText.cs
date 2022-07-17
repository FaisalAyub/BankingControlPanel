using System;
namespace MCN.Common.AttribParam
{
    public class SwallText
    {
        public SwallText()
        {

        }
        public SwallText(string typeV, string titleV, string htmlV)
        {
            type = typeV;
            title = titleV;
            html = htmlV;
        }
        public string type { get; set; }
        public string title { get; set; }
        public string html { get; set; }
    }
}
