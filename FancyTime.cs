using System;
using MCGalaxy;
using MCGalaxy.Commands;

namespace Plugins {

    public sealed class FancyTime : Plugin {

        public override string name { get { return "Fancy Time"; } }
        public override string creator { get{ return "Subelectronite"; } }
        public override string MCGalaxy_Version { get{ return "1.9.3.2"; } }

        public override void Load(bool startup) {
            Command.Register(new CmdFancyTime());
            Chat.MessageGlobal("Fancy Time plugin successfully loaded!");
        }

        public override void Unload(bool shutdown) {
            Command.Unregister(Command.Find("FancyTime"));
            Chat.MessageGlobal("Fancy Time plugin successfully unloaded!");
        }

    }

    public class CmdFancyTime : Command {

        public override string name { get { return "FancyTime"; } }
        public override string shortcut { get { return "FT"; } }
        public override string type { get { return "Fun"; } }

        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player commandUser, string args) {

            DateTime dt = DateTime.Now;

            string minute;
            string hour;
            string day;
            string month;
            
            // Adds ordinal indicator to day.
            switch (dt.Day){
                case 1:
                    day = dt.Day.ToString() + "st";
                    break;
                case 2:
                    day = dt.Day.ToString() + "nd";
                    break;
                case 3:
                    day = dt.Day.ToString() + "rd";
                    break;
                case 21:
                    day = dt.Day.ToString() + "st";
                    break;
                case 22:
                    day = dt.Day.ToString() + "nd";
                    break;
                case 23:
                    day = dt.Day.ToString() + "rd";
                    break;
                case 31:
                    day = dt.Day.ToString() + "st";
                    break;
                default:
                    day = dt.Day.ToString() + "th";
                    break;
            }

            // Converts month from number to word.
            switch (dt.Month){
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
                default:
                    month = "N/A";
                    break;
            }

            // Adds 0 to hour if single-digit.
            if((dt.Hour / 10) == 0) {
                hour = "0" + dt.Hour.ToString();
            }
            else {
                hour = dt.Hour.ToString();
            }

            // Adds 0 to minute if single-digit.
            if((dt.Minute / 10) == 0) {
                minute = "0" + dt.Minute.ToString();
            }
            else {
                minute = dt.Minute.ToString();
            }

            // Sends message to player.
            commandUser.Message("The date is " + dt.DayOfWeek + " " + day + " " + month + " " + dt.Year.ToString() + " and the time is " + hour + ":" + minute + ".");
        }

        // Shows help message.
        public override void Help(Player commandUser) {
            commandUser.Message("%T/FancyTime");
            commandUser.Message("%HShows the fancy time.");
        }
        
    }

}
