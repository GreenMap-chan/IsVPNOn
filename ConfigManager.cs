

static class ConfigManager
{
    public static string[] ipServices = {
            "https://api.ipify.org",        
            "https://icanhazip.com",        
            "https://checkip.amazonaws.com", 
            "https://ifconfig.me/ip",         
            "https://ident.me",             
            "https://ipecho.net/plain",     
            "https://myexternalip.com/raw",  
            "https://wtfismyip.com/text",    
            "https://ipinfo.io/ip",           
            "https://api.my-ip.io/ip.txt",   
            "https://ip4.seeip.org",       
            "https://ip.seeip.org",     
            "https://whatismyip.akamai.com",  
            "https://l2.io/ip",                
        };
    public static string AppDataPath = "./data/appdata.json";
    public static int timerInterval = 5000;
}