using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Wpf_OrganizeAparty
{
    internal class MyStorage
    {
        internal static void WriteXml<T>(T data, string file)
        {
			try
			{
				XmlSerializer sr = new XmlSerializer(typeof(T));
				FileStream stream;
				stream = new FileStream(file, FileMode.Create);
				sr.Serialize(stream, data);
				stream.Close();

			}
			catch (Exception x)
			{
				MessageBox.Show(x.ToString(), "Error");
				throw;
			}
        }

		internal static T ReadXml<T>(string file)
		{

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    //(T)cast it
                    return (T)serializer.Deserialize(sr);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                return default(T);
            }
        }

        internal static void WriteXml<T>(object decorations, string v)
        {
            throw new NotImplementedException();
        }
    }
}