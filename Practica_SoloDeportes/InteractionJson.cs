using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Practica_SoloDeportes.Controllers;

namespace Practica_SoloDeportes
{
    public class InteractionJson
    {
        //var json = File.ReadAllText(@"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json");
        //solo tendra 4 metodos o 5 para modificar los json
        //actualizar ,eliminar , get all , get by id , update ,deleted, create 
        public List<InicializacionTradeMark> get()
        {
            var json = File.ReadAllText(@"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json");
            try
            {
                var obj = JObject.Parse(json);
                var result = obj["TradeMark"].ToObject<List<InicializacionTradeMark>>();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<InicializacionTradeMark> UpdateTM()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
            var json = File.ReadAllText(jsonfile);
            try

            {


                var Up = JObject.Parse(json);
                JArray ArrayJson = (JArray)Up["TradeMark"];
                var TMID = 77;
                if (TMID >= 0)
                {
                    var TMName = "Rebook";
                    foreach (var update in ArrayJson.Where(obj => obj["id"].Value<int>() == TMID))
                    {
                        update["description"] = !string.IsNullOrEmpty(TMName) ? TMName : "";
                    }
                    Up["TradeMark"] = ArrayJson;
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(Up, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);
                    //var result = Up["TradeMark"].ToObject<List<InicializacionTradeMark>>();
                    return null;

                }
                else
                {
                    Console.Write("Invalid code");
                    return UpdateTM();
                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        public List<InicializacionTradeMark> DeleteTM()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
            var json = File.ReadAllText(jsonfile);
            try
            {
                var DeleteTM = JObject.Parse(json);
                JArray ArrayJSon = (JArray)DeleteTM["TradeMark"];
                var TMID = 17;
                if (TMID > 0)
                {
                    var TMDes = string.Empty;
                    var TMDE = ArrayJSon.FirstOrDefault(obj => obj["id"].Value<int>() == TMID);
                    ArrayJSon.Remove(TMDE);
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(DeleteTM, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public List<InicializacionTradeMark> AddTM()
        {
            try
            {

                Console.WriteLine("Enter new id: ");
                var TMNW = Console.ReadLine();
                Console.WriteLine("Enter new name ");
                var TMNN = Console.ReadLine();
                InicializacionTradeMark add1 = new InicializacionTradeMark() { id = Convert.ToInt32(TMNW), description = TMNN };



                var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\TradeMarkjson.json";
                var json = File.ReadAllText(jsonfile);
                //var list = JsonConvert.DeserializeObject<List<InicializacionTradeMark>>(jsonfile;
                var jadd = JObject.Parse(json);
                var narray = jadd.GetValue("TradeMark") as JArray;
                narray.Add(JToken.FromObject(add1));

                jadd["TradeMark"] = narray;
                String output = Newtonsoft.Json.JsonConvert.SerializeObject(narray, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonfile, output);


            }
            catch (Exception)
            {

                throw;
            }
            return null;

        }

        ///----------------------------------------------------------
        public List<InicializacionSize> GetS()
        {

            var json = File.ReadAllText(@"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\Sizejson.json");
            try
            {
                var obj = JObject.Parse(json);
                var result = obj["Size"].ToObject<List<InicializacionSize>>();
                return result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<InicializacionSize> UpdateSize()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\Sizejson.json";
            var json = File.ReadAllText(jsonfile);
            try
            {
                var Up = JObject.Parse(json);
                JArray ArrayJson = (JArray)Up["Size"];
                var idS = 5;

                if (idS >= 0)
                {
                    var DSize = "XL";
                    foreach (var update in ArrayJson.Where(obj => obj["id"].Value<int>() == idS))
                    {
                        update["description"] = !string.IsNullOrEmpty(DSize) ? DSize : "";
                    }
                    Up["Size"] = ArrayJson;
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(Up, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);
                    return null;

                }

            }

            catch (Exception)
            {

                throw;
            }
            return null;

        }

        public List<InicializacionSize>DeleteSize()
        {
            var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\Sizejson.json";
            var json = File.ReadAllText(jsonfile);
            try
            {
                var DeleteS= JObject.Parse(json);
                JArray ArrayJSon = (JArray)DeleteS["Size"];
                var SID = 17;
                if (SID > 0)
                {
                    var SDes = string.Empty;
                    var SDE = ArrayJSon.FirstOrDefault(obj => obj["id"].Value<int>() == SID);
                    ArrayJSon.Remove(SDE);
                    String output = Newtonsoft.Json.JsonConvert.SerializeObject(SDE, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonfile, output);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;

        }

        public List<InicializacionSize>AddSize()
        {

            try
            {

                Console.WriteLine("Enter new id: ");
                var SID = Console.ReadLine();
                Console.WriteLine("Enter new Size ");
                var SS = Console.ReadLine();
                InicializacionSize Sizeadd = new InicializacionSize() { id = Convert.ToInt32(SID), description = SS };



                var jsonfile = @"C:\Users\axel.lautaro.umansky\source\repos\Practica_SoloDeportes\Practica_SoloDeportes\Jsons\Sizejson.json";
                var json = File.ReadAllText(jsonfile);
                //var list = JsonConvert.DeserializeObject<List<InicializacionTradeMark>>(jsonfile;
                var jadd = JObject.Parse(json);
                var narray = jadd.GetValue("TradeMark") as JArray;
                narray.Add(JToken.FromObject(add1));

                jadd["TradeMark"] = narray;
                String output = Newtonsoft.Json.JsonConvert.SerializeObject(narray, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonfile, output);


            }
            catch (Exception)
            {

                throw;
            }
            return null;

        }
    }
}

   

