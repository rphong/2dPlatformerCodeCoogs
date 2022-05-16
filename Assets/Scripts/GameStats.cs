using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    //End game stats
    public static int totalPoints { get; set; }
    public static int levelReached { get; set; }
    public static int timeLived { get; set; }
    public static int timePerLevel { get; set; }

    //Stats while playing game
    public static int gameDifficulty { get; set; }
    public static int currentGameHealth { get; set; }
    public static int maxGameHealth { get; set; }
    public static int gameStartTime { get; set; }
    public static int gameEndTime { get; set; }

}
