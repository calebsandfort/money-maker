using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMaker.Models
{
    #region EnumExtensions
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
    #endregion

    #region Attributes
    #region DisplayAttribute
    public class EnumDisplayAttribute : Attribute
    {
        internal EnumDisplayAttribute(string display)
        {
            this.Display = display;
        }
        public String Display { get; private set; }
    }
    #endregion 
    #endregion

    #region Leagues
    public enum Leagues
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("NFL")]
        Nfl
    }
    #endregion

    #region Conferences
    public enum Conferences
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("AFC")]
        American,

        [EnumDisplay("NFC")]
        National
    }
    #endregion

    #region Divisions
    public enum Divisions
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("East")]
        East,

        [EnumDisplay("South")]
        South,

        [EnumDisplay("North")]
        North,

        [EnumDisplay("West")]
        West
    }
    #endregion

    #region GameOutcomes
    public enum GameOutcomes
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("Win")]
        Win,

        [EnumDisplay("Loss")]
        Loss,

        [EnumDisplay("Tie")]
        Tie
    }
    #endregion

    #region BetOutcomes
    public enum BetOutcomes
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("Win")]
        Win,

        [EnumDisplay("Loss")]
        Loss,

        [EnumDisplay("Push")]
        Push
    }
    #endregion

    #region BetTypes
    public enum BetTypes
    {
        [EnumDisplay("None")]
        None = 0,

        [EnumDisplay("Single")]
        Single,

        [EnumDisplay("Parlay")]
        Parlay,

        [EnumDisplay("Teaser")]
        Teaser
    }
    #endregion
}
