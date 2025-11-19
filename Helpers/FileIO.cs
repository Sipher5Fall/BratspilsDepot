using System;


public static class FileIO
{

	/*
	 *		Log tager en List<string> lines og en string path ind
	 *		og printer hvert index i List<string> til en .txt fil 
	 *		på den path der er blevet sendt med. Det er dermed
	 *		callerens ansvar at give en filsti. Og samtidig er
	 *		det ikke nædvendigt at specificere en filtype fra 
	 *		calleren.
	 */

	//vi kan ændre List<string> til en Ordre type og så bare sende en ordre ind, og derfra afkode hvad der skal gemmes.
	public static void Log(List<string> lines, string path)
	{
		//her initialiser vi en ny StreamWriter som åbner den angivne fil eller laver en ny på den placering
		//bool værdien til sidst betyder at vi appender til filen, ikke overskriver.
		using (StreamWriter writer = new StreamWriter(path + ".txt", true))
		{
			foreach (string line in lines)
			{
				writer.WriteLine(line);
			}

		}
	}

	/*
	 *		Read læser en fil en linje af gangen, og returner en liste
	 *		af strings fra filen. som kan arbejdes med et andet sted.
	 */

	public static List<string> Read(string path)
	{
		//vi laver en liste af strings
		List<string> lines = new List<string> ();

		//vi laver en string som vi overskriver for hver linje af filen
		string line = "";

		//her læser vi filen en linje af gange, og adder line til listen lines
		using (StreamReader reader = new StreamReader(path+".txt"))
		{
			while((line = reader.ReadLine()) != null)
			{
				lines.add(line);
			}
		}

		return lines;
	}


}
