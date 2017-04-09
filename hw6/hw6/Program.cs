using opennlp.tools.tokenize;
using System;
using System.IO;
using System.Text.RegularExpressions;
using opennlp.tools.sentdetect;

namespace hw6
{
	class Program
	{
		static string[] tokens;
		static void Main(string[] args)
		{
			String[] file = Directory.GetFiles(@"..\..\..\", "*.txt");
			StreamWriter sw = new StreamWriter(@"..\..\..\output\Html.txt");
			foreach (String files in file)
			{
				using (StreamReader sr = new StreamReader(files))
				{
					while (sr.Peek() != -1)
					{
						string line = sr.ReadLine();
						int i;
						java.io.InputStream modelin = new java.io.FileInputStream(string.Format(@"{0}\en-sent.bin", @"..\Debug"));
						SentenceModel model = new SentenceModel(modelin);
						SentenceDetector detector = new SentenceDetectorME(model);
						string[] sents = detector.sentDetect(line);
						foreach (var sent in sents)
						{
							sw.WriteLine(sent);
						}


					}
				}
				sw.Flush();
			}
			sw.Close();
		}
	}
}
