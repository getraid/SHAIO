namespace SHAIO
{
    public static class PathSettings
    {
        //Sets path to RCM-Smash tool by rajkosto
        public static string PathToRcmSmash { get; set; } = @"Tools/TegraRcmSmash/TegraRcmSmash.exe";

        //Sets path to where payloads/bin files are located at
        public static string PayloadPath { get; set; } = @"SDCard/Payload/";

        //Sets path to where Homebrew is located at
        public static string HomebrewPath { get; set; } = @"SDCard/Homebrew/";

        //Sets path where apx drivers are
        public static string DriverPath { get; set; } = @"Installers\apx_driver\InstallDriver.exe";

        public static string Tools { get; set; } = @"Tools/";
    }
}