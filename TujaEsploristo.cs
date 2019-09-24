﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TujaEsploristo
{
	public partial class TujaEsploristo : Form
	{
		public string enirejoVojo = @"E:\tuja-vortaro";// Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tuja-vortaro";// @"E:\tuja-vortaro";// 
		public string elirejoVojo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tuja-dosiero";
		public static List<string> lingvoj = new List<string>(new[] { "fr", "ru", "cs", "hu", "de", "be", "sk", "pl", "en", "nl", "pt", "es", "ca", "it", "bg", "fa", "sv", "id", "br" });//, "fi", "tr", "he", "oc", "el", "ja", "uk", "ro", "hr", "vo", "da", "zh", "tp", "no", "la", "kek", "ia", "ie", "mk", "ku", "sr", "lat", "gd", "af", "lv", "sl", "th", "grc", "eu", "os", "is", "lt", "ar", "az", "et", "kk", "ky", "sw", "tk", "tt", "ug", "uz", "cy", "ga", "gl", "ko", "mn", "ka", "vi", "yi", "jbo", "mo", "iu", "qu", "to" });
		public static List<string> balizoj = new List<string>(new[] { "ref", "#text", "ctl", "trd", "refgrp", "klr", "frm", "sncref", "k", "g", "bib", "lok", "mll" });
		public static List<string> eksbalizoj = new List<string>(new[] { "fnt", "ekz", "ind", "uzo", "url", "#comment", "aut", "vrk" });

		private string EnirejoVojo
		{
			get { return m_EnirejoVojo; }
			set { m_EnirejoVojo = value; }
		}
		private string m_EnirejoVojo;
		private string ElirejoVojo
		{
			get { return m_ElirejoVojo; }
			set { m_ElirejoVojo = value; }
		}
		private string m_ElirejoVojo;
		public TujaEsploristo()
		{
			InitializeComponent(); //http://www.reta-vortaro.de/revo/art/vir.html
			this.textBox_EnirejoVojo.Text = enirejoVojo;
			this.textBox_ElirejoVojo.Text = elirejoVojo;
		}

		private void TujaEsploristo_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(ElirejoVojo))
				 Directory.CreateDirectory(ElirejoVojo);
			string tujaElirejoxml = Path.Combine(ElirejoVojo, "xml");
			if (!Directory.Exists(tujaElirejoxml))
				Directory.CreateDirectory(tujaElirejoxml);

			var dosierojkonverteblaj = Directory.GetFiles(EnirejoVojo + @"\revo\src\xml\", "*.xml");
			progressBar_Unikodigu.Minimum = 1;
			progressBar_Unikodigu.Maximum = dosierojkonverteblaj.Count();
			progressBar_Unikodigu.Value = 1;
			progressBar_Unikodigu.Step = 1;

			progressBar_Vortaroj.Minimum = 1;
			progressBar_Vortaroj.Maximum = lingvoj.Count();
			progressBar_Vortaroj.Value = 1;
			progressBar_Vortaroj.Step = 1;
		}
		private void SavuVortaronSlosilon(List<vortaro> records, string nom)
		{
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(ElirejoVojo + @"\slosiloj", nom + ".txt")))
			{
				foreach (var v in records)
				{
					string line = string.Format("{0}-{1} : {2}", v.vorto,v.homografo, v.traduko);
					outputFile.WriteLine(line);
				}
			}
		}
		private void SavuLaVortaron(List<vortaro> records, string nom, string signature = "")
		{
			// Write the string array to a new file named "WriteLines.txt".
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(ElirejoVojo, nom + ".js")))
			{
				if (!string.IsNullOrWhiteSpace(signature))
					outputFile.WriteLine(signature);
				outputFile.WriteLine($"const {nom} = [");
				foreach (var v in records)
				{
					string line = "{" + string.Format("vorto: \"{0}\", traduko: \"{1}\", homografo: \"{2}\"", v.vorto, v.traduko,v.homografo) + "},";
					outputFile.WriteLine(line);
				}
				outputFile.WriteLine("]");
				string ligneFinale = "module.exports = { " + nom + " }";
				outputFile.WriteLine(ligneFinale);

			}
		}
		private void SavuLaEtimologiojn(List<Etimologio> records, string nom, string signature = "")
		{
			// Write the string array to a new file named "WriteLines.txt".
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(ElirejoVojo, nom + ".js")))
			{
				if (!string.IsNullOrWhiteSpace(signature))
					outputFile.WriteLine(signature);
				outputFile.WriteLine($"const {nom} = [");
				foreach (var v in records)
				{
					string line = "{" + string.Format("vorto: \"{0}\", etimologio: \"{1}\"", v.vorto, v.etimologio) + "},";
					outputFile.WriteLine(line);
				}
				outputFile.WriteLine("]");
				string ligneFinale = "module.exports = { " + nom + " }";
				outputFile.WriteLine(ligneFinale);

			}
		}
		private void SavuLaDifinojn(List<Difino> records, string nom)
		{
			// Write the string array to a new file named "WriteLines.txt".
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(ElirejoVojo, nom + ".js")))
			{
				outputFile.WriteLine($"const {nom} = [");
				foreach (var v in records)
				{
					string line = "{" + string.Format("vorto: \"{0}\", frazo: \"{1}\", ekzemploKleo:\"{2}\", retavortaro:\"{3}\"", v.vorto, v.frazo, v.ekzemploKleo, v.retavortaro) + "},";
					outputFile.WriteLine(line);
				}
				outputFile.WriteLine("]");
				string ligneFinale = "module.exports = { " + nom + " }";
				outputFile.WriteLine(ligneFinale);

			}
		}
		private void SavuLaEkzemplojn(List<Ekzemplo> records, string nom)
		{
			// Write the string array to a new file named "WriteLines.txt".
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(ElirejoVojo, nom + ".js")))
			{
				outputFile.WriteLine($"const {nom} = [");
				foreach (var v in records)
				{
					string line = "{" + string.Format("vorto: \"{0}\", frazo: \"{1}\", difinoKleo:\"{2}\", retavortaro:\"{3}\"", v.vorto, v.frazo, v.difinoKleo, v.retavortaro) + "},";
					outputFile.WriteLine(line);
				}
				outputFile.WriteLine("]");
				string ligneFinale = "module.exports = { " + nom + " }";
				outputFile.WriteLine(ligneFinale);

			}
		}
		private void unToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void Espdic_Click(object sender, EventArgs e)
		{
			//# ESPDIC (Esperanto – English Dictionary) – 20 July 2019 - Paul Denisowski (www.denisowski.org)			
			string docPath = Path.Combine(EnirejoVojo + @"\espdic", "espdic.txt");

			var query = File.ReadAllLines(docPath)
				.Where(line => line.Contains(':'))
				.Select(line =>
				{
					var columns = line.Split(':');
					return new vortaro { vorto = columns[0].Trim(), traduko = columns[1].Replace("\"", "'").Trim(), homografo = "1" };
				});

			var querydoublons = query.Where(c => c.traduko.Contains(',') || c.traduko.Contains(';'));
			var querysingletons = query.Where(c => !( c.traduko.Contains(',') || c.traduko.Contains(';')));
			List<vortaro> novListe = querysingletons.ToList();
			foreach (var line in querydoublons)
			{
				var homografoj = line.traduko.Split(';');
				int homoc = 1;
				foreach (var homografo in homografoj)
				{
					var synonymes = homografo.Split(',');
					string prevSyno = string.Empty;
					foreach (var synonyme in synonymes)
					{
						var synonym = synonyme.Replace("\"", "'").Trim();
						if (!string.IsNullOrWhiteSpace(prevSyno))
						{
							if (!synonym.Contains(")"))
								prevSyno = prevSyno + synonym + ", ";
							else
							{
								novListe.Add(new vortaro { vorto = line.vorto, traduko = prevSyno + synonym , homografo = homoc.ToString() });
								prevSyno = string.Empty;
							}
						}
						else
						if (synonym.Contains("(") && !synonym.Contains(")"))
							prevSyno = prevSyno + synonym + ", ";
						else
							novListe.Add(new vortaro { vorto = line.vorto, traduko = synonym, homografo = homoc.ToString() });
					}
					homoc++;
				}
			}

			SavuLaVortaron(novListe.OrderBy(v => v.vorto).ToList(), "eo_espdic", @"// ESPDIC by Paul Denisowski, CC-BY-3.0.");
			(sender as Button).BackColor = Color.PaleGreen;
		}
		private void etimologio_Click(object sender, EventArgs e)
		{
			string docPath = Path.Combine(EnirejoVojo + @"\etymology", "etymology.txt");

			var query = File.ReadAllLines(docPath)
				.Where(lineo => lineo.Contains('='))
				.Select(lineo =>
				{
					var columns = lineo.Split('=');
					return new Etimologio { vorto = columns[0].Trim(), etimologio = columns[1].Trim() };
				});

			SavuLaEtimologiojn(query.OrderBy(v => v.vorto).ToList(), "etimologioj", @"// Etimologio by Tuja Vortaro");
			(sender as Button).BackColor = Color.PaleGreen;
		}
		private void Unikodiĝi_Click(object sender, EventArgs e)
		{
			var document = XDocument.Load(@"literoj.xml");
			var unicodeList = (document.Element("literoj")?.Elements("l") ?? Enumerable.Empty<XElement>())
				.Where(c => c.Attribute("kodo").Value.Contains("#"))
				.Select(el => {
					int code = int.Parse(el.Attribute("kodo").Value.Replace("#x", ""), System.Globalization.NumberStyles.HexNumber);
					return new unicodage
					{
						nomo = el.Attribute("nomo")?.Value,
						kodo = char.ConvertFromUtf32(code)
					};
				}
				);

			foreach (string dir in Directory.GetFiles(EnirejoVojo + @"\revo\src\xml\", "*.xml"))
			{
				ConvertAllAnsiXMLToUTF8(dir, unicodeList);
				progressBar_Unikodigu.PerformStep();
			}
			(sender as Button).BackColor = Color.PaleGreen;
		}
		private void Vortaroj_Click(object sender, EventArgs e)
		{
			lingvoj.ForEach(l =>
			{
				var dico = AnalizuXMLPaĝojnKajTrovuTradukojn(l);
				if (dico != null)
					SavuLaVortaron(dico, "eo_" + l);
				progressBar_Vortaroj.PerformStep();
			});
			(sender as Button).BackColor = Color.PaleGreen;
		}
		private void Difinoj_Click(object sender, EventArgs e)
		{
			List<Ekzemplo> ekzemploj = new List<Ekzemplo>();
			var dicodif = AnalizuXMLPaĝonjKajTrovuDifinojnKajEkzemplojn(ekzemploj);
			if (dicodif != null)
			{
				IEnumerable<Difino> dicodifinoj = dicodif;
				IEnumerable<Ekzemplo> dicoekzemploj = ekzemploj;

				SavuLaDifinojn(dicodifinoj.OrderBy(v => v.vorto).ToList(), "difinoj");
				SavuLaEkzemplojn(dicoekzemploj.OrderBy(v => v.vorto).ToList(), "ekzemploj");
			}
			(sender as Button).BackColor = Color.PaleGreen;
		}

		#region Convertion XML Ansi vers UTF8
		private void ConvertAllAnsiXMLToUTF8(string path, IEnumerable<unicodage> unicodeList)
		{
			var query = File.ReadAllLines(path)
				.Where(line => line.Length > 0)
				.Select(line =>
				{
					string newLine = line;
					while (newLine.Contains('&'))
					{
						int pos1 = newLine.IndexOf('&');
						int pos2 = newLine.IndexOf(';', pos1);
						if (pos2 < pos1)
							return newLine;
						string code = newLine.Substring(pos1 + 1, pos2 - pos1 - 1);
						var lunicode = string.Empty;
						if (code.StartsWith("#"))
						{
							int code1 = int.Parse(code.Replace("#x", "").Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
							lunicode = char.ConvertFromUtf32(code1);
						}
						else
						{
							var trouvé = unicodeList.Where(l => l.nomo == code);
							if (trouvé != null && trouvé.Count() > 0)
								lunicode = trouvé.Select(l => l.kodo).Single();
						}
						newLine = newLine.Replace("&" + code + ";", lunicode).Replace('ȕ', '×').Replace('蜢', '-').Replace('舗', '\'').Replace('舤', '†').Replace('蜒', '∈').Replace('興', '-').Replace('蝄', '∨')
										.Replace('蝃', '∧').Replace('蜩', '∙').Replace('艂', '′').Replace('蠄', '≤')
										.Replace('ű', '«').Replace('Ƈ', '»').Replace('舖', '‘').Replace('蝇', '∫').Replace('薔', '→').Replace('蜡', '∑').Replace('蜙', '∏')
										.Replace('頰', '♦').Replace('蠴', '⊂').Replace('蠅', '≥').Replace('蜆', '∂').Replace('蜐', '∆').Replace('蜑', '∇').Replace('虘', '⇒')
										.Replace('Ų', '¬').Replace('蠵', '⊃').Replace('蜴', '∞').Replace('蜰', '√').Replace('虠', '⇔')
										.Replace('頱', '♧').Replace('頤', '♠').Replace('頥', '♡').Replace('頦', '♢')
										.Replace('蔲', '⅔').Replace('蕀', '⅜')
										;
					}
					return newLine;
				});
			string docPath = ElirejoVojo + @"\xml";
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, Path.GetFileName(path))))
			{
				foreach (var l in query)				
					outputFile.WriteLine(l);				
			}
		}
		#endregion
		
		#region vortaroStrokturoj
		public static vortoStruKt VortoStrukt(XmlNode nodedrv, string radiko)
		{
			//    <kap><ofc>*</ofc><tld/>i</kap>
			//    <kap><tld/>iĝi, <var><kap>sin <tld/>i</kap></var></kap>
			vortoStruKt aktuaVorto = new vortoStruKt();
			var veravorto = string.Empty;
			var kap = nodedrv.SelectSingleNode("kap");
			if (kap.FirstChild.NodeType == XmlNodeType.Text)
				aktuaVorto.prefikso = kap.FirstChild.Value;
			aktuaVorto.radiko = radiko;
			
			bool sekvantoEstosSufikso = false;
			foreach (XmlNode infanode in kap.ChildNodes)
			{
				if (sekvantoEstosSufikso && infanode.NodeType == XmlNodeType.Text)
				{
					aktuaVorto.sufikso = infanode.Value.Replace(",","").Trim();
					break;
				}
				if (infanode.Name == "tld")
					sekvantoEstosSufikso = true;
			}
				
			return aktuaVorto;
		}

		public static void AnalizuNodojn(XmlDocument document, string radiko, List<vortaro> dicospec, string l, Func<List<vortaro>, string, string, XmlNode, bool> serĉuTradukojnEnNodo) 
		{
			var nodedrvList = document.SelectNodes("vortaro/art/drv");
			foreach (XmlNode nodedrv in nodedrvList)
			{
				vortoStruKt vorto = VortoStrukt(nodedrv, radiko);
				serĉuTradukojnEnNodo(dicospec, vorto.vorto, l, nodedrv);
				var snc = nodedrv.SelectNodes("snc");
				foreach (XmlNode sncs in snc)
					serĉuTradukojnEnNodo(dicospec, vorto.vorto, l, sncs);
				var subsnc = nodedrv.SelectNodes("snc/subsnc");
				foreach (XmlNode subsncs in subsnc)
					serĉuTradukojnEnNodo(dicospec, vorto.vorto, l, subsncs);
			}
		}
		#endregion

		#region farigi vortaron kun tradukoj

		private List<vortaro> AnalizuXMLPaĝojnKajTrovuTradukojn(string l)
		{
			string[] fichiers = Directory.GetFiles(ElirejoVojo + @"\xml\", "*.xml");
			List<vortaro> dicospec = new List<vortaro>(55000);
			foreach (string path in fichiers)
			{
				XmlDocument document = new XmlDocument();
				document.Load(path);
				var radiko = document.SelectSingleNode("vortaro/art/kap/rad").InnerText;
				if (!string.IsNullOrWhiteSpace(radiko))
					AnalizuNodojn(document, radiko, dicospec, l, serĉuTradukojnEnNodo);
			}
			IEnumerable<vortaro> vortaroLingvo = dicospec;
			return vortaroLingvo.OrderBy(v => v.vorto).ToList();
		}
		private static bool serĉuTradukojnEnNodo(List<vortaro> dicospec, string veravorto, string l, XmlNode node)
		{
			var trd = node.SelectNodes("trd[@lng=\"" + l + "\"]");
			foreach (XmlNode trdu in trd)
				aldonuNodoEnVortaro(dicospec, veravorto, trdu.InnerText);			
			var trdgrp = node.SelectNodes("trdgrp[@lng=\"" + l + "\"]");
			foreach (XmlNode trdgrpu in trdgrp)
			{
				var trdv = trdgrpu.SelectNodes("trd");
				foreach (XmlNode trvdgrpu in trdv)
					aldonuNodoEnVortaro(dicospec, veravorto, trvdgrpu.InnerText);				
			}
			return true;
		}
		private static void aldonuNodoEnVortaro(List<vortaro> dicospec, string veravorto, string traduk)
		{
			traduk = traduk.Replace(System.Environment.NewLine, " ").Replace('"', '\'');
			traduk = traduk.Replace("  ", " ").Trim();
			if (traduk.Length > 0)
			{
				vortaro novavortaro = new vortaro { vorto = veravorto, traduko = traduk, homografo = "1" };
				if (!dicospec.Contains(novavortaro))
					dicospec.Add(novavortaro);
			}
		}
		#endregion
		#region farigi vortarojn kun definoj kaj ekzempoj
		private List<Difino> AnalizuXMLPaĝonjKajTrovuDifinojnKajEkzemplojn(List<Ekzemplo> ekzemploj)
		{
			string[] dosieroj = Directory.GetFiles(ElirejoVojo + @"\xml\", "*.xml");
			List<Difino> dicospec = new List<Difino>(55000);
			foreach (string dosiero in dosieroj)
			{
				string retafile = Path.GetFileName(dosiero);
				XmlDocument document = new XmlDocument();
				document.Load(dosiero);
				var radiko = document.SelectSingleNode("vortaro/art/kap/rad").InnerText;
				if (radiko != null)
				{
					var nodedrvList = document.SelectNodes("vortaro/art/drv");
					foreach (XmlNode nodedrv in nodedrvList)
					{
						int difno = 1;
						vortoStruKt vorto = VortoStrukt(nodedrv, radiko);
						serĉuDifinojnEnNodo(dicospec, ekzemploj, vorto, nodedrv, retafile, ref difno);
						var snc = nodedrv.SelectNodes("snc");
						foreach (XmlNode sncs in snc)
							serĉuDifinojnEnNodo(dicospec, ekzemploj, vorto, sncs, retafile, ref difno);
						var subsnc = nodedrv.SelectNodes("snc/subsnc");
						foreach (XmlNode subsncs in subsnc)
							serĉuDifinojnEnNodo(dicospec, ekzemploj, vorto, subsncs, retafile, ref difno);
					}
				}
			}
			return dicospec;
		}
		private static void serĉuDifinojnEnNodo(List<Difino> dicospec, List<Ekzemplo> ekzemploj, vortoStruKt vorto, XmlNode node, string dosiero, ref int difno)
		{
			var dif = node.SelectNodes("dif");
			foreach (XmlNode difNode in dif)
			{
				int difdif = 0;
				string diftekst = difNode.InnerText.Trim();
				if (difNode.HasChildNodes)
				{
					StringBuilder difi = new StringBuilder();
					bool spacoPost = true; //post tld, ne aldonu spaco
					int antaŭaKompto = ekzemploj.Count;
					AnalisuNodojnPorTroviDifinojKajEkzemploj(ekzemploj, vorto, difNode, difi, ref spacoPost, dosiero, difno);
					if (ekzemploj.Count == antaŭaKompto)
						difdif = 0;
					else
					{
						difdif = difno;
						difno++;
					}

					diftekst = difi.ToString();
				}

				aldonuEnDifinoj(dicospec, vorto, diftekst, dosiero, difdif, false);
			}
		}
		public static void AnalisuNodojnPorTroviDifinojKajEkzemploj(List<Ekzemplo> ekzemploj, vortoStruKt vorto, XmlNode difNode, StringBuilder difi, ref bool spacoPost, string dosiero, int difno)
		{
			if (difNode.ChildNodes.Count > 1 || (difNode.ChildNodes.Count == 1 && difNode.ChildNodes[0].Name != "#text"))
			{
				foreach (XmlNode infanode in difNode)
				{
					if (!eksbalizoj.Contains(infanode.Name))
						AnalisuNodojnPorTroviDifinojKajEkzemploj(ekzemploj, vorto, infanode, difi, ref spacoPost, dosiero, difno);
					else if (infanode.Name == "ekz")
					{
						StringBuilder defstring = new StringBuilder();
						AnalisuNodojnPorTroviDifinojKajEkzemploj(ekzemploj, vorto, infanode, defstring, ref spacoPost, dosiero, difno);
						aldonuEnEkzemploj(ekzemploj, vorto.vorto, defstring.ToString(), difno, dosiero);
					}
				}
			}
			else
				serĉuDifinojnKajEkzemplojnEnNodo(vorto, difNode, difi, ref spacoPost, dosiero);

		}
		public static void serĉuDifinojnKajEkzemplojnEnNodo(vortoStruKt vorto, XmlNode infanode, StringBuilder difi, ref bool spacoPost, string dosiero)
		{
			if (balizoj.Contains(infanode.Name))
				difi.Append(FFF(infanode.InnerText, ref spacoPost));
			else if (infanode.Name == "tld")
			{
				string rara = vorto.radiko;
				if (infanode.Attributes["lit"] != null)
				{
					if (vorto.radiko.Length == 0)
						rara = rara.ToUpper();
					else
						rara = char.ToUpper(rara[0]) + rara.Substring(1);
				}
				bool prefiksita = vorto.prefikso?.Length > 0;

				if (!string.IsNullOrWhiteSpace(vorto.prefikso))
				{
					var difinoPeco = difi.ToString();
					if (difinoPeco.Length > vorto.prefikso.Length)
					{
						var lastaPeco = difinoPeco.Substring(difinoPeco.Length - vorto.prefikso.Length);
						if (!lastaPeco.Contains(vorto.prefikso))
							prefiksita = false;
					}
				}
				if (!prefiksita)
					difi.AppendFormat(" {0}", rara);
				else
					difi.Append(rara);
				spacoPost = false;
			}
			else if (infanode.Name == "lok")
				difi.AppendFormat(" ({0})", infanode.InnerText);
			else if (infanode.Name == "em")
				difi.AppendFormat(" {0} ", infanode.InnerText);
			else if (infanode.Name == "sub" || infanode.Name == "sup")
			{
				spacoPost = false;
				//Est-ce un nombre en indice?
				string indice = infanode.InnerText.Trim();
				bool estasSub = infanode.Name == "sub";
				int unicodeBase = estasSub ? 0X2080 : 0X2070;
				foreach (char c in indice)
				{
					int unicode = 0;
					if (int.TryParse(c.ToString(), out unicode))
					{
						if (!estasSub && unicode > 0 && unicode < 4)
						{
							if (unicode == 1)
								unicode = 0X00B9;
							else if (unicode == 2)
								unicode = 0X00B2;
							else if (unicode == 3)
								unicode = 0X00B3;
						}
						else
							unicode += unicodeBase;
					}
					else if (c == '+')
						unicode = unicodeBase + 0XA;
					else if (c == '-')
						unicode = unicodeBase + 0XB;
					else if (c == '=')
						unicode = unicodeBase + 0XC;
					else if (c == '(')
						unicode = unicodeBase + 0XD;
					else if (c == ')')
						unicode = unicodeBase + 0XE;
					//else
					//	listeBalises.Add(string.Format("!!!!!UNICODE : Fichier {0}, Balise {1}, innerText={2}", fichier, infanode.Name, infanode.InnerText));
					if (unicode != 0)
						difi.Append(char.ConvertFromUtf32(unicode));
					else
						difi.Append(c);
				}
			}
			else
			{
				difi.Append(FFF(infanode.InnerText, ref spacoPost));
			}
		}
		public static string FFF(string tekst, ref bool spacoPost)
		{
			string[] lines = tekst.Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);
			bool unualino = true;
			StringBuilder novstr = new StringBuilder();
			foreach (string ligne in lines)
			{
				string puralino = ligne;
				if (!unualino || spacoPost)
					puralino = puralino.Trim();
				if (puralino.Length > 0)
				{
					if (!unualino || spacoPost)
						novstr.AppendFormat(" {0}", puralino);
					else
						novstr.Append(puralino);
					unualino = false;
				}
			}
			tekst = novstr.ToString();
			if (spacoPost)
				return string.Format(" {0}", tekst);
			spacoPost = true;
			return tekst;
		}

		private static void aldonuEnEkzemploj(List<Ekzemplo> ekzemploj, string veravorto, string traduk, int difno, string fichier)
		{
			traduk = traduk.TrimEnd(':', ' ', ',', '.', ';');
			traduk = traduk.Replace(System.Environment.NewLine, " ").Replace('"', '\'').Trim();
			traduk = traduk.Replace("  ", " ").Replace(" )", ")").Replace("( ", "(");
			if (traduk.Length > 0)
			{
				string difinoKleo = string.Format("{0}{1}", veravorto, difno);
				Ekzemplo novavortaro = new Ekzemplo { vorto = veravorto, frazo = traduk, difinoKleo = difinoKleo, retavortaro = fichier };
				ekzemploj.Add(novavortaro);
			}
		}
		private static void aldonuEnDifinoj(List<Difino> dicospec, vortoStruKt vorto, string traduk, string fichier, int difno, bool test = true)
		{
			traduk = traduk.TrimEnd(':', ' ', ',', '.', ';');
			traduk = traduk.Replace(System.Environment.NewLine, " ").Replace('"', '\'').Trim();
			traduk = traduk.Replace("  ", " ").Replace(" )", ")").Replace("( ", "(");
			if (traduk.Length > 0)
			{
				string ekzemploKleo = difno > 0 ? string.Format("{0}{1}", vorto.vorto, difno) : string.Empty;
				Difino novavortaro = new Difino { vorto = vorto.vorto, frazo = traduk, ekzemploKleo = ekzemploKleo, retavortaro = fichier };
				if (!test || !dicospec.Contains(novavortaro))
					dicospec.Add(novavortaro);
			}
		}
		#endregion
		private void Espdic_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}

		private void Ansi2UTF8_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}

		private void etimologio_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}

		private void Vortaroj_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}

		private void Difinoj_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}
		private void Slosigu_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}
		private void Deŝlosiligu_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Button).BackColor = Color.PaleVioletRed;
		}
		private void textBox_EnirejoVojo_TextChanged(object sender, EventArgs e)
		{
			EnirejoVojo  = (sender as TextBox).Text;
		}

		private void textBox_ElirejoVojo_TextChanged(object sender, EventArgs e)
		{
			ElirejoVojo = (sender as TextBox).Text;
		}

		private void button_ŝlosiligu_Click(object sender, EventArgs e)
		{
			string tujaElirejoxml = Path.Combine(ElirejoVojo, "slosiloj");
			if (!Directory.Exists(tujaElirejoxml))
				Directory.CreateDirectory(tujaElirejoxml);

			string docPath = Path.Combine(ElirejoVojo, "eo_espdic.js");
			//line => {vorto: "Zuluo", traduko: "Zulu", homografo: "1"},
			int longoVorto = 9; //{vorto: "
			int longoTraduko = 12;//, traduko: "
			int longoHomografo = 14;//, homografo: "
			var query = File.ReadAllLines(docPath)
				.Where(line => line.Contains("vorto:"))
				.Select(line =>
				{					
					int posTraduko = line.IndexOf(", traduko:");
					int posHomografo = line.IndexOf(", homografo:");
					string eo = line.Substring(longoVorto, posTraduko - longoVorto-1);
					string en = line.Substring(posTraduko + longoTraduko, posHomografo - posTraduko - longoTraduko-1);
					string ho = line.Substring(posHomografo + longoHomografo);
					ho = ho.Remove(1);
					return new vortaro { vorto = eo.Trim(), traduko = en.Trim(), homografo = ho };
				});

			List<vortaro> eoListe = new List<vortaro>();
			List<vortaro> enListe = new List<vortaro>();
			int linePos = 1;
			foreach (var line in query)
			{
				eoListe.Add(new vortaro { vorto = linePos.ToString(), traduko = line.vorto, homografo = line.homografo });
				enListe.Add(new vortaro { vorto = linePos.ToString(), traduko = line.traduko, homografo = line.homografo });
				linePos++;
			}

			SavuVortaronSlosilon(eoListe, "eo_en_slosilo_eo");
			SavuVortaronSlosilon(enListe, "eo_en_slosilo");


			foreach (string dir in Directory.GetFiles(ElirejoVojo + @"\", "eo_*.js"))
			{
				string dosi = Path.GetFileName(dir.Remove(dir.Length - 3));
				if (dosi.Contains("eo_fr"))
				{
					var queryLingvo = File.ReadAllLines(dir)
						.Where(line => line.Contains("vorto:"))
						.Select(line =>
						{
							int posTraduko = line.IndexOf(", traduko:");
							string eo = line.Substring(longoVorto, posTraduko - longoVorto - 1);
							return eo.Trim();
						});

					List<vortaro> eoLingvoListe = new List<vortaro>();
					List<vortaro> enLingvoListe = new List<vortaro>();

					List<string> espoLingvoListe = queryLingvo.ToList();
					List<string> pkeyListe = new List<string>();
					foreach (var line in eoListe)
					{
						if (!espoLingvoListe.Contains(line.traduko))
						{
							eoLingvoListe.Add(new vortaro { vorto = line.vorto, traduko = line.traduko, homografo = line.homografo });
							pkeyListe.Add(line.vorto);
						}
					}
					foreach (var line in enListe)
					{
						if (pkeyListe.Contains(line.vorto))
							enLingvoListe.Add(new vortaro { vorto = line.vorto, traduko = line.traduko, homografo = line.homografo });
					}
					SavuVortaronSlosilon(eoLingvoListe, dosi + "_slosilo_eo");
					SavuVortaronSlosilon(enLingvoListe, dosi + "_slosilo");
				}
			}



			(sender as Button).BackColor = Color.PaleGreen;

		}

		private void Deŝlosiligu_Click(object sender, EventArgs e)
		{
			string tujaElirejoxml = Path.Combine(ElirejoVojo, "slosiloj");
			if (!Directory.Exists(tujaElirejoxml))
				return;

			string eoPath = Path.Combine(tujaElirejoxml, "eo_fr_slosilo_eo.txt");
			string frPath = Path.Combine(tujaElirejoxml, "eo_fr.txt");
			if (!File.Exists(eoPath) || !File.Exists(frPath))
				return;

			//line => 11-1 : abakteria
			var eoDico = File.ReadAllLines(eoPath)
				.Where(line => line.Contains(":"))
				.Select(line =>
				{
					string[] compo = line.Split(':');					
					return new KeyValuePair<string,string>(compo[0].Trim(), compo[1].Trim());
				}).ToDictionary(x=>x.Key,x=>x.Value);


			//line => 11-1 : abakteria
			var frDico = File.ReadAllLines(frPath)
				.Where(line => line.Contains(":"))
				.Select(line =>
				{
					string[] compo = line.Split(':');
					return new KeyValuePair<string, string>(compo[0].Trim(), compo[1].Trim());
				}).ToDictionary(x => x.Key, x => x.Value);

			var compos = frDico
				.Where(x=> eoDico.ContainsKey(x.Key))
				.Select(x => 
				{
					var eoparto = eoDico[x.Key];
					string homografo = "1";
					if (x.Key.Contains('-'))
						homografo = x.Key.Split('-')[1];
					return new vortaro { vorto = eoparto, traduko = x.Value, homografo = homografo };					
					
				});
			SavuLaVortaron(compos.ToList(), "eo_fr_adicigi");
			(sender as Button).BackColor = Color.PaleGreen;
		}

	}
}
