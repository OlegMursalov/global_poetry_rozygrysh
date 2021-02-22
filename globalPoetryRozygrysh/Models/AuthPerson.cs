namespace globalPoetryRozygrysh.Models
{
    public class AuthPerson
    {
        public string VK_ID { get; set; }
        public string Pass { get; set; }
        public string Description { get; set; }

        public bool Validate(out string tooltipText)
        {
            if (string.IsNullOrEmpty(VK_ID))
            {
                tooltipText = "Заполните, пожалуйста, VK ID";
                return false;
            }
            else if (string.IsNullOrEmpty(Pass))
            {
                tooltipText = "Заполните, пожалуйста, пароль";
                return false;
            }
            else
            {
                tooltipText = null;
                return true;
            }
        }
    }
}