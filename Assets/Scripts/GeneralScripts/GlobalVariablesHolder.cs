using System;
using Unity;


public static class GlobalVariables
{
    public static int MaxCheckPointCount = 0;
    public static int PlayerCount { get; set;}
    //public static bool OnlyOnePlayer { get; set; } 
    public static bool isSplitScreen { get; set; }
    public static bool isGameReady { get; set; }
    public static int MaxPlayerCount { get; set; }

  

    public static int allPlayersFinalCheckPoint;

    public static string ErrorMessage = "DEFAULT ERROR: Error has occured!";
    public static string ErrorPage = "ErrorPage";

  


   
}
