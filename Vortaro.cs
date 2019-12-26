using System;
namespace TujaEsploristo
{
    public class vortoStruKt
    {
        public string prefikso { get; set; }
        public string radiko { get; set; }
        public string sufikso { get; set; }
        public string vorto
        {
            get
            {
                string vor = string.Empty;
                if (!string.IsNullOrWhiteSpace(prefikso))
                    vor += prefikso;
                vor += radiko;
                if (!string.IsNullOrWhiteSpace(sufikso))
                    vor += sufikso;
                vor = vor.Replace(System.Environment.NewLine, " ").Trim();
                return vor;
            }
        }
    }
    public struct vortaro
    {
        public string vorto { get; set; }
        public string traduko { get; set; }
        public string homografo { get; set; }
    }
    public struct Etimologio
    {
        public string vorto { get; set; }
        public string etimologio { get; set; }
    }
    public struct Difino
    {
        public string vorto { get; set; }
        public string frazo { get; set; }
        public string ekzemploKleo { get; set; }
        public string retavortaro { get; set; }
    }
    public struct Ekzemplo
    {
        public string vorto { get; set; }
        public string frazo { get; set; }
        public string difinoKleo { get; set; }
        public string retavortaro { get; set; }

    }
    public struct unicodage
    {
        public string nomo { get; set; }
        public string kodo { get; set; }
    }
}
