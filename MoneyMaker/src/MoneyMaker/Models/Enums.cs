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
    public class DisplayAttribute : Attribute
    {
        internal DisplayAttribute(string display)
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
        [Display("None")]
        None = 0,

        [Display("NFL")]
        Nfl
    }
    #endregion

    #region Conferences
    public enum Conferences
    {
        [Display("None")]
        None = 0,

        [Display("American")]
        American,

        [Display("National")]
        National
    }
    #endregion

    #region Divisions
    public enum Divisions
    {
        [Display("None")]
        None = 0,

        [Display("East")]
        East,

        [Display("South")]
        South,

        [Display("North")]
        North,

        [Display("West")]
        West
    }
    #endregion

    #region GameOutcomes
    public enum GameOutcomes
    {
        [Display("None")]
        None = 0,

        [Display("Win")]
        Win,

        [Display("Loss")]
        Loss,

        [Display("Tie")]
        Tie
    }
    #endregion

    #region BetOutcomes
    public enum BetOutcomes
    {
        [Display("None")]
        None = 0,

        [Display("Win")]
        Win,

        [Display("Loss")]
        Loss,

        [Display("Push")]
        Push
    }
    #endregion

    #region BetTypes
    public enum BetTypes
    {
        [Display("None")]
        None = 0,

        [Display("Single")]
        Single,

        [Display("Parlay")]
        Parlay,

        [Display("Teaser")]
        Teaser
    }
    #endregion
}
