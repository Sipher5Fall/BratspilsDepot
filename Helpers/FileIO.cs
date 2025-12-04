using System;


public static class FileIO
{
	public static string GetRoot()
	{
		//Vi laver en string der har den filsti vi arbejder i
		string rootSti = AppDomain.CurrentDomain.BaseDirectory;
		//vi tilføjer "/Arkiv" til stien fordi vi vil have en mappe at have vores historik filer i
		string sti = rootSti + "/Arkiv";
		
		//her tester vi om mappen "/Arkiv" eksisterer, hvis ikke, så laver vi den
		if(!Directory.Exists(sti))
		{ Directory.CreateDirectory(sti); }

		return sti;
    }

    /*
	 *		Log tager en List<string> lines og en string path ind
	 *		og printer hvert index i List<string> til en .txt fil 
	 *		på den path der er blevet sendt med. Det er dermed
	 *		callerens ansvar at give en filsti. Og samtidig er
	 *		det ikke nædvendigt at specificere en filtype fra 
	 *		calleren.
	 */

    //vi kan ændre List<string> til en Ordre type og så bare sende en ordre ind, og derfra afkode hvad der skal gemmes.
    public static void Log(List<string> lines, string filNavn)
	{
		string root = GetRoot();
		string filsti = root + filNavn;
		//her initialiser vi en ny StreamWriter som åbner den angivne fil eller laver en ny på den placering
		//bool værdien til sidst betyder at vi appender til filen, ikke overskriver.
		using (StreamWriter writer = new StreamWriter(filsti + ".txt", true))
		{
			try
			{
				foreach (string line in lines)
				{
					writer.WriteLine(line);
				}
			}
			catch (Exception e)
			{
				LogError(e.Message, "/ErrorLog");
			}
		}
	}

	public static void LogOrdreId(int ordreID, string filnavn)
	{
		string root = GetRoot();
		string filsti = root + filnavn;

		using (StreamWriter writer = new StreamWriter(filsti + ".txt"))
		{
			try
			{
				writer.WriteLine(ordreID);
			}
			catch (Exception e)
			{
                LogError(e.Message, "/ErrorLog");
            }
		}
	}

	public static void LogError(string message, string filnavn)
	{
        string root = GetRoot();
        string filsti = root + filnavn;

		using (StreamWriter writer = new StreamWriter(filsti+".txt"))
		{
			writer.WriteLine(message, true); 
		}
    }

	/*
	 *		Read læser en fil en linje af gangen, og returner en liste
	 *		af strings fra filen. som kan arbejdes med et andet sted.
	 */

	public static List<string> Read(string filNavn)
	{

        string root = GetRoot();
        string filsti = root + filNavn;
        //vi laver en liste af strings
        List<string> lines = new List<string> ();

		//vi laver en string som vi overskriver for hver linje af filen
		string line = "";

		//her læser vi filen en linje af gange, og adder line til listen lines
		using (StreamReader reader = new StreamReader(filsti+".txt"))
		{
			try
			{
				while((line = reader.ReadLine()) != null)
				{
					lines.Add(line);
				}
			}
			catch (Exception e)
			{
                LogError(e.Message, "/ErrorLog");
            }
		}

		return lines;
	}

	public static int ReadOrdreId(string filNavn)
	{
        string root = GetRoot();
        string filsti = root + filNavn;
        //vi laver en liste af strings
        

        //vi laver en string som vi overskriver for hver linje af filen
        string line = "";
		int ordreID = 0;

        //her læser vi filen en linje af gange, og adder line til listen lines
        using (StreamReader reader = new StreamReader(filsti + ".txt"))
        {
			try
			{
				while ((line = reader.ReadLine()) != null)
				{
					ordreID = Convert.ToInt32(line);
				}
			}
			catch(Exception e)
			{
                LogError(e.Message, "/ErrorLog");
            }
        }

		return ordreID;
    }



}
