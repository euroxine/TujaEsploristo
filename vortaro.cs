using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TujaEsploristo
{
	public class vortoStruKt
	{
		public string prefikso { get; set; }
		public string radiko { get; set; }
		public string sufikso { get; set; }
		public string vorto {
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
	public class vortaro
	{
		public string vorto { get; set; }
		public string traduko { get; set; }
		public string homografo { get; set; }
	}
	public class Etimologio
	{
		public string vorto { get; set; }
		public string etimologio { get; set; }
	}
	public class Difino
	{
		public string vorto { get; set; }
		public string frazo { get; set; }
		public string ekzemploKleo { get; set; }
		public string retavortaro { get; set; }
	}
	public class Ekzemplo
	{
		public string vorto { get; set; }
		public string frazo { get; set; }
		public string difinoKleo { get; set; }
		public string retavortaro { get; set; }

	}
	public class unicodage
	{
		public string nomo { get; set; }
		public string kodo { get; set; }
	}
}
