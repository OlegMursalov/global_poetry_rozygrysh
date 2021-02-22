namespace globalPoetryRozygrysh.Models
{
    public class AuthPerson
    {
        public string VK_ID { get; set; }
        public string Pass { get; set; }
        public string Description { get; set; }
        public string TooltipText { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(VK_ID))
            {
                TooltipText = "Заполните, пожалуйста, VK ID";
                return false;
            }
            else if (string.IsNullOrEmpty(Pass))
            {
                TooltipText = "Заполните, пожалуйста, пароль";
                return false;
            }
            else
            {
                TooltipText = null;
                return true;
            }
        }
    }
}