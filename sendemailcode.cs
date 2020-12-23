public static void Email(string htmlString) {  
    try {  
        MailMessage message = new MailMessage();  
        SmtpClient smtp = new SmtpClient();  
        message.From = new MailAddress("FromMailAddress");  
        message.To.Add(new MailAddress("ToMailAddress"));  
        message.Subject = "Test";  
        message.IsBodyHtml = true; //to make message body as html  
        message.Body = htmlString;  
        smtp.Port = 587;  
        smtp.Host = "smtp.gmail.com"; //for gmail host  
        smtp.EnableSsl = true;  
        smtp.UseDefaultCredentials = false;  
        smtp.Credentials = new NetworkCredential("FromMailAddress", "password");  
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
        smtp.Send(message);  
    } catch (Exception) {}  
}  